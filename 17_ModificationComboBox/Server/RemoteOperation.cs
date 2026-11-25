using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Interfaces;

namespace Server
{
    public class RemoteOperation : MarshalByRefObject, IRemoteOperation
    {
        // MACHINE 2: configure the Oracle host, port, service and credentials here.
        private const string oradb = "Data Source=localhost:1522/XEPDB1; User Id=oracle; Password=manager;";
        public override object InitializeLifetimeService()
        {
            return null;
        }
        public string TesterConnexion(string n)
        {
            return "Bonjour " + n;
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
                    da.Fill(ds, "Enseignants");
                    return ds;
                }
            }
        }
        private int Execute(string sql, Action<OracleCommand> bind)
        {
            using (var c = new OracleConnection(oradb)) using (var cmd = new OracleCommand(sql, c))
            {
                cmd.BindByName = true;
                bind(cmd);
                c.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public DataSet GetEnseignants()
        {
            return Query("SELECT * FROM EnseignantSelection ORDER BY matricule");
        }
        // TRICK 17: || joins a label; the separate MATRICULE value identifies even duplicate names.
        public DataSet GetListeEnseignants()
        {
            return Query("SELECT matricule,nom || ' ' || prenom || ' (' || TO_CHAR(matricule) || ')' AS nom_complet FROM EnseignantSelection ORDER BY nom,prenom,matricule");
        }
        public DataSet RechercherEnseignant(int matricule)
        {
            return Query("SELECT * FROM EnseignantSelection WHERE matricule=:matricule", c => c.Parameters.Add("matricule", OracleDbType.Int32).Value = matricule);
        }
        private int Sauver(int m, string n, string p, string s, bool modifier)
        {
            if (string.IsNullOrWhiteSpace(n) || n.Trim().Length > 30 || string.IsNullOrWhiteSpace(p) || p.Trim().Length > 30 || (s != null && s.Trim().Length > 60)) throw new ArgumentException("Champs invalides.");
            string sql = modifier ? "UPDATE EnseignantSelection SET nom=:nom,prenom=:prenom,specialite=:specialite WHERE matricule=:matricule" : "INSERT INTO EnseignantSelection(matricule,nom,prenom,specialite) VALUES(:matricule,:nom,:prenom,:specialite)";
            return Execute(sql, c =>
            {
                c.Parameters.Add("matricule", OracleDbType.Int32).Value = m;
                c.Parameters.Add("nom", OracleDbType.Varchar2).Value = n.Trim();
                c.Parameters.Add("prenom", OracleDbType.Varchar2).Value = p.Trim();
                c.Parameters.Add("specialite", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(s) ? (object) DBNull.Value : s.Trim();
            });
        }
        public int AjouterEnseignant(int m, string n, string p, string s)
        {
            return Sauver(m, n, p, s, false);
        }
        public int ModifierEnseignant(int m, string n, string p, string s)
        {
            return Sauver(m, n, p, s, true);
        }
        public int SupprimerEnseignant(int m)
        {
            return Execute("DELETE FROM EnseignantSelection WHERE matricule=:matricule", c => c.Parameters.Add("matricule", OracleDbType.Int32).Value = m);
        }
    }
}
