using System;
using System.Data;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using Interfaces;

namespace Server
{
    public class RemoteOperation : MarshalByRefObject, IRemoteOperation
    {
        // MACHINE 2: set the database host, listener port, service and credentials.
        private static readonly string oradb = System.Configuration.ConfigurationManager.ConnectionStrings["OraclePrincipale"].ConnectionString;
        public override object InitializeLifetimeService()
        {
            return null;
        }
        public string TesterConnexion(string nomClient)
        {
            return "Bonjour " + nomClient;
        }
        private static InvalidOperationException Erreur(OracleException e)
        {
            Console.Error.WriteLine(e.Message);
            string message = e.Number == 2292 ? "Suppression impossible : des enregistrements liés existent." : e.Number == 2291 ? "Référence introuvable (client ou produit)." : e.Number == 1 ? "Identifiant déjà utilisé." : "Erreur Oracle : vérifiez la connexion et les données.";
            return new InvalidOperationException(message);
        }
        private DataSet Query(string sql, Action<OracleCommand> bind = null)
        {
            try
            {
                using (var c = new OracleConnection(oradb)) using (var cmd = new OracleCommand(sql, c))
                {
                    cmd.BindByName = true;
                    if (bind != null) bind(cmd);
                    using (var da = new OracleDataAdapter(cmd))
                    {
                        var ds = new DataSet();
                        da.Fill(ds, "Resultats");
                        return ds;
                    }
                }
            }
            catch (OracleException e)
            {
                throw Erreur(e);
            }
        }
        private int Execute(string sql, Action<OracleCommand> bind)
        {
            try
            {
                using (var c = new OracleConnection(oradb)) using (var cmd = new OracleCommand(sql, c))
                {
                    cmd.BindByName = true;
                    bind(cmd);
                    c.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (OracleException e)
            {
                throw Erreur(e);
            }
        }
        public DataSet GetClients()
        {
            return Query("SELECT * FROM Client_Commande ORDER BY nom,idclient");
        }
        public DataSet GetProduits()
        {
            return Query("SELECT * FROM Produit_Commande ORDER BY designation,idproduit");
        }
        public DataSet RechercherClient(int idClient)
        {
            return Query("SELECT * FROM Client_Commande WHERE idclient=:id", c => c.Parameters.Add("id", OracleDbType.Int32).Value = idClient);
        }
        public DataSet RechercherProduit(int idProduit)
        {
            return Query("SELECT * FROM Produit_Commande WHERE idproduit=:id", c => c.Parameters.Add("id", OracleDbType.Int32).Value = idProduit);
        }
        private static string Obligatoire(string v, int max)
        {
            if (string.IsNullOrWhiteSpace(v) || v.Trim().Length > max) throw new ArgumentException("Texte invalide.");
            return v.Trim();
        }
        private static object Telephone(string v)
        {
            if (v != null && v.Trim().Length > 20) throw new ArgumentException("Téléphone invalide.");
            return string.IsNullOrWhiteSpace(v) ? (object) DBNull.Value : v.Trim();
        }
        public int AjouterClient(int idClient, string nom, string telephone)
        {
            string n = Obligatoire(nom, 60);
            object t = Telephone(telephone);
            return Execute("INSERT INTO Client_Commande(idclient,nom,telephone) VALUES(:id,:nom,:telephone)", c =>
            {
                c.Parameters.Add("id", OracleDbType.Int32).Value = idClient;
                c.Parameters.Add("nom", OracleDbType.Varchar2).Value = n;
                c.Parameters.Add("telephone", OracleDbType.Varchar2).Value = t;
            });
        }
        public int ModifierClient(int idClient, string nom, string telephone)
        {
            string n = Obligatoire(nom, 60);
            object t = Telephone(telephone);
            return Execute("UPDATE Client_Commande SET nom=:nom,telephone=:telephone WHERE idclient=:id", c =>
            {
                c.Parameters.Add("id", OracleDbType.Int32).Value = idClient;
                c.Parameters.Add("nom", OracleDbType.Varchar2).Value = n;
                c.Parameters.Add("telephone", OracleDbType.Varchar2).Value = t;
            });
        }
        public int SupprimerClient(int idClient)
        {
            return Execute("DELETE FROM Client_Commande WHERE idclient=:id", c => c.Parameters.Add("id", OracleDbType.Int32).Value = idClient);
        }
        public int AjouterProduit(int idProduit, string designation, decimal prix, int stock)
        {
            string d = Obligatoire(designation, 60);
            if (prix < 0 || stock < 0) throw new ArgumentException("Prix ou stock invalide.");
            return Execute("INSERT INTO Produit_Commande(idproduit,designation,prix,stock) VALUES(:id,:designation,:prix,:stock)", c =>
            {
                c.Parameters.Add("id", OracleDbType.Int32).Value = idProduit;
                c.Parameters.Add("designation", OracleDbType.Varchar2).Value = d;
                c.Parameters.Add("prix", OracleDbType.Decimal).Value = prix;
                c.Parameters.Add("stock", OracleDbType.Int32).Value = stock;
            });
        }
        public int ModifierProduit(int idProduit, string designation, decimal prix)
        {
            string d = Obligatoire(designation, 60);
            if (prix < 0) throw new ArgumentException("Prix invalide.");
            return Execute("UPDATE Produit_Commande SET designation=:designation,prix=:prix WHERE idproduit=:id", c =>
            {
                c.Parameters.Add("id", OracleDbType.Int32).Value = idProduit;
                c.Parameters.Add("designation", OracleDbType.Varchar2).Value = d;
                c.Parameters.Add("prix", OracleDbType.Decimal).Value = prix;
            });
        }
        public int SupprimerProduit(int idProduit)
        {
            return Execute("DELETE FROM Produit_Commande WHERE idproduit=:id", c => c.Parameters.Add("id", OracleDbType.Int32).Value = idProduit);
        }
        // TRICK 21: explicit INNER JOIN follows the foreign key; aliases qualify each column.
        // Traditional alternative: SELECT c.idcommande,cl.nom FROM Commande c, Client_Commande cl WHERE c.idclient=cl.idclient.
        // Four tables: SELECT cl.nom,c.idcommande,p.designation,lc.quantite,lc.prixunitaire,lc.quantite*lc.prixunitaire AS montant
        // FROM Client_Commande cl JOIN Commande c ON c.idclient=cl.idclient JOIN Ligne_Commande lc ON lc.idcommande=c.idcommande JOIN Produit_Commande p ON p.idproduit=lc.idproduit.
        private const string Commandes = "SELECT c.idcommande,c.datecommande,cl.idclient,cl.nom AS nom_client FROM Commande c INNER JOIN Client_Commande cl ON cl.idclient=c.idclient";
        public DataSet GetCommandes()
        {
            return Query(Commandes + " ORDER BY c.datecommande DESC,c.idcommande DESC");
        }
        public DataSet GetCommandesParClient(int idClient)
        {
            return Query(Commandes + " WHERE cl.idclient=:id ORDER BY c.datecommande DESC,c.idcommande DESC", c => c.Parameters.Add("id", OracleDbType.Int32).Value = idClient);
        }
        public DataSet GetLignesCommande(int idCommande)
        {
            return Query("SELECT lc.idcommande,lc.idproduit,p.designation,lc.quantite,lc.prixunitaire,lc.quantite*lc.prixunitaire AS montant FROM Ligne_Commande lc INNER JOIN Produit_Commande p ON p.idproduit=lc.idproduit WHERE lc.idcommande=:id ORDER BY lc.idproduit", c => c.Parameters.Add("id", OracleDbType.Int32).Value = idCommande);
        }
        // Composite key requires both columns in SELECT, UPDATE or DELETE predicates.
        public DataSet RechercherLigneCommande(int idCommande, int idProduit)
        {
            return Query("SELECT * FROM Ligne_Commande WHERE idcommande=:commande AND idproduit=:produit", c =>
            {
                c.Parameters.Add("commande", OracleDbType.Int32).Value = idCommande;
                c.Parameters.Add("produit", OracleDbType.Int32).Value = idProduit;
            });
        }
        public DataSet GetClientsSansCommandes()
        {
            return Query("SELECT cl.idclient,cl.nom FROM Client_Commande cl LEFT JOIN Commande c ON c.idclient=cl.idclient WHERE c.idcommande IS NULL");
        }
        public DataSet GetProduitsJamaisCommandes()
        {
            return Query("SELECT p.idproduit,p.designation FROM Produit_Commande p LEFT JOIN Ligne_Commande lc ON lc.idproduit=p.idproduit WHERE lc.idproduit IS NULL");
        }
        // Alternative: SELECT cl.idclient FROM Client_Commande cl WHERE NOT EXISTS (SELECT 1 FROM Commande c WHERE c.idclient=cl.idclient).
        // Two independent connections, not a distributed transaction or cross-database JOIN.
        public DataSet GetProduitsDeuxBases()
        {
            var second = System.Configuration.ConfigurationManager.ConnectionStrings["OracleSecondaire"];
            if (second == null || string.IsNullOrWhiteSpace(second.ConnectionString)) throw new InvalidOperationException("Configurez OracleSecondaire dans Server/App.config.");
            var ds = new DataSet();
            var table = new DataTable("Produits");
            table.Columns.Add("IDPRODUIT", typeof(int));
            table.Columns.Add("DESIGNATION", typeof(string));
            table.Columns.Add("STOCK", typeof(int));
            table.Columns.Add("SOURCE", typeof(string));
            try
            {
                foreach (var source in new[]
                {
                    new { Connection = oradb, Nom = "PRINCIPALE" }, new { Connection = second.ConnectionString, Nom = "SECONDAIRE" }
                })
                {
                    using (var c = new OracleConnection(source.Connection)) using (var cmd = new OracleCommand("SELECT idproduit,designation,stock FROM Produit_Commande", c))
                    {
                        c.Open();
                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read()) table.Rows.Add(Convert.ToInt32(r.GetValue(0)), r.GetString(1), Convert.ToInt32(r.GetValue(2)), source.Nom);
                        }
                    }
                }
                ds.Tables.Add(table);
                return ds;
            }
            catch (OracleException e)
            {
                throw Erreur(e);
            }
        }
        // COUNT DISTINCT avoids multiplying order counts by the number of lines; LEFT JOIN preserves clients without orders.
        public DataSet GetChiffreAffairesParClient()
        {
            return Query("SELECT cl.idclient,cl.nom,COUNT(DISTINCT c.idcommande) AS nombre_commandes,NVL(SUM(lc.quantite*lc.prixunitaire),0) AS chiffre_affaires FROM Client_Commande cl LEFT JOIN Commande c ON c.idclient=cl.idclient LEFT JOIN Ligne_Commande lc ON lc.idcommande=c.idcommande GROUP BY cl.idclient,cl.nom ORDER BY chiffre_affaires DESC");
        }
        public decimal CalculerTotalCommande(int idCommande)
        {
            try
            {
                using (var c = new OracleConnection(oradb)) using (var cmd = new OracleCommand("SELECT NVL(SUM(quantite*prixunitaire),0) FROM Ligne_Commande WHERE idcommande=:id", c))
                {
                    cmd.BindByName = true;
                    cmd.Parameters.Add("id", OracleDbType.Int32).Value = idCommande;
                    c.Open();
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            catch (OracleException e)
            {
                throw Erreur(e);
            }
        }
        // TRICK 21: one transaction covers header, conditional stock changes and server-priced lines.
        public int AjouterCommande(int idCommande, int idClient, DateTime dateCommande, DataTable lignes)
        {
            if (lignes == null || !lignes.Columns.Contains("IDPRODUIT") || !lignes.Columns.Contains("QUANTITE") || lignes.Columns["IDPRODUIT"].DataType != typeof(int) || lignes.Columns["QUANTITE"].DataType != typeof(int) || lignes.Rows.Count == 0) throw new ArgumentException("Lignes invalides.");
            var ids = new HashSet<int>();
            foreach (DataRow r in lignes.Rows)
            {
                if (r.RowState == DataRowState.Deleted || r.IsNull("IDPRODUIT") || r.IsNull("QUANTITE")) throw new ArgumentException("Ligne invalide.");
                int id = (int) r["IDPRODUIT"], q = (int) r["QUANTITE"];
                if (id <= 0 || q <= 0 || q > 99999999 || !ids.Add(id)) throw new ArgumentException("Produit, quantité ou doublon invalide.");
            }
            try
            {
                using (var c = new OracleConnection(oradb))
                {
                    c.Open();
                    using (var tx = c.BeginTransaction())
                    {
                        try
                        {
                            using (var cmd = new OracleCommand("INSERT INTO Commande(idcommande,idclient,datecommande) VALUES(:commande,:client,:datecommande)", c))
                            {
                                cmd.Transaction = tx;
                                cmd.BindByName = true;
                                cmd.Parameters.Add("commande", OracleDbType.Int32).Value = idCommande;
                                cmd.Parameters.Add("client", OracleDbType.Int32).Value = idClient;
                                cmd.Parameters.Add("datecommande", OracleDbType.Date).Value = dateCommande;
                                cmd.ExecuteNonQuery();
                            }
                            foreach (DataRow r in lignes.Rows)
                            {
                                int id = (int) r["IDPRODUIT"], q = (int) r["QUANTITE"];
                                using (var cmd = new OracleCommand("UPDATE Produit_Commande SET stock=stock-:q WHERE idproduit=:id AND stock>=:q", c))
                                {
                                    cmd.Transaction = tx;
                                    cmd.BindByName = true;
                                    cmd.Parameters.Add("q", OracleDbType.Int32).Value = q;
                                    cmd.Parameters.Add("id", OracleDbType.Int32).Value = id;
                                    if (cmd.ExecuteNonQuery() != 1) throw new InvalidOperationException("Produit introuvable ou stock insuffisant : " + id);
                                }
                                using (var cmd = new OracleCommand("INSERT INTO Ligne_Commande(idcommande,idproduit,quantite,prixunitaire) SELECT :commande,idproduit,:q,prix FROM Produit_Commande WHERE idproduit=:id", c))
                                {
                                    cmd.Transaction = tx;
                                    cmd.BindByName = true;
                                    cmd.Parameters.Add("commande", OracleDbType.Int32).Value = idCommande;
                                    cmd.Parameters.Add("q", OracleDbType.Int32).Value = q;
                                    cmd.Parameters.Add("id", OracleDbType.Int32).Value = id;
                                    if (cmd.ExecuteNonQuery() != 1) throw new InvalidOperationException("Produit introuvable.");
                                }
                            }
                            tx.Commit();
                            return 1;
                        }
                        catch
                        {
                            try
                            {
                                tx.Rollback();
                            }
                            catch (Exception rollback)
                            {
                                Console.Error.WriteLine("Rollback: " + rollback.Message);
                            }
                            throw;
                        }
                    }
                }
            }
            catch (OracleException e)
            {
                throw Erreur(e);
            }
        }
    }
}
