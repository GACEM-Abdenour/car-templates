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
        public DataSet RechercherEmploye(int matricule)
        {
            return Query("SELECT * FROM Employe WHERE matricule=:matricule", "Employes", c => c.Parameters.Add("matricule", OracleDbType.Int32).Value = matricule);
        }
        // TRICK 07: DISTINCT prevents repeated ComboBox choices.
        public DataSet GetEmployes()
        {
            return Query("SELECT * FROM Employe ORDER BY matricule", "Employes");
        }
        public DataSet GetDepartements()
        {
            return Query("SELECT DISTINCT departement FROM Employe ORDER BY departement", "Departements");
        }
        public DataSet GetEmployesParDepartement(string d)
        {
            return Query("SELECT * FROM Employe WHERE departement=:departement", "Employes", x => x.Parameters.Add("departement", OracleDbType.Varchar2).Value = d);
        }
        private int Save(int m, string n, string p, string d, decimal s, bool u)
        {
            return Execute(u ? "UPDATE Employe SET nom=:nom,prenom=:prenom,departement=:departement,salaire=:salaire WHERE matricule=:matricule" : "INSERT INTO Employe VALUES(:matricule,:nom,:prenom,:departement,:salaire)", x =>
            {
                x.Parameters.Add("matricule", OracleDbType.Int32).Value = m;
                x.Parameters.Add("nom", OracleDbType.Varchar2).Value = n;
                x.Parameters.Add("prenom", OracleDbType.Varchar2).Value = p;
                x.Parameters.Add("departement", OracleDbType.Varchar2).Value = d;
                x.Parameters.Add("salaire", OracleDbType.Decimal).Value = s;
            });
        }
        public int AjouterEmploye(int m, string n, string p, string d, decimal s)
        {
            return Save(m, n, p, d, s, false);
        }
        public int ModifierEmploye(int m, string n, string p, string d, decimal s)
        {
            return Save(m, n, p, d, s, true);
        }
        public int SupprimerEmploye(int m)
        {
            return Execute("DELETE FROM Employe WHERE matricule=:m", x => x.Parameters.Add("m", OracleDbType.Int32).Value = m);
        }
    }
}
