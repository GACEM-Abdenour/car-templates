using System.Data;
namespace Interfaces {
    // Shared contract: both Machine 1 and Machine 2 reference this assembly.
    public interface IRemoteOperation {
        string TesterConnexion(string nomClient);
        // ADAPTATION TP4: DataSet crosses Remoting by value and can contain 0..n rows.
        DataSet GetEmployes(); DataSet RechercherEmploye(int matricule); DataSet GetDepartements(); DataSet GetEmployesParDepartement(string departement); int AjouterEmploye(int matricule,string nom,string prenom,string departement,decimal salaire); int ModifierEmploye(int matricule,string nom,string prenom,string departement,decimal salaire); int SupprimerEmploye(int matricule);
    }
}
