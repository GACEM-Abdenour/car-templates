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
        // CRUD: parameters preserve apostrophes and ExecuteNonQuery returns affected rows.
        public DataSet RechercherCours(int idCours)
        {
            return Query("SELECT * FROM Cours WHERE idcours=:id", "Cours", c => c.Parameters.Add("id", OracleDbType.Int32).Value = idCours);
        }
        public int AjouterCours(int idCours, string intitule, string enseignant, decimal volumeHoraire)
        {
            VerifierCours(intitule, enseignant, volumeHoraire);
            return Execute("INSERT INTO Cours(idcours,intitule,enseignant,volumehoraire) VALUES(:id,:intitule,:enseignant,:volume)", c =>
            {
                c.Parameters.Add("id", OracleDbType.Int32).Value = idCours;
                c.Parameters.Add("intitule", OracleDbType.Varchar2).Value = intitule;
                c.Parameters.Add("enseignant", OracleDbType.Varchar2).Value = enseignant;
                c.Parameters.Add("volume", OracleDbType.Decimal).Value = volumeHoraire;
            });
        }
        public int ModifierCours(int idCours, string intitule, string enseignant, decimal volumeHoraire)
        {
            VerifierCours(intitule, enseignant, volumeHoraire);
            return Execute("UPDATE Cours SET intitule=:intitule,enseignant=:enseignant,volumehoraire=:volume WHERE idcours=:id", c =>
            {
                c.Parameters.Add("id", OracleDbType.Int32).Value = idCours;
                c.Parameters.Add("intitule", OracleDbType.Varchar2).Value = intitule;
                c.Parameters.Add("enseignant", OracleDbType.Varchar2).Value = enseignant;
                c.Parameters.Add("volume", OracleDbType.Decimal).Value = volumeHoraire;
            });
        }
        public int SupprimerCours(int idCours)
        {
            return Execute("DELETE FROM Cours WHERE idcours=:id", c => c.Parameters.Add("id", OracleDbType.Int32).Value = idCours);
        }
        private static void VerifierCours(string intitule, string enseignant, decimal volume)
        {
            if (string.IsNullOrWhiteSpace(intitule) || string.IsNullOrWhiteSpace(enseignant) || volume < 0) throw new ArgumentException("Cours invalide.");
        }
        // TRICK 08: ExecuteScalar asks Oracle to count; it does not download rows to the client.
        public DataSet GetCours()
        {
            return Query("SELECT * FROM Cours ORDER BY idcours", "Cours");
        }
        private int Count(string q, Action<OracleCommand> b = null)
        {
            object v = Scalar(q, b);
            return v == null || v == DBNull.Value ? 0 : Convert.ToInt32(v);
        }
        public int CompterCours()
        {
            return Count("SELECT COUNT(*) FROM Cours");
        }
        public int CompterCoursPlusDe30Heures()
        {
            return Count("SELECT COUNT(*) FROM Cours WHERE volumehoraire>30");
        }
        public int CompterCoursParVolumeHoraire(decimal s)
        {
            return Count("SELECT COUNT(*) FROM Cours WHERE volumehoraire>:seuil", x => x.Parameters.Add("seuil", OracleDbType.Decimal).Value = s);
        }
        public int CompterCoursParEnseignant(string e)
        {
            return Count("SELECT COUNT(*) FROM Cours WHERE UPPER(enseignant)=UPPER(:enseignant)", x => x.Parameters.Add("enseignant", OracleDbType.Varchar2).Value = e);
        }
    }
}
