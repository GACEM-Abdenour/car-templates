using System.Data;

namespace Interfaces
{
    // Shared contract: both Machine 1 and Machine 2 reference this assembly.
    public interface IRemoteOperation
    {
        string TesterConnexion(string nomClient);
        // ADAPTATION TP4: DataSet crosses Remoting by value and can contain 0..n rows.
        DataSet GetEtudiants();
        DataSet RechercherEtudiant(int matricule);
        int AjouterEtudiant(int matricule, string nom, string prenom, string groupe);
        int ModifierEtudiant(int matricule, string nom, string prenom, string groupe);
        int SupprimerEtudiant(int matricule);
        DataSet RechercherEtudiants(string nom, string prenom, string groupe);
        DataSet RechercherNomOuPrenom(string motCle);
    }
}
