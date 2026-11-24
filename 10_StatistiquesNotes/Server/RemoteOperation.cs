using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Interfaces;
namespace Server {
 public class RemoteOperation : MarshalByRefObject, IRemoteOperation {
  // MACHINE 2: change these Oracle values for the examination database.
  private const string oradb = "Data Source=localhost:1522/XEPDB1; User Id=oracle; Password=manager;";
  public override object InitializeLifetimeService() { return null; }
  public string TesterConnexion(string nomClient) { Console.WriteLine("Requete: " + nomClient); return "Bonjour " + nomClient + ", le serveur repond !"; }
  private DataSet Query(string sql, string table, Action<OracleCommand> bind = null) { using (var c=new OracleConnection(oradb)) using(var cmd=new OracleCommand(sql,c)) { cmd.BindByName=true; if(bind!=null) bind(cmd); using(var da=new OracleDataAdapter(cmd)) { var ds=new DataSet(); da.Fill(ds,table); return ds; } } }
  private int Execute(string sql, Action<OracleCommand> bind) { using(var c=new OracleConnection(oradb)) using(var cmd=new OracleCommand(sql,c)) { c.Open(); cmd.BindByName=true; bind(cmd); return cmd.ExecuteNonQuery(); } }
  private object Scalar(string sql, Action<OracleCommand> bind=null) { using(var c=new OracleConnection(oradb)) using(var cmd=new OracleCommand(sql,c)) { c.Open(); cmd.BindByName=true; if(bind!=null)bind(cmd); return cmd.ExecuteScalar(); } }
  // The grade constraint is checked on both server and Oracle, including remote callers.
  private static void Verifier(string nom,string prenom,decimal note) { if(string.IsNullOrWhiteSpace(nom)||nom.Length>30||string.IsNullOrWhiteSpace(prenom)||prenom.Length>30||note<0||note>20) throw new ArgumentException("Étudiant ou note invalide."); }
  public DataSet RechercherEtudiant(int matricule) { return Query("SELECT * FROM EtudiantStatistique WHERE matricule=:matricule","Etudiants",c=>c.Parameters.Add("matricule",OracleDbType.Int32).Value=matricule); }
  public int AjouterEtudiant(int matricule,string nom,string prenom,decimal note) { Verifier(nom,prenom,note); return Execute("INSERT INTO EtudiantStatistique(matricule,nom,prenom,note) VALUES(:matricule,:nom,:prenom,:note)",c=>{c.Parameters.Add("matricule",OracleDbType.Int32).Value=matricule;c.Parameters.Add("nom",OracleDbType.Varchar2).Value=nom;c.Parameters.Add("prenom",OracleDbType.Varchar2).Value=prenom;c.Parameters.Add("note",OracleDbType.Decimal).Value=note;}); }
  public int ModifierEtudiant(int matricule,string nom,string prenom,decimal note) { Verifier(nom,prenom,note); return Execute("UPDATE EtudiantStatistique SET nom=:nom,prenom=:prenom,note=:note WHERE matricule=:matricule",c=>{c.Parameters.Add("matricule",OracleDbType.Int32).Value=matricule;c.Parameters.Add("nom",OracleDbType.Varchar2).Value=nom;c.Parameters.Add("prenom",OracleDbType.Varchar2).Value=prenom;c.Parameters.Add("note",OracleDbType.Decimal).Value=note;}); }
  public int SupprimerEtudiant(int matricule) { return Execute("DELETE FROM EtudiantStatistique WHERE matricule=:matricule",c=>c.Parameters.Add("matricule",OracleDbType.Int32).Value=matricule); }
// TRICK 10 A: nullable decimal represents an undefined AVG/MIN/MAX for an empty table.
  public DataSet GetEtudiants(){return Query("SELECT * FROM EtudiantStatistique ORDER BY matricule","Etudiants");} private decimal? Grade(string q){object v=Scalar(q);return v==null||v==DBNull.Value?(decimal?)null:Convert.ToDecimal(v);} public decimal? CalculerMoyenne(){return Grade("SELECT AVG(note) FROM EtudiantStatistique");} public decimal? GetNoteMinimale(){return Grade("SELECT MIN(note) FROM EtudiantStatistique");} public decimal? GetNoteMaximale(){return Grade("SELECT MAX(note) FROM EtudiantStatistique");} public int CompterAdmis(){return Convert.ToInt32(Scalar("SELECT COUNT(*) FROM EtudiantStatistique WHERE note>=10"));} public int CompterAjournes(){return Convert.ToInt32(Scalar("SELECT COUNT(*) FROM EtudiantStatistique WHERE note<10"));}
  // TRICK 10 B: one DataSet row carries several aggregate columns in one remote call.
  public DataSet GetStatistiques(){return Query("SELECT COUNT(*) AS nombre_etudiants,ROUND(AVG(note),2) AS moyenne,MIN(note) AS note_minimale,MAX(note) AS note_maximale,COUNT(CASE WHEN note>=10 THEN 1 END) AS admis,COUNT(CASE WHEN note<10 THEN 1 END) AS ajournes FROM EtudiantStatistique","Statistiques");}
 }
}
