using System;

namespace Interfaces
{
    [Serializable]
    public class ResultatCompteur
    {
        public string InstanceId
        {
            get;
            set;
        }
        public int Valeur
        {
            get;
            set;
        }
    }
}
