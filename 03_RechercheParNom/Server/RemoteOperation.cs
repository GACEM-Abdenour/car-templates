using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Interfaces;

namespace Server
{
    public class RemoteOperation : MarshalByRefObject, IRemoteOperation
    {
        // MACHINE 2: change these Oracle values for the examination database.
        private const string oradb = "Data Source=localhost:1522/XEPDB1; User Id=oracle; Password=manager;";
        public override object InitializeLifetimeService()
        {
            return null;
        }
        public string TesterConnexion(string nomClient)
        {
            Console.WriteLine("Requete: " + nomClient);
            return "Bonjour " + nomClient + ", le serveur repond !";
        }
        private DataSet Query(string sql, string table, Action<OracleCommand> bind = null)
        {
            using (var c = new OracleConnection(oradb)) using (var cmd = new OracleCommand(sql, c))
            {
                cmd.BindByName = true;
                if (bind != null) bind(cmd);
                using (var da = new OracleDataAdapter(cmd))
                {
                    var ds = new DataSet();
                    da.Fill(ds, table);
                    return ds;
                }
            }
        }
        private int Execute(string sql, Action<OracleCommand> bind)
        {
            using (var c = new OracleConnection(oradb)) using (var cmd = new OracleCommand(sql, c))
            {
                c.Open();
                cmd.BindByName = true;
                bind(cmd);
                return cmd.ExecuteNonQuery();
            }
        }
        private object Scalar(string sql, Action<OracleCommand> bind = null)
        {
            using (var c = new OracleConnection(oradb)) using (var cmd = new OracleCommand(sql, c))
            {
                c.Open();
                cmd.BindByName = true;
                if (bind != null) bind(cmd);
                return cmd.ExecuteScalar();
            }
        }
        public DataSet GetEtudiants()
        {
            return Query("SELECT matricule,nom,prenom FROM EtudiantNom ORDER BY matricule", "Etudiants");
        }
        public DataSet RechercherEtudiant(int matricule)
        {
            return Query("SELECT matricule,nom,prenom FROM EtudiantNom WHERE matricule=:matricule", "Etudiants", x => x.Parameters.Add("matricule", OracleDbType.Int32).Value = matricule);
        }
        public int AjouterEtudiant(int matricule, string nom, string prenom)
        {
            return Execute("INSERT INTO EtudiantNom(matricule,nom,prenom) VALUES(:matricule,:nom,:prenom)", x =>
            {
                x.Parameters.Add("matricule", OracleDbType.Int32).Value = matricule;
                x.Parameters.Add("nom", OracleDbType.Varchar2).Value = nom;
                x.Parameters.Add("prenom", OracleDbType.Varchar2).Value = prenom;
            });
        }
        public int ModifierEtudiant(int matricule, string nom, string prenom)
        {
            return Execute("UPDATE EtudiantNom SET nom=:nom,prenom=:prenom WHERE matricule=:matricule", x =>
            {
                x.Parameters.Add("nom", OracleDbType.Varchar2).Value = nom;
                x.Parameters.Add("prenom", OracleDbType.Varchar2).Value = prenom;
                x.Parameters.Add("matricule", OracleDbType.Int32).Value = matricule;
            });
        }
        public int SupprimerEtudiant(int matricule)
        {
            return Execute("DELETE FROM EtudiantNom WHERE matricule=:matricule", x => x.Parameters.Add("matricule", OracleDbType.Int32).Value = matricule);
        }
        // TRICK 03: exact non-key search; DataSet may contain several students.
        public DataSet RechercherParNom(string nom)
        {
            return Query("SELECT * FROM EtudiantNom WHERE UPPER(nom)=UPPER(:nom)", "Etudiants", x => x.Parameters.Add("nom", OracleDbType.Varchar2).Value = nom);
        }
        public DataSet RechercherParPrenom(string prenom)
        {
            return Query("SELECT * FROM EtudiantNom WHERE UPPER(prenom)=UPPER(:prenom)", "Etudiants", x => x.Parameters.Add("prenom", OracleDbType.Varchar2).Value = prenom);
        }
    }
}
