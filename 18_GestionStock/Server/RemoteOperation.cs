using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Interfaces;

namespace Server
{
    public class RemoteOperation : MarshalByRefObject, IRemoteOperation
    {
        // MACHINE 2: change host, port, service and credentials for deployment.
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
                        da.Fill(ds, "Produits");
                        return ds;
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.Error.WriteLine(ex.Message);
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
            catch (OracleException ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw new InvalidOperationException("Erreur Oracle ou dépassement numérique.");
            }
        }
        private static void Verifier(string d, int seuil)
        {
            if (string.IsNullOrWhiteSpace(d) || d.Trim().Length > 60 || seuil < 0 || seuil > 99999999) throw new ArgumentException("Produit invalide.");
        }
        private static void Mouvement(int q)
        {
            if (q <= 0 || q > 99999999) throw new ArgumentException("Quantité de mouvement invalide.");
        }
        public DataSet GetProduits()
        {
            return Query("SELECT * FROM ProduitStock ORDER BY idproduit");
        }
        public DataSet RechercherProduit(int idProduit)
        {
            return Query("SELECT * FROM ProduitStock WHERE idproduit=:id", c => c.Parameters.Add("id", OracleDbType.Int32).Value = idProduit);
        }
        public int AjouterProduit(int idProduit, string designation, int seuilAlerte)
        {
            Verifier(designation, seuilAlerte);
            return Execute("INSERT INTO ProduitStock(idproduit,designation,quantite,seuilalerte) VALUES(:id,:designation,0,:seuil)", c =>
            {
                c.Parameters.Add("id", OracleDbType.Int32).Value = idProduit;
                c.Parameters.Add("designation", OracleDbType.Varchar2).Value = designation.Trim();
                c.Parameters.Add("seuil", OracleDbType.Int32).Value = seuilAlerte;
            });
        }
        public int ModifierProduit(int idProduit, string designation, int seuilAlerte)
        {
            Verifier(designation, seuilAlerte);
            return Execute("UPDATE ProduitStock SET designation=:designation,seuilalerte=:seuil WHERE idproduit=:id", c =>
            {
                c.Parameters.Add("id", OracleDbType.Int32).Value = idProduit;
                c.Parameters.Add("designation", OracleDbType.Varchar2).Value = designation.Trim();
                c.Parameters.Add("seuil", OracleDbType.Int32).Value = seuilAlerte;
            });
        }
        public int SupprimerProduit(int idProduit)
        {
            return Execute("DELETE FROM ProduitStock WHERE idproduit=:id AND quantite=0", c => c.Parameters.Add("id", OracleDbType.Int32).Value = idProduit);
        }
        // TRICK 18: atomic UPDATE adds to existing stock instead of replacing it.
        public int AjouterEntreeStock(int idProduit, int quantite)
        {
            Mouvement(quantite);
            return Execute("UPDATE ProduitStock SET quantite=quantite+:quantite WHERE idproduit=:id", c =>
            {
                c.Parameters.Add("id", OracleDbType.Int32).Value = idProduit;
                c.Parameters.Add("quantite", OracleDbType.Int32).Value = quantite;
            });
        }
        // Oracle checks stock and decrements in the same UPDATE, preventing competing exits from making stock negative.
        public int EnregistrerSortieStock(int idProduit, int quantite)
        {
            Mouvement(quantite);
            return Execute("UPDATE ProduitStock SET quantite=quantite-:quantite WHERE idproduit=:id AND quantite>=:quantite", c =>
            {
                c.Parameters.Add("id", OracleDbType.Int32).Value = idProduit;
                c.Parameters.Add("quantite", OracleDbType.Int32).Value = quantite;
            });
        }
        public DataSet GetProduitsEnAlerte()
        {
            return Query("SELECT * FROM ProduitStock WHERE quantite<=seuilalerte ORDER BY quantite,designation");
        }
        public DataSet GetProduitsEpuises()
        {
            return Query("SELECT * FROM ProduitStock WHERE quantite=0 ORDER BY designation");
        }
        // null means missing product; zero is a real stock value.
        public int? GetQuantiteStock(int idProduit)
        {
            try
            {
                using (var c = new OracleConnection(oradb)) using (var cmd = new OracleCommand("SELECT quantite FROM ProduitStock WHERE idproduit=:id", c))
                {
                    cmd.BindByName = true;
                    cmd.Parameters.Add("id", OracleDbType.Int32).Value = idProduit;
                    c.Open();
                    object v = cmd.ExecuteScalar();
                    return v == null || v == DBNull.Value ? (int?) null : Convert.ToInt32(v);
                }
            }
            catch (OracleException ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw new InvalidOperationException("Erreur de base de données.");
            }
        }
    }
}
