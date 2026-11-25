using System;
using System.Collections.Generic;
using System.Threading;
using Interfaces;

namespace Server
{
    public class RemoteOperation : MarshalByRefObject, IRemoteOperation
    {
        // TRICK 22: this object stays on the server behind a proxy; Serializable Etudiant travels by value.
        private int compteur;
        private static int compteurGlobal;
        private readonly string instanceId = Guid.NewGuid().ToString();
        public RemoteOperation()
        {
            Console.WriteLine("Nouvelle instance : " + instanceId);
        }
        public override object InitializeLifetimeService()
        {
            return null;
        }
        public string TesterConnexion(string nomClient)
        {
            return "Bonjour " + nomClient + ", serveur " + Environment.MachineName;
        }
        public Etudiant GetEtudiant()
        {
            return new Etudiant { Matricule = 10001, Nom = "Benali", Prenom = "Ahmed", Note = 15 };
        }
        public Etudiant ModifierCopie(Etudiant e)
        {
            if (e == null || string.IsNullOrWhiteSpace(e.Nom) || string.IsNullOrWhiteSpace(e.Prenom) || e.Note < 0 || e.Note > 20) throw new ArgumentException("Étudiant invalide.");
            e.Nom = e.Nom.ToUpperInvariant();
            return e;
        }
        public List<Etudiant> GetEtudiants()
        {
            return new List<Etudiant> { GetEtudiant(), new Etudiant { Matricule = 10002, Nom = "Amari", Prenom = "Sara", Note = 17 } };
        }
        public int GetCompteur()
        {
            return Volatile.Read(ref compteur);
        }
        public ResultatCompteur IncrementerCompteur()
        {
            return new ResultatCompteur { InstanceId = instanceId, Valeur = Interlocked.Increment(ref compteur) };
        }
        public void ReinitialiserCompteur()
        {
            Interlocked.Exchange(ref compteur, 0);
        }
        public string GetInstanceId()
        {
            return instanceId;
        }
        // Static state is per application domain, not durable across server restart.
        public ResultatCompteur IncrementerCompteurGlobal()
        {
            return new ResultatCompteur { InstanceId = instanceId, Valeur = Interlocked.Increment(ref compteurGlobal) };
        }
    }
}
