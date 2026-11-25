using System;

namespace Interfaces
{
    [Serializable]
    public class Etudiant
    {
        public int Matricule
        {
            get;
            set;
        }
        public string Nom
        {
            get;
            set;
        }
        public string Prenom
        {
            get;
            set;
        }
        public decimal Note
        {
            get;
            set;
        }
    }
}
