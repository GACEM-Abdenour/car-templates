using System.Data;
namespace Interfaces {
    // Shared contract: both Machine 1 and Machine 2 reference this assembly.
    public interface IRemoteOperation {
        string TesterConnexion(string nomClient);
        // ADAPTATION TP4: DataSet crosses Remoting by value and can contain 0..n rows.
        DataSet GetArticles(); DataSet RechercherArticle(int idArticle); DataSet RechercherParDOI(string doi); int AjouterArticle(int idArticle,string titre,string auteur,string revue,int anneePublication,string doi); int ModifierArticle(int idArticle,string titre,string auteur,string revue,int anneePublication,string doi); int SupprimerArticle(int idArticle);
    }
}
