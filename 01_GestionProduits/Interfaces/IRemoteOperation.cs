using System.Data;

namespace Interfaces
{
    // Shared contract: both Machine 1 and Machine 2 reference this assembly.
    public interface IRemoteOperation
    {
        string TesterConnexion(string nomClient);
        // ADAPTATION TP4: DataSet crosses Remoting by value and can contain 0..n rows.
        DataSet GetProduits();
        DataSet RechercherProduit(long codeBarre);
        int AjouterProduit(long codeBarre, string designation, int quantite, decimal prix);
        int ModifierProduit(long codeBarre, string designation, int quantite, decimal prix);
        int SupprimerProduit(long codeBarre);
    }
}
