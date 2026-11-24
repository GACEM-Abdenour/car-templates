using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Interfaces;
namespace Server {
 public class RemoteOperation : MarshalByRefObject, IRemoteOperation {
  // MACHINE 2: replace host, port, service and credentials for the exam database.
  private const string oradb="Data Source=localhost:1522/XEPDB1; User Id=oracle; Password=manager;";
  public override object InitializeLifetimeService(){return null;}
  public string TesterConnexion(string nomClient){return "Bonjour "+nomClient;}
  private DataSet Query(string sql,Action<OracleCommand> bind=null){using(var c=new OracleConnection(oradb))using(var cmd=new OracleCommand(sql,c)){cmd.BindByName=true;if(bind!=null)bind(cmd);using(var da=new OracleDataAdapter(cmd)){var ds=new DataSet();da.Fill(ds,"Reservations");return ds;}}}
  private int Execute(string sql,Action<OracleCommand> bind){using(var c=new OracleConnection(oradb))using(var cmd=new OracleCommand(sql,c)){cmd.BindByName=true;bind(cmd);c.Open();return cmd.ExecuteNonQuery();}}
  private static void Verifier(string responsable,string salle){if(string.IsNullOrWhiteSpace(responsable)||responsable.Length>60||string.IsNullOrWhiteSpace(salle)||salle.Length>30)throw new ArgumentException("Responsable ou salle invalide.");}
  public DataSet GetReservations(){return Query("SELECT * FROM Reservation ORDER BY datereservation,idreservation");}
  public DataSet RechercherReservation(int idReservation){return Query("SELECT * FROM Reservation WHERE idreservation=:id",c=>c.Parameters.Add("id",OracleDbType.Int32).Value=idReservation);}
  // TRICK 12: Oracle DATE includes time; bind DateTime directly, never concatenate formatted dates.
  public int AjouterReservation(int idReservation,string responsable,string salle,DateTime dateReservation){Verifier(responsable,salle);return Execute("INSERT INTO Reservation(idreservation,responsable,salle,datereservation) VALUES(:id,:responsable,:salle,:dateReservation)",c=>{c.Parameters.Add("id",OracleDbType.Int32).Value=idReservation;c.Parameters.Add("responsable",OracleDbType.Varchar2).Value=responsable;c.Parameters.Add("salle",OracleDbType.Varchar2).Value=salle;c.Parameters.Add("dateReservation",OracleDbType.Date).Value=dateReservation;});}
  public int ModifierReservation(int idReservation,string responsable,string salle,DateTime dateReservation){Verifier(responsable,salle);return Execute("UPDATE Reservation SET responsable=:responsable,salle=:salle,datereservation=:dateReservation WHERE idreservation=:id",c=>{c.Parameters.Add("id",OracleDbType.Int32).Value=idReservation;c.Parameters.Add("responsable",OracleDbType.Varchar2).Value=responsable;c.Parameters.Add("salle",OracleDbType.Varchar2).Value=salle;c.Parameters.Add("dateReservation",OracleDbType.Date).Value=dateReservation;});}
  public int SupprimerReservation(int idReservation){return Execute("DELETE FROM Reservation WHERE idreservation=:id",c=>c.Parameters.Add("id",OracleDbType.Int32).Value=idReservation);}
  // Inclusive start, exclusive next midnight: include all times on the final day.
  public DataSet GetReservationsParDate(DateTime date){return GetReservationsEntre(date,date);}
  public DataSet GetReservationsEntre(DateTime dateDebut,DateTime dateFin){if(dateDebut.Date>dateFin.Date||dateFin.Date==DateTime.MaxValue.Date)throw new ArgumentException("Intervalle de dates invalide.");return Query("SELECT * FROM Reservation WHERE datereservation>=:debut AND datereservation<:fin ORDER BY datereservation",c=>{c.Parameters.Add("debut",OracleDbType.Date).Value=dateDebut.Date;c.Parameters.Add("fin",OracleDbType.Date).Value=dateFin.Date.AddDays(1);});}
  // SYSDATE is the database server clock. TRUNC removes its time component.
  public DataSet GetReservationsFutures(){return Query("SELECT * FROM Reservation WHERE datereservation>SYSDATE ORDER BY datereservation");}
  // Alternative TRUNC(datereservation)=TRUNC(SYSDATE) can prevent ordinary index use.
  public DataSet GetReservationsAujourdhui(){return Query("SELECT * FROM Reservation WHERE datereservation>=TRUNC(SYSDATE) AND datereservation<TRUNC(SYSDATE)+1 ORDER BY datereservation");}
 }
}
