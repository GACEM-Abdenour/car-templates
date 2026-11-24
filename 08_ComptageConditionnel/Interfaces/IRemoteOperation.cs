using System.Data;
namespace Interfaces {
    // Shared contract: both Machine 1 and Machine 2 reference this assembly.
    public interface IRemoteOperation {
        string TesterConnexion(string nomClient);
        // ADAPTATION TP4: DataSet crosses Remoting by value and can contain 0..n rows.
        DataSet GetCours(); DataSet RechercherCours(int idCours);
        int AjouterCours(int idCours, string intitule, string enseignant, decimal volumeHoraire);
        int ModifierCours(int idCours, string intitule, string enseignant, decimal volumeHoraire);
        int SupprimerCours(int idCours);
        int CompterCours(); int CompterCoursPlusDe30Heures(); int CompterCoursParVolumeHoraire(decimal seuil); int CompterCoursParEnseignant(string enseignant);
    }
}
