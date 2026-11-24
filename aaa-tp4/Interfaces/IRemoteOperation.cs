using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Interfaces
{
    public interface IRemoteOperation
    {
        string TesterConnexion(string nomClient);

        // Read operations (return DataSet)
        DataSet GetEtudiants();
        DataSet RechercherEtudiant(int matricule);

        // Write operations (return int = number of rows affected)
        int AjouterEtudiant(int matricule, string nom, string prenom);
        int ModifierEtudiant(int matricule, string nom, string prenom);
        int SupprimerEtudiant(int matricule);
    }
}