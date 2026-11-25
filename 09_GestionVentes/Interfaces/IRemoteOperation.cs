using System.Data;

namespace Interfaces
{
    // Shared contract: both Machine 1 and Machine 2 reference this assembly.
    public interface IRemoteOperation
    {
        string TesterConnexion(string nomClient);
        // ADAPTATION TP4: DataSet crosses Remoting by value and can contain 0..n rows.
        DataSet GetVentes();
        DataSet RechercherVente(int idVente);
        int AjouterVente(int idVente, string produit, int quantite, decimal prixUnitaire);
        int ModifierVente(int idVente, string produit, int quantite, decimal prixUnitaire);
        int SupprimerVente(int idVente);
        decimal CalculerChiffreAffaires();
        decimal CalculerChiffreAffairesParProduit(string produit);
        int CalculerQuantiteTotale();
    }
}
