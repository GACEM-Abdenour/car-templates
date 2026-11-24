using System.Data;
namespace Interfaces { public interface IRemoteOperation {
 string TesterConnexion(string nomClient); DataSet GetProduits(); DataSet RechercherProduit(int idProduit);
 int AjouterProduit(int idProduit,string designation,string categorie,int quantite); int ModifierProduit(int idProduit,string designation,string categorie,int quantite);
 DataSet GetProduitsEpuises();
 // Only conditional deletion is exposed. int returns affected rows, including legitimate zero.
 int SupprimerProduitSiStockNul(int idProduit); int SupprimerProduitsEpuises(); int SupprimerProduitsEpuisesParCategorie(string categorie);
} }
