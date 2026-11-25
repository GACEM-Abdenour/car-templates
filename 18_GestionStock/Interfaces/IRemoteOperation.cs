using System.Data;

namespace Interfaces
{
    public interface IRemoteOperation
    {
        string TesterConnexion(string nomClient);
        DataSet GetProduits();
        DataSet RechercherProduit(int idProduit);
        int AjouterProduit(int idProduit, string designation, int seuilAlerte);
        int ModifierProduit(int idProduit, string designation, int seuilAlerte);
        int SupprimerProduit(int idProduit);
        // Affected row counts distinguish success from an unperformed movement.
        int AjouterEntreeStock(int idProduit, int quantite);
        int EnregistrerSortieStock(int idProduit, int quantite);
        DataSet GetProduitsEnAlerte();
        DataSet GetProduitsEpuises();
        int? GetQuantiteStock(int idProduit);
    }
}
