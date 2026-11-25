using System;
using System.Data;

namespace Interfaces
{
    public interface IRemoteOperation
    {
        string TesterConnexion(string nomClient);
        // DateTime crosses Remoting by value; DataSet carries zero or more rows.
        DataSet GetReservations();
        DataSet RechercherReservation(int idReservation);
        // Return affected rows to distinguish a missing identifier.
        int AjouterReservation(int idReservation, string responsable, string salle, DateTime dateReservation);
        int ModifierReservation(int idReservation, string responsable, string salle, DateTime dateReservation);
        int SupprimerReservation(int idReservation);
        DataSet GetReservationsParDate(DateTime date);
        DataSet GetReservationsEntre(DateTime dateDebut, DateTime dateFin);
        DataSet GetReservationsFutures();
        DataSet GetReservationsAujourdhui();
    }
}
