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
  // TRICK 09: NUMBER monetary values use decimal. Bind values instead of concatenating input.
  public DataSet RechercherVente(int idVente) { return Query("SELECT idvente,produit,quantite,prixunitaire,quantite*prixunitaire AS montant FROM Vente WHERE idvente=:id", "Ventes", c=>c.Parameters.Add("id",OracleDbType.Int32).Value=idVente); }
  private static void VerifierVente(string produit,int quantite,decimal prix) { if(string.IsNullOrWhiteSpace(produit)||produit.Length>60||quantite<=0||quantite>999999||prix<0||prix>9999999999.99m) throw new ArgumentException("Vente invalide."); }
  public int AjouterVente(int idVente,string produit,int quantite,decimal prixUnitaire) { VerifierVente(produit,quantite,prixUnitaire); return Execute("INSERT INTO Vente(idvente,produit,quantite,prixunitaire) VALUES(:id,:produit,:quantite,:prix)", c=>{c.Parameters.Add("id",OracleDbType.Int32).Value=idVente;c.Parameters.Add("produit",OracleDbType.Varchar2).Value=produit;c.Parameters.Add("quantite",OracleDbType.Int32).Value=quantite;c.Parameters.Add("prix",OracleDbType.Decimal).Value=prixUnitaire;}); }
  public int ModifierVente(int idVente,string produit,int quantite,decimal prixUnitaire) { VerifierVente(produit,quantite,prixUnitaire); return Execute("UPDATE Vente SET produit=:produit,quantite=:quantite,prixunitaire=:prix WHERE idvente=:id", c=>{c.Parameters.Add("id",OracleDbType.Int32).Value=idVente;c.Parameters.Add("produit",OracleDbType.Varchar2).Value=produit;c.Parameters.Add("quantite",OracleDbType.Int32).Value=quantite;c.Parameters.Add("prix",OracleDbType.Decimal).Value=prixUnitaire;}); }
  public int SupprimerVente(int idVente) { return Execute("DELETE FROM Vente WHERE idvente=:id",c=>c.Parameters.Add("id",OracleDbType.Int32).Value=idVente); }
// TRICK 09: montant is calculated, never stored, to avoid inconsistent data.
  public DataSet GetVentes(){return Query("SELECT idvente,produit,quantite,prixunitaire,quantite*prixunitaire AS montant FROM Vente ORDER BY idvente","Ventes");} private decimal Money(string q,Action<OracleCommand> b=null){object v=Scalar(q,b);return v==null||v==DBNull.Value?0m:Convert.ToDecimal(v);} public decimal CalculerChiffreAffaires(){return Money("SELECT NVL(SUM(quantite*prixunitaire),0) FROM Vente");} public decimal CalculerChiffreAffairesParProduit(string p){return Money("SELECT NVL(SUM(quantite*prixunitaire),0) FROM Vente WHERE UPPER(produit)=UPPER(:produit)",x=>x.Parameters.Add("produit",OracleDbType.Varchar2).Value=p);} public int CalculerQuantiteTotale(){return Convert.ToInt32(Scalar("SELECT NVL(SUM(quantite),0) FROM Vente"));}
 }
}
