using System.Data;
namespace Interfaces { public interface IRemoteOperation {
 string TesterConnexion(string nomClient);
 // DataSet returns matching records; bool only answers whether a duplicate exists.
 DataSet GetEtudiants(); DataSet RechercherEtudiant(int matricule); DataSet RechercherParEmail(string email);
 bool EtudiantExiste(int matricule); bool EmailExiste(string email); bool EmailUtiliseParAutreEtudiant(int matricule,string email);
 // Writes return affected rows; duplicates raise a standard InvalidOperationException.
 int AjouterEtudiant(int matricule,string nom,string prenom,string email); int ModifierEtudiant(int matricule,string nom,string prenom,string email); int SupprimerEtudiant(int matricule);
} }
