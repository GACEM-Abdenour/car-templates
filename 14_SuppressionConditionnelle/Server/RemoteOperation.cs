using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Interfaces;

namespace Server
{
    public class RemoteOperation : MarshalByRefObject, IRemoteOperation
    {
        // MACHINE 2: change the Oracle server, listener, service and credentials for deployment.
        private const string oradb = "Data Source=localhost:1522/XEPDB1; User Id=oracle; Password=manager;";
        public override object InitializeLifetimeService()
        {
            return null;
        }
        public string TesterConnexion(string nomClient)
        {
            return "Bonjour " + nomClient;
        }
        private DataSet Query(string sql, Action<OracleCommand> bind = null)
        {
            using (var c = new OracleConnection(oradb)) using (var cmd = new OracleCommand(sql, c))
            {
                cmd.BindByName = true;
                if (bind != null) bind(cmd);
                using (var da = new OracleDataAdapter(cmd))
                {
                    var ds = new DataSet();
                    da.Fill(ds, "Produits");
                    return ds;
                }
            }
        }
        private int Execute(string sql, Action<OracleCommand> bind = null)
        {
            using (var c = new OracleConnection(oradb)) using (var cmd = new OracleCommand(sql, c))
            {
                cmd.BindByName = true;
                if (bind != null) bind(cmd);
                c.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        private static void Verifier(string d, string cat, int q)
        {
            if (string.IsNullOrWhiteSpace(d) || d.Trim().Length > 60 || string.IsNullOrWhiteSpace(cat) || cat.Trim().Length > 40 || q < 0 || q > 999999) throw new ArgumentException("Produit invalide.");
        }
        public DataSet GetProduits()
        {
            return Query("SELECT * FROM ProduitSuppression ORDER BY idproduit");
        }
        public DataSet RechercherProduit(int idProduit)
        {
            return Query("SELECT * FROM ProduitSuppression WHERE idproduit=:id", c => c.Parameters.Add("id", OracleDbType.Int32).Value = idProduit);
        }
        public int AjouterProduit(int idProduit, string designation, string categorie, int quantite)
        {
            Verifier(designation, categorie, quantite);
            return Execute("INSERT INTO ProduitSuppression(idproduit,designation,categorie,quantite) VALUES(:id,:designation,:categorie,:quantite)", c =>
            {
                c.Parameters.Add("id", OracleDbType.Int32).Value = idProduit;
                c.Parameters.Add("designation", OracleDbType.Varchar2).Value = designation.Trim();
                c.Parameters.Add("categorie", OracleDbType.Varchar2).Value = categorie.Trim();
                c.Parameters.Add("quantite", OracleDbType.Int32).Value = quantite;
            });
        }
        public int ModifierProduit(int idProduit, string designation, string categorie, int quantite)
        {
            Verifier(designation, categorie, quantite);
            return Execute("UPDATE ProduitSuppression SET designation=:designation,categorie=:categorie,quantite=:quantite WHERE idproduit=:id", c =>
            {
                c.Parameters.Add("id", OracleDbType.Int32).Value = idProduit;
                c.Parameters.Add("designation", OracleDbType.Varchar2).Value = designation.Trim();
                c.Parameters.Add("categorie", OracleDbType.Varchar2).Value = categorie.Trim();
                c.Parameters.Add("quantite", OracleDbType.Int32).Value = quantite;
            });
        }
        // TRICK 14: the condition lives inside DELETE, so a concurrent stock change cannot bypass it.
        public DataSet GetProduitsEpuises()
        {
            return Query("SELECT * FROM ProduitSuppression WHERE quantite=0 ORDER BY categorie,designation");
        }
        public int SupprimerProduitSiStockNul(int idProduit)
        {
            return Execute("DELETE FROM ProduitSuppression WHERE idproduit=:id AND quantite=0", c => c.Parameters.Add("id", OracleDbType.Int32).Value = idProduit);
        }
        public int SupprimerProduitsEpuises()
        {
            return Execute("DELETE FROM ProduitSuppression WHERE quantite=0");
        }
        public int SupprimerProduitsEpuisesParCategorie(string categorie)
        {
            if (string.IsNullOrWhiteSpace(categorie)) throw new ArgumentException("Catégorie obligatoire.");
            return Execute("DELETE FROM ProduitSuppression WHERE UPPER(categorie)=UPPER(:categorie) AND quantite=0", c => c.Parameters.Add("categorie", OracleDbType.Varchar2).Value = categorie.Trim());
        }
    }
}
