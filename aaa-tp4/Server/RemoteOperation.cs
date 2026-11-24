using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Interfaces;

namespace Server
{
    public class RemoteOperation : MarshalByRefObject, IRemoteOperation
    {
        private string oradb = "Data Source=localhost:1522/XEPDB1; User Id=oracle; Password=manager;";

        public override object InitializeLifetimeService()
        {
            return null;
        }

        public string TesterConnexion(string nomClient)
        {
            Console.WriteLine("Requete recue de : " + nomClient);
            return "Bonjour " + nomClient + ", le serveur repond !";
        }

        // SELECT ALL (from TP4 Ado-Exemple2 & 5)
        public DataSet GetEtudiants()
        {
            Console.WriteLine("Appel client : GetEtudiants()");
            DataSet ds = new DataSet();
            using (OracleConnection conn = new OracleConnection(oradb))
            {
                conn.Open();
                string sql = "SELECT matricule, nom, prenom FROM Etudiant ORDER BY matricule";
                OracleDataAdapter da = new OracleDataAdapter(sql, conn);
                da.Fill(ds, "Etudiant");
            }
            return ds;
        }

        // SEARCH (from TP4 Ado-Exemple5)
        public DataSet RechercherEtudiant(int matricule)
        {
            Console.WriteLine("Appel client : RechercherEtudiant(" + matricule + ")");
            DataSet ds = new DataSet();
            using (OracleConnection conn = new OracleConnection(oradb))
            {
                conn.Open();
                string sql = "SELECT matricule, nom, prenom FROM Etudiant WHERE matricule = " + matricule;
                OracleDataAdapter da = new OracleDataAdapter(sql, conn);
                da.Fill(ds, "Etudiant");
            }
            return ds;
        }

        // INSERT (from TP4 Ado-Exemple1 & 3)
        public int AjouterEtudiant(int matricule, string nom, string prenom)
        {
            Console.WriteLine("Appel client : AjouterEtudiant(" + matricule + ", " + nom + ", " + prenom + ")");
            using (OracleConnection conn = new OracleConnection(oradb))
            {
                conn.Open();
                string sql = "INSERT INTO Etudiant VALUES(" + matricule + ", '" + nom + "', '" + prenom + "')";
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                return cmd.ExecuteNonQuery();
            }
        }

        // UPDATE (from TP4 Ado-Exemple5)
        public int ModifierEtudiant(int matricule, string nom, string prenom)
        {
            Console.WriteLine("Appel client : ModifierEtudiant(" + matricule + ", " + nom + ", " + prenom + ")");
            using (OracleConnection conn = new OracleConnection(oradb))
            {
                conn.Open();
                string sql = "UPDATE Etudiant SET nom = '" + nom + "', prenom = '" + prenom + "' WHERE matricule = " + matricule;
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                return cmd.ExecuteNonQuery();
            }
        }

        // DELETE (from TP4 Ado-Exemple4)
        public int SupprimerEtudiant(int matricule)
        {
            Console.WriteLine("Appel client : SupprimerEtudiant(" + matricule + ")");
            using (OracleConnection conn = new OracleConnection(oradb))
            {
                conn.Open();
                string sql = "DELETE FROM Etudiant WHERE matricule = " + matricule;
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                return cmd.ExecuteNonQuery();
            }
        }
    }
}