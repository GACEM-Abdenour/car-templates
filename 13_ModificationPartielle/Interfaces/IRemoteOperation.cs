using System.Data;
namespace Interfaces { public interface IRemoteOperation {
 string TesterConnexion(string nomClient);
 DataSet GetEmployes(); DataSet RechercherEmploye(int matricule);
 // Write methods return the number of affected rows.
 int AjouterEmploye(int matricule,string nom,string prenom,string departement,string telephone,decimal salaire);
 int ModifierEmploye(int matricule,string nom,string prenom,string departement,string telephone,decimal salaire);
 int SupprimerEmploye(int matricule);
 int ModifierSalaire(int matricule,decimal salaire); int ModifierDepartement(int matricule,string departement); int ModifierTelephone(int matricule,string telephone);
 // A true flag includes its field in SET; false preserves it. A selected blank telephone clears it.
 int ModifierEmployePartiellement(int matricule,bool changerSalaire,decimal salaire,bool changerDepartement,string departement,bool changerTelephone,string telephone);
} }
