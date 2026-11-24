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
// ======================================================
  // TRICK 01: CRUD with a 10-digit long and monetary decimal.
  // ======================================================
  public DataSet GetProduits(){ return Query("SELECT codebarre,designation,quantite,prix FROM Produit ORDER BY codebarre","Produit"); }
  public DataSet RechercherProduit(long codeBarre){ return Query("SELECT * FROM Produit WHERE codebarre=:codebarre","Produit",x=>x.Parameters.Add("codebarre",OracleDbType.Int64).Value=codeBarre); }
  public int AjouterProduit(long codeBarre,string designation,int quantite,decimal prix){ if(quantite<0||prix<0) throw new ArgumentException("Quantite et prix doivent etre positifs."); return Execute("INSERT INTO Produit(codebarre,designation,quantite,prix) VALUES(:codebarre,:designation,:quantite,:prix)",x=>{x.Parameters.Add("codebarre",OracleDbType.Int64).Value=codeBarre;x.Parameters.Add("designation",OracleDbType.Varchar2).Value=designation;x.Parameters.Add("quantite",OracleDbType.Int32).Value=quantite;x.Parameters.Add("prix",OracleDbType.Decimal).Value=prix;}); }
  public int ModifierProduit(long codeBarre,string designation,int quantite,decimal prix){ if(quantite<0||prix<0) throw new ArgumentException("Valeur negative."); return Execute("UPDATE Produit SET designation=:designation,quantite=:quantite,prix=:prix WHERE codebarre=:codebarre",x=>{x.Parameters.Add("designation",OracleDbType.Varchar2).Value=designation;x.Parameters.Add("quantite",OracleDbType.Int32).Value=quantite;x.Parameters.Add("prix",OracleDbType.Decimal).Value=prix;x.Parameters.Add("codebarre",OracleDbType.Int64).Value=codeBarre;}); }
  public int SupprimerProduit(long codeBarre){return Execute("DELETE FROM Produit WHERE codebarre=:codebarre",x=>x.Parameters.Add("codebarre",OracleDbType.Int64).Value=codeBarre);}
 }
}
