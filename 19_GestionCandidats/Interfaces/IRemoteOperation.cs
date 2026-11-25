using System.Data;

namespace Interfaces
{
    public interface IRemoteOperation
    {
        string TesterConnexion(string nomClient);
        DataSet GetCandidats();
        DataSet RechercherCandidat(int idCandidat);
        // CRUD receives original grades, never a stored final grade or decision.
        int AjouterCandidat(int idCandidat, string nom, string prenom, decimal noteEcrit, decimal noteOral);
        int ModifierCandidat(int idCandidat, string nom, string prenom, decimal noteEcrit, decimal noteOral);
        int SupprimerCandidat(int idCandidat);
        DataSet GetCandidatsAvecResultats();
        DataSet GetCandidatsParDecision(string decision);
        DataSet GetAdmis();
        int CompterCandidatsParDecision(string decision);
    }
}
