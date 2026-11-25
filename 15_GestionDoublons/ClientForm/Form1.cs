using System;
using System.Data;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;
using Interfaces;

namespace ClientForm
{
    public partial class Form1 : Form
    {
        private IRemoteOperation remoteOperation;
        public Form1()
        {
            InitializeComponent();
            try
            {
                ChannelServices.RegisterChannel(new TcpChannel(), false);
                // MACHINE 1: replace localhost with server IP.
                remoteOperation = (IRemoteOperation) Activator.GetObject(typeof(IRemoteOperation), "tcp://localhost:1069/RemoteOperation");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Run(Action a)
        {
            try
            {
                a();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private int Id()
        {
            int n;
            if (!int.TryParse(txtMatricule.Text, out n) || n < 0 || n > 99999) throw new ArgumentException("Matricule invalide.");
            return n;
        }
        private string Nom(TextBox t)
        {
            string v = t.Text.Trim();
            if (v.Length == 0 || v.Length > 30) throw new ArgumentException("Nom invalide.");
            return v;
        }
        private string Email()
        {
            string v = txtEmail.Text.Trim().ToLowerInvariant();
            int a = v.IndexOf('@');
            if (v.Length > 100 || a <= 0 || a != v.LastIndexOf('@') || a == v.Length - 1) throw new ArgumentException("Email invalide.");
            foreach (char c in v) if (c < 33 || c > 126) throw new ArgumentException("Email ASCII requis.");
            return v;
        }
        private void Afficher(DataSet d)
        {
            if (d == null || d.Tables.Count == 0) throw new InvalidOperationException("Aucune table reçue.");
            dataGridView1.DataSource = d.Tables[0].DefaultView;
            if (d.Tables[0].Rows.Count == 0) MessageBox.Show("Aucun résultat.");
        }
        private void Resultat(int n)
        {
            lblResultat.Text = n == 0 ? "Étudiant introuvable." : n + " ligne(s) modifiée(s).";
            if (n > 0) Afficher(remoteOperation.GetEtudiants());
        }
        private void btnAfficher_Click(object s, EventArgs e)
        {
            Run(() => Afficher(remoteOperation.GetEtudiants()));
        }
        private void btnRechercher_Click(object s, EventArgs e)
        {
            Run(() => Afficher(remoteOperation.RechercherEtudiant(Id())));
        }
        private void btnRechercherEmail_Click(object s, EventArgs e)
        {
            Run(() => Afficher(remoteOperation.RechercherParEmail(Email())));
        }
        private void btnVerifierMatricule_Click(object s, EventArgs e)
        {
            Run(() => lblResultat.Text = remoteOperation.EtudiantExiste(Id()) ? "Matricule déjà utilisé." : "Matricule disponible.");
        }
        private void btnVerifierEmail_Click(object s, EventArgs e)
        {
            Run(() => lblResultat.Text = remoteOperation.EmailExiste(Email()) ? "Email déjà utilisé." : "Email disponible.");
        }
        // TRICK 15: friendly checks precede writes; the database UNIQUE constraint handles concurrent clients.
        private void btnAjouter_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                int m = Id();
                string n = Nom(txtNom), p = Nom(txtPrenom), email = Email();
                if (remoteOperation.EtudiantExiste(m) || remoteOperation.EmailExiste(email)) throw new ArgumentException("Matricule ou email déjà utilisé.");
                Resultat(remoteOperation.AjouterEtudiant(m, n, p, email));
            });
        }
        private void btnModifier_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                int m = Id();
                string n = Nom(txtNom), p = Nom(txtPrenom), email = Email();
                if (remoteOperation.EmailUtiliseParAutreEtudiant(m, email)) throw new ArgumentException("Email utilisé par un autre étudiant.");
                Resultat(remoteOperation.ModifierEtudiant(m, n, p, email));
            });
        }
        private void btnSupprimer_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                int m = Id();
                if (MessageBox.Show("Confirmer la suppression ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) Resultat(remoteOperation.SupprimerEtudiant(m));
            });
        }
    }
}
