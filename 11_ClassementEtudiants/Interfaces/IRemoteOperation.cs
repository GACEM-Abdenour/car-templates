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
        int AjouterEtudiant(int matricule, string nom, string prenom, decimal note);
        int ModifierEtudiant(int matricule, string nom, string prenom, decimal note);
        int SupprimerEtudiant(int matricule);
        // TRICK 11: DataSet carries any number of ordered rows across Remoting.
        DataSet TrierParNom();
        DataSet TrierParNoteCroissante();
        DataSet TrierParNoteDecroissante();
        // Positive N selects at most N rows; rank returns a calculated column.
        DataSet GetMeilleursEtudiants(int nombre);
        DataSet GetClassement();
    }
}
