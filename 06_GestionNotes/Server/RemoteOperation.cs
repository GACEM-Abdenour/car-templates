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
            return Query("SELECT matricule,nom,prenom,note FROM EtudiantNote ORDER BY matricule", "Etudiants");
        }
        public DataSet RechercherEtudiant(int matricule)
        {
            return Query("SELECT matricule,nom,prenom,note FROM EtudiantNote WHERE matricule=:matricule", "Etudiants", x => x.Parameters.Add("matricule", OracleDbType.Int32).Value = matricule);
        }
        public int AjouterEtudiant(int matricule, string nom, string prenom, decimal note)
        {
            VerifierNote(note);
            return Execute("INSERT INTO EtudiantNote(matricule,nom,prenom,note) VALUES(:matricule,:nom,:prenom,:note)", x =>
            {
                x.Parameters.Add("matricule", OracleDbType.Int32).Value = matricule;
                x.Parameters.Add("nom", OracleDbType.Varchar2).Value = nom;
                x.Parameters.Add("prenom", OracleDbType.Varchar2).Value = prenom;
                x.Parameters.Add("note", OracleDbType.Decimal).Value = note;
            });
        }
        public int ModifierEtudiant(int matricule, string nom, string prenom, decimal note)
        {
            VerifierNote(note);
            return Execute("UPDATE EtudiantNote SET nom=:nom,prenom=:prenom,note=:note WHERE matricule=:matricule", x =>
            {
                x.Parameters.Add("nom", OracleDbType.Varchar2).Value = nom;
                x.Parameters.Add("prenom", OracleDbType.Varchar2).Value = prenom;
                x.Parameters.Add("note", OracleDbType.Decimal).Value = note;
                x.Parameters.Add("matricule", OracleDbType.Int32).Value = matricule;
            });
        }
        public int SupprimerEtudiant(int matricule)
        {
            return Execute("DELETE FROM EtudiantNote WHERE matricule=:matricule", x => x.Parameters.Add("matricule", OracleDbType.Int32).Value = matricule);
        }
        private static void VerifierNote(decimal note)
        {
            if (note < 0 || note > 20) throw new ArgumentException("Note invalide : 0 a 20.");
        }
        // TRICK 06: both Server validation and the Oracle CHECK constraint protect 0..20.
        public DataSet GetAdmis()
        {
            return Query("SELECT * FROM EtudiantNote WHERE note>=10", "Etudiants");
        }
        public DataSet GetAjournes()
        {
            return Query("SELECT * FROM EtudiantNote WHERE note<10", "Etudiants");
        }
        public DataSet RechercherNoteMin(decimal n)
        {
            if (n < 0 || n > 20) throw new ArgumentException("Note invalide.");
            return Query("SELECT * FROM EtudiantNote WHERE note>=:noteMin", "Etudiants", x => x.Parameters.Add("noteMin", OracleDbType.Decimal).Value = n);
        }
        public DataSet RechercherNotesEntre(decimal a, decimal b)
        {
            if (a < 0 || b > 20 || a > b) throw new ArgumentException("Intervalle invalide.");
            return Query("SELECT * FROM EtudiantNote WHERE note BETWEEN :min AND :max", "Etudiants", x =>
            {
                x.Parameters.Add("min", OracleDbType.Decimal).Value = a;
                x.Parameters.Add("max", OracleDbType.Decimal).Value = b;
            });
        }
    }
}
