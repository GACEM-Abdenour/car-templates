using System.Collections.Generic;

namespace Interfaces
{
    public interface IRemoteOperation
    {
        string TesterConnexion(string nomClient);
        Etudiant GetEtudiant();
        Etudiant ModifierCopie(Etudiant etudiant);
        List<Etudiant> GetEtudiants();
        int GetCompteur();
        ResultatCompteur IncrementerCompteur();
        void ReinitialiserCompteur();
        string GetInstanceId();
        ResultatCompteur IncrementerCompteurGlobal();
    }
}
