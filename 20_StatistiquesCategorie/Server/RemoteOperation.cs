using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Interfaces;

namespace Server
{
    public class RemoteOperation : MarshalByRefObject, IRemoteOperation
    {
        // MACHINE 2: change Oracle host, port, service and credentials for deployment.
        private const string oradb = "Data Source=localhost:1522/XEPDB1; User Id=oracle; Password=manager;";
        public override object InitializeLifetimeService()
        {
            return null;
        }
        public string TesterConnexion(string n)
        {
            return "Bonjour " + n;
        }
        private DataSet Query(string sql, Action<OracleCommand> b = null)
        {
            try
            {
                using (var c = new OracleConnection(oradb)) using (var cmd = new OracleCommand(sql, c))
                {
                    cmd.BindByName = true;
                    if (b != null) b(cmd);
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
                Console.Error.WriteLine(e.Message);
                throw new InvalidOperationException("Erreur de base de données.");
            }
        }
        private int Execute(string sql, Action<OracleCommand> b)
        {
            try
            {
                using (var c = new OracleConnection(oradb)) using (var cmd = new OracleCommand(sql, c))
                {
                    cmd.BindByName = true;
                    b(cmd);
                    c.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (OracleException e)
            {
                Console.Error.WriteLine(e.Message);
                throw new InvalidOperationException("Erreur de base de données.");
            }
        }
        private static void Verifier(string p, string cat, int q, decimal prix)
        {
            if (string.IsNullOrWhiteSpace(p) || p.Trim().Length > 60 || string.IsNullOrWhiteSpace(cat) || cat.Trim().Length > 40 || q <= 0 || q > 999999 || prix < 0 || prix > 9999999999.99m) throw new ArgumentException("Vente invalide.");
        }
        public DataSet GetVentes()
        {
            return Query("SELECT idvente,produit,categorie,quantite,prixunitaire,quantite*prixunitaire AS montant FROM VenteCategorie ORDER BY idvente");
        }
        public DataSet RechercherVente(int idVente)
        {
            return Query("SELECT idvente,produit,categorie,quantite,prixunitaire,quantite*prixunitaire AS montant FROM VenteCategorie WHERE idvente=:id", c => c.Parameters.Add("id", OracleDbType.Int32).Value = idVente);
        }
        private int Sauver(int id, string p, string cat, int q, decimal prix, bool modifier)
        {
            Verifier(p, cat, q, prix);
            return Execute(modifier ? "UPDATE VenteCategorie SET produit=:produit,categorie=:categorie,quantite=:quantite,prixunitaire=:prix WHERE idvente=:id" : "INSERT INTO VenteCategorie(idvente,produit,categorie,quantite,prixunitaire) VALUES(:id,:produit,:categorie,:quantite,:prix)", c =>
            {
                c.Parameters.Add("id", OracleDbType.Int32).Value = id;
                c.Parameters.Add("produit", OracleDbType.Varchar2).Value = p.Trim();
                c.Parameters.Add("categorie", OracleDbType.Varchar2).Value = cat.Trim();
                c.Parameters.Add("quantite", OracleDbType.Int32).Value = q;
                c.Parameters.Add("prix", OracleDbType.Decimal).Value = prix;
            });
        }
        public int AjouterVente(int idVente, string produit, string categorie, int quantite, decimal prixUnitaire)
        {
            return Sauver(idVente, produit, categorie, quantite, prixUnitaire, false);
        }
        public int ModifierVente(int idVente, string produit, string categorie, int quantite, decimal prixUnitaire)
        {
            return Sauver(idVente, produit, categorie, quantite, prixUnitaire, true);
        }
        public int SupprimerVente(int idVente)
        {
            return Execute("DELETE FROM VenteCategorie WHERE idvente=:id", c => c.Parameters.Add("id", OracleDbType.Int32).Value = idVente);
        }
        // TRICK 20: WHERE filters rows before GROUP BY; HAVING filters groups after aggregation.
        public DataSet GetStatistiquesParCategorie()
        {
            return Query("SELECT categorie,COUNT(*) AS nombre_ventes,SUM(quantite) AS quantite_totale,SUM(quantite*prixunitaire) AS chiffre_affaires,ROUND(AVG(prixunitaire),2) AS prix_moyen,MIN(quantite*prixunitaire) AS montant_min,MAX(quantite*prixunitaire) AS montant_max FROM VenteCategorie GROUP BY categorie ORDER BY categorie");
        }
        public DataSet GetCategoriesParChiffreAffaires(decimal seuil)
        {
            if (seuil < 0) throw new ArgumentException("Seuil invalide.");
            return Query("SELECT categorie,SUM(quantite*prixunitaire) AS chiffre_affaires FROM VenteCategorie GROUP BY categorie HAVING SUM(quantite*prixunitaire)>:seuil ORDER BY categorie", c => c.Parameters.Add("seuil", OracleDbType.Decimal).Value = seuil);
        }
        public DataSet GetCategoriesParNombreVentes(int nombreMinimum)
        {
            if (nombreMinimum < 0) throw new ArgumentException("Nombre invalide.");
            return Query("SELECT categorie,COUNT(*) AS nombre_ventes FROM VenteCategorie GROUP BY categorie HAVING COUNT(*)>=:nombre ORDER BY categorie", c => c.Parameters.Add("nombre", OracleDbType.Int32).Value = nombreMinimum);
        }
        public DataSet GetStatistiquesParCategorieEtProduit()
        {
            return Query("SELECT categorie,produit,COUNT(*) AS nombre_ventes,SUM(quantite) AS quantite_totale,SUM(quantite*prixunitaire) AS chiffre_affaires FROM VenteCategorie GROUP BY categorie,produit ORDER BY categorie,produit");
        }
        public DataSet GetStatistiquesPrixMinimum(decimal prixMinimum)
        {
            if (prixMinimum < 0) throw new ArgumentException("Prix invalide.");
            return Query("SELECT categorie,COUNT(*) AS nombre_ventes,SUM(quantite*prixunitaire) AS chiffre_affaires FROM VenteCategorie WHERE prixunitaire>=:prix GROUP BY categorie ORDER BY categorie", c => c.Parameters.Add("prix", OracleDbType.Decimal).Value = prixMinimum);
        }
        // AVG gives equal weight to each sale; weighted price uses quantity. NULLIF protects division.
        public DataSet GetPrixMoyenPondereParCategorie()
        {
            return Query("SELECT categorie,ROUND(AVG(prixunitaire),2) AS prix_moyen_simple,ROUND(SUM(quantite*prixunitaire)/NULLIF(SUM(quantite),0),2) AS prix_moyen_pondere FROM VenteCategorie GROUP BY categorie ORDER BY categorie");
        }
        // Combine WHERE prixunitaire>=:prix, GROUP BY categorie, HAVING SUM(quantite*prixunitaire)>:seuil.
    }
}
