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
public DataSet GetEtudiants(){return Query("SELECT matricule,nom,prenom,note FROM EtudiantClassement ORDER BY matricule","Etudiants");} public DataSet RechercherEtudiant(int matricule){return Query("SELECT matricule,nom,prenom,note FROM EtudiantClassement WHERE matricule=:matricule","Etudiants",x=>x.Parameters.Add("matricule",OracleDbType.Int32).Value=matricule);} public int AjouterEtudiant(int matricule,string nom,string prenom,decimal note){VerifierNote(note);return Execute("INSERT INTO EtudiantClassement(matricule,nom,prenom,note) VALUES(:matricule,:nom,:prenom,:note)",x=>{x.Parameters.Add("matricule",OracleDbType.Int32).Value=matricule;x.Parameters.Add("nom",OracleDbType.Varchar2).Value=nom;x.Parameters.Add("prenom",OracleDbType.Varchar2).Value=prenom;x.Parameters.Add("note",OracleDbType.Decimal).Value=note;});} public int ModifierEtudiant(int matricule,string nom,string prenom,decimal note){VerifierNote(note);return Execute("UPDATE EtudiantClassement SET nom=:nom,prenom=:prenom,note=:note WHERE matricule=:matricule",x=>{x.Parameters.Add("nom",OracleDbType.Varchar2).Value=nom;x.Parameters.Add("prenom",OracleDbType.Varchar2).Value=prenom;x.Parameters.Add("note",OracleDbType.Decimal).Value=note;x.Parameters.Add("matricule",OracleDbType.Int32).Value=matricule;});} public int SupprimerEtudiant(int matricule){return Execute("DELETE FROM EtudiantClassement WHERE matricule=:matricule",x=>x.Parameters.Add("matricule",OracleDbType.Int32).Value=matricule);}
  private static void VerifierNote(decimal note) { if (note < 0 || note > 20) throw new ArgumentException("Note invalide : 0 a 20."); }
  // TRICK 11: ASC and DESC sort by name or grade. Matricule resolves ties deterministically.
  public DataSet TrierParNom(){return Query("SELECT * FROM EtudiantClassement ORDER BY nom ASC, prenom ASC, matricule ASC","Etudiants");}
  public DataSet TrierParNoteCroissante(){return Query("SELECT * FROM EtudiantClassement ORDER BY note ASC, matricule ASC","Etudiants");}
  public DataSet TrierParNoteDecroissante(){return Query("SELECT * FROM EtudiantClassement ORDER BY note DESC, matricule ASC","Etudiants");}
  // Apply ROWNUM after the inner ORDER BY: otherwise Oracle may select the wrong rows.
  public DataSet GetMeilleursEtudiants(int nombre){if(nombre<=0)throw new ArgumentException("Nombre positif requis.");return Query("SELECT * FROM (SELECT * FROM EtudiantClassement ORDER BY note DESC, matricule ASC) WHERE ROWNUM <= :nombre ORDER BY note DESC, matricule ASC","Etudiants",x=>x.Parameters.Add("nombre",OracleDbType.Int32).Value=nombre);}
  // RANK shares ties and leaves gaps. Do not include matricule inside OVER: it would break ties.
  // Alternatives: DENSE_RANK() OVER (ORDER BY note DESC) removes gaps;
  // ROW_NUMBER() OVER (ORDER BY note DESC, matricule) gives every row a unique position.
  public DataSet GetClassement(){return Query("SELECT matricule,nom,prenom,note,RANK() OVER (ORDER BY note DESC) AS rang FROM EtudiantClassement ORDER BY rang,matricule","Etudiants");}
  // TRICK 06: both Server validation and the Oracle CHECK constraint protect 0..20.
  public DataSet GetAdmis(){return Query("SELECT * FROM EtudiantClassement WHERE note>=10","Etudiants");} public DataSet GetAjournes(){return Query("SELECT * FROM EtudiantClassement WHERE note<10","Etudiants");} public DataSet RechercherNoteMin(decimal n){if(n<0||n>20)throw new ArgumentException("Note invalide.");return Query("SELECT * FROM EtudiantClassement WHERE note>=:noteMin","Etudiants",x=>x.Parameters.Add("noteMin",OracleDbType.Decimal).Value=n);} public DataSet RechercherNotesEntre(decimal a,decimal b){if(a<0||b>20||a>b)throw new ArgumentException("Intervalle invalide.");return Query("SELECT * FROM EtudiantClassement WHERE note BETWEEN :min AND :max","Etudiants",x=>{x.Parameters.Add("min",OracleDbType.Decimal).Value=a;x.Parameters.Add("max",OracleDbType.Decimal).Value=b;});}
 }
}
