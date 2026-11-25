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
            try
            {
                using (var c = new OracleConnection(oradb)) using (var cmd = new OracleCommand(sql, c))
                {
                    c.Open();
                    cmd.BindByName = true;
                    bind(cmd);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (OracleException ex)
            {
                if (ex.Number == 1) throw new InvalidOperationException("Identifiant ou DOI déjà utilisé.");
                throw;
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
        // TRICK 02: many text parameters; DBNull.Value keeps revue optional.
        public DataSet GetArticles()
        {
            return Query("SELECT * FROM ArticleScientifique ORDER BY idarticle", "Articles");
        }
        public DataSet RechercherArticle(int id)
        {
            return Query("SELECT * FROM ArticleScientifique WHERE idarticle=:id", "Articles", x => x.Parameters.Add("id", OracleDbType.Int32).Value = id);
        }
        public DataSet RechercherParDOI(string doi)
        {
            return Query("SELECT * FROM ArticleScientifique WHERE doi=:doi", "Articles", x => x.Parameters.Add("doi", OracleDbType.Varchar2).Value = doi);
        }
        public int AjouterArticle(int id, string t, string a, string r, int an, string doi)
        {
            return Sauver(id, t, a, r, an, doi, false);
        }
        public int ModifierArticle(int id, string t, string a, string r, int an, string doi)
        {
            return Sauver(id, t, a, r, an, doi, true);
        }
        private int Sauver(int id, string t, string a, string r, int an, string doi, bool update)
        {
            string q = update ? "UPDATE ArticleScientifique SET titre=:titre,auteur=:auteur,revue=:revue,anneepublication=:annee,doi=:doi WHERE idarticle=:id" : "INSERT INTO ArticleScientifique(idarticle,titre,auteur,revue,anneepublication,doi) VALUES(:id,:titre,:auteur,:revue,:annee,:doi)";
            return Execute(q, x =>
            {
                x.Parameters.Add("id", OracleDbType.Int32).Value = id;
                x.Parameters.Add("titre", OracleDbType.Varchar2).Value = t;
                x.Parameters.Add("auteur", OracleDbType.Varchar2).Value = a;
                x.Parameters.Add("revue", OracleDbType.Varchar2).Value = String.IsNullOrWhiteSpace(r) ? (object) DBNull.Value : r;
                x.Parameters.Add("annee", OracleDbType.Int32).Value = an;
                x.Parameters.Add("doi", OracleDbType.Varchar2).Value = doi;
            });
        }
        public int SupprimerArticle(int id)
        {
            return Execute("DELETE FROM ArticleScientifique WHERE idarticle=:id", x => x.Parameters.Add("id", OracleDbType.Int32).Value = id);
        }
    }
}
