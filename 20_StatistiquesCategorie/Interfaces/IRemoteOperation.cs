using System.Data;

namespace Interfaces
{
    public interface IRemoteOperation
    {
        string TesterConnexion(string nomClient);
        DataSet GetVentes();
        DataSet RechercherVente(int idVente);
        int AjouterVente(int idVente, string produit, string categorie, int quantite, decimal prixUnitaire);
        int ModifierVente(int idVente, string produit, string categorie, int quantite, decimal prixUnitaire);
        int SupprimerVente(int idVente);
        // DataSet carries a variable number of grouped rows and columns.
        DataSet GetStatistiquesParCategorie();
        DataSet GetCategoriesParChiffreAffaires(decimal seuil);
        DataSet GetCategoriesParNombreVentes(int nombreMinimum);
        DataSet GetStatistiquesParCategorieEtProduit();
        DataSet GetStatistiquesPrixMinimum(decimal prixMinimum);
        DataSet GetPrixMoyenPondereParCategorie();
    }
}
