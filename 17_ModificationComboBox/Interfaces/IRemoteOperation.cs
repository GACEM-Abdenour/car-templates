using System.Data;

namespace Interfaces
{
    public interface IRemoteOperation
    {
        string TesterConnexion(string nomClient);
        // Full records, display list, and a single record respectively.
        DataSet GetEnseignants();
        DataSet GetListeEnseignants();
        DataSet RechercherEnseignant(int matricule);
        int AjouterEnseignant(int matricule, string nom, string prenom, string specialite);
        int ModifierEnseignant(int matricule, string nom, string prenom, string specialite);
        int SupprimerEnseignant(int matricule);
    }
}
