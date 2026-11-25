using System;
using System.Data;

namespace Interfaces
{
    public interface IRemoteOperation
    {
        string TesterConnexion(string nomClient);
        DataSet GetClients();
        DataSet GetProduits();
        DataSet RechercherClient(int idClient);
        DataSet RechercherProduit(int idProduit);
        int AjouterClient(int idClient, string nom, string telephone);
        int ModifierClient(int idClient, string nom, string telephone);
        int SupprimerClient(int idClient);
        int AjouterProduit(int idProduit, string designation, decimal prix, int stock);
        int ModifierProduit(int idProduit, string designation, decimal prix);
        int SupprimerProduit(int idProduit);
        DataSet GetCommandes();
        DataSet GetCommandesParClient(int idClient);
        DataSet GetLignesCommande(int idCommande);
        DataSet RechercherLigneCommande(int idCommande, int idProduit);
        // One call contains a complete draft. Required columns: IDPRODUIT (int), QUANTITE (int); server retrieves prices.
        int AjouterCommande(int idCommande, int idClient, DateTime dateCommande, DataTable lignes);
        decimal CalculerTotalCommande(int idCommande);
        DataSet GetChiffreAffairesParClient();
        DataSet GetClientsSansCommandes();
        DataSet GetProduitsJamaisCommandes();
        DataSet GetProduitsDeuxBases();
    }
}
