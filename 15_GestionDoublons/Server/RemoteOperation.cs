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
        public string TesterConnexion(string nomClient)
        {
            return "Bonjour " + nomClient;
        }
        // Never send OracleException (or its inner exception) to a client without the Oracle DLL.
        private static InvalidOperationException Erreur(OracleException ex)
        {
            Console.Error.WriteLine("Oracle error " + ex.Number + ": " + ex.Message);
            return new InvalidOperationException(ex.Number == 1 ? "Matricule ou adresse électronique déjà utilisé(e)." : "Erreur de base de données sur le serveur.");
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
                        da.Fill(ds, "Etudiants");
                        return ds;
                    }
                }
            }
            catch (OracleException ex)
            {
                throw Erreur(ex);
            }
        }
        private int Scalar(string sql, Action<OracleCommand> bind)
        {
            try
            {
                using (var c = new OracleConnection(oradb)) using (var cmd = new OracleCommand(sql, c))
                {
                    cmd.BindByName = true;
                    bind(cmd);
                    c.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (OracleException ex)
            {
                throw Erreur(ex);
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
            catch (OracleException ex)
            {
                throw Erreur(ex);
            }
        }
        // Exercise convention: emails are trimmed and lowercased. Validate ASCII here so Oracle LOWER and invariant lowercase agree.
        private static string Email(string email)
        {
            string v = (email ?? "").Trim().ToLowerInvariant();
            int at = v.IndexOf('@');
            if (v.Length > 100 || at <= 0 || at != v.LastIndexOf('@') || at == v.Length - 1 || v.IndexOf(' ') >= 0) throw new ArgumentException("Adresse électronique invalide.");
            foreach (char ch in v) if (ch < 33 || ch > 126) throw new ArgumentException("Adresse électronique ASCII requise.");
            return v;
        }
        private static void Nom(string v)
        {
            if (string.IsNullOrWhiteSpace(v) || v.Trim().Length > 30) throw new ArgumentException("Nom ou prénom invalide.");
        }
        public DataSet GetEtudiants()
        {
            return Query("SELECT * FROM EtudiantInscription ORDER BY matricule");
        }
        public DataSet RechercherEtudiant(int matricule)
        {
            return Query("SELECT * FROM EtudiantInscription WHERE matricule=:matricule", c => c.Parameters.Add("matricule", OracleDbType.Int32).Value = matricule);
        }
        public DataSet RechercherParEmail(string email)
        {
            string v = Email(email);
            return Query("SELECT * FROM EtudiantInscription WHERE email=:email", c => c.Parameters.Add("email", OracleDbType.Varchar2).Value = v);
        }
        // TRICK 15: COUNT returns one number; ExecuteScalar and >0 turn it into a .NET bool.
        public bool EtudiantExiste(int matricule)
        {
            return Scalar("SELECT COUNT(*) FROM EtudiantInscription WHERE matricule=:matricule", c => c.Parameters.Add("matricule", OracleDbType.Int32).Value = matricule) > 0;
        }
        // EXISTS only needs SELECT 1; CASE returns 1/0 from Oracle's dual table.
        public bool EmailExiste(string email)
        {
            string v = Email(email);
            return Scalar("SELECT CASE WHEN EXISTS (SELECT 1 FROM EtudiantInscription WHERE email=:email) THEN 1 ELSE 0 END FROM dual", c => c.Parameters.Add("email", OracleDbType.Varchar2).Value = v) > 0;
        }
        // Exclude the current primary key, so retaining one's own email is allowed.
        public bool EmailUtiliseParAutreEtudiant(int matricule, string email)
        {
            string v = Email(email);
            return Scalar("SELECT COUNT(*) FROM EtudiantInscription WHERE email=:email AND matricule<>:matricule", c =>
            {
                c.Parameters.Add("email", OracleDbType.Varchar2).Value = v;
                c.Parameters.Add("matricule", OracleDbType.Int32).Value = matricule;
            }) > 0;
        }
        // Concurrent clients may both pass a preliminary check: PRIMARY KEY and UNIQUE are authoritative.
        private int Sauver(int m, string n, string p, string email, bool update)
        {
            Nom(n);
            Nom(p);
            string v = Email(email);
            string sql = update ? "UPDATE EtudiantInscription SET nom=:nom,prenom=:prenom,email=:email WHERE matricule=:matricule" : "INSERT INTO EtudiantInscription(matricule,nom,prenom,email) VALUES(:matricule,:nom,:prenom,:email)";
            return Execute(sql, c =>
            {
                c.Parameters.Add("matricule", OracleDbType.Int32).Value = m;
                c.Parameters.Add("nom", OracleDbType.Varchar2).Value = n.Trim();
                c.Parameters.Add("prenom", OracleDbType.Varchar2).Value = p.Trim();
                c.Parameters.Add("email", OracleDbType.Varchar2).Value = v;
            });
        }
        public int AjouterEtudiant(int matricule, string nom, string prenom, string email)
        {
            return Sauver(matricule, nom, prenom, email, false);
        }
        public int ModifierEtudiant(int matricule, string nom, string prenom, string email)
        {
            return Sauver(matricule, nom, prenom, email, true);
        }
        public int SupprimerEtudiant(int matricule)
        {
            return Execute("DELETE FROM EtudiantInscription WHERE matricule=:matricule", c => c.Parameters.Add("matricule", OracleDbType.Int32).Value = matricule);
        }
    }
}
