using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Interfaces;

namespace Server
{
    public class RemoteOperation : MarshalByRefObject, IRemoteOperation
    {
        // MACHINE 2: configure Oracle host, port, service and credentials.
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
                        da.Fill(ds, "Candidats");
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
        private static void Verifier(string nom, string prenom, decimal ecrit, decimal oral)
        {
            if (string.IsNullOrWhiteSpace(nom) || nom.Trim().Length > 30 || string.IsNullOrWhiteSpace(prenom) || prenom.Trim().Length > 30 || ecrit < 0 || ecrit > 20 || oral < 0 || oral > 20) throw new ArgumentException("Candidat ou note invalide.");
        }
        private static string Decision(string d)
        {
            if (d != "ADMIS" && d != "ADMIS AVEC MENTION" && d != "AJOURNE" && d != "ELIMINE") throw new ArgumentException("Décision invalide.");
            return d;
        }
        public DataSet GetCandidats()
        {
            return Query("SELECT * FROM Candidat ORDER BY idcandidat");
        }
        public DataSet RechercherCandidat(int idCandidat)
        {
            return Query("SELECT * FROM Candidat WHERE idcandidat=:id", c => c.Parameters.Add("id", OracleDbType.Int32).Value = idCandidat);
        }
        private int Sauver(int id, string nom, string prenom, decimal ecrit, decimal oral, bool modifier)
        {
            Verifier(nom, prenom, ecrit, oral);
            return Execute(modifier ? "UPDATE Candidat SET nom=:nom,prenom=:prenom,noteecrit=:ecrit,noteoral=:oral WHERE idcandidat=:id" : "INSERT INTO Candidat(idcandidat,nom,prenom,noteecrit,noteoral) VALUES(:id,:nom,:prenom,:ecrit,:oral)", c =>
            {
                c.Parameters.Add("id", OracleDbType.Int32).Value = id;
                c.Parameters.Add("nom", OracleDbType.Varchar2).Value = nom.Trim();
                c.Parameters.Add("prenom", OracleDbType.Varchar2).Value = prenom.Trim();
                c.Parameters.Add("ecrit", OracleDbType.Decimal).Value = ecrit;
                c.Parameters.Add("oral", OracleDbType.Decimal).Value = oral;
            });
        }
        public int AjouterCandidat(int idCandidat, string nom, string prenom, decimal noteEcrit, decimal noteOral)
        {
            return Sauver(idCandidat, nom, prenom, noteEcrit, noteOral, false);
        }
        public int ModifierCandidat(int idCandidat, string nom, string prenom, decimal noteEcrit, decimal noteOral)
        {
            return Sauver(idCandidat, nom, prenom, noteEcrit, noteOral, true);
        }
        public int SupprimerCandidat(int idCandidat)
        {
            return Execute("DELETE FROM Candidat WHERE idcandidat=:id", c => c.Parameters.Add("id", OracleDbType.Int32).Value = idCandidat);
        }
        // TRICK 19: CASE order is essential: elimination first, mention before admission.
        // Classification uses unrounded weighted grades; ROUND is only for display.
        private const string Resultats = "SELECT idcandidat,nom,prenom,noteecrit,noteoral,ROUND(noteecrit*0.6+noteoral*0.4,2) AS note_finale,CASE WHEN noteecrit<5 OR noteoral<5 THEN 'ELIMINE' WHEN noteecrit*0.6+noteoral*0.4>=16 THEN 'ADMIS AVEC MENTION' WHEN noteecrit*0.6+noteoral*0.4>=10 THEN 'ADMIS' ELSE 'AJOURNE' END AS decision FROM Candidat";
        public DataSet GetCandidatsAvecResultats()
        {
            return Query(Resultats + " ORDER BY note_finale DESC,idcandidat");
        }
        // An outer SELECT filters the computed alias, unavailable to WHERE at the same level.
        public DataSet GetCandidatsParDecision(string decision)
        {
            return Query("SELECT * FROM (" + Resultats + ") WHERE decision=:decision ORDER BY note_finale DESC,idcandidat", c => c.Parameters.Add("decision", OracleDbType.Varchar2).Value = Decision(decision));
        }
        public DataSet GetAdmis()
        {
            return Query("SELECT * FROM (" + Resultats + ") WHERE decision IN ('ADMIS','ADMIS AVEC MENTION') ORDER BY note_finale DESC,idcandidat");
        }
        public int CompterCandidatsParDecision(string decision)
        {
            try
            {
                using (var c = new OracleConnection(oradb)) using (var cmd = new OracleCommand("SELECT COUNT(*) FROM (" + Resultats + ") WHERE decision=:decision", c))
                {
                    cmd.BindByName = true;
                    cmd.Parameters.Add("decision", OracleDbType.Varchar2).Value = Decision(decision);
                    c.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (OracleException e)
            {
                Console.Error.WriteLine(e.Message);
                throw new InvalidOperationException("Erreur de base de données.");
            }
        }
    }
}
