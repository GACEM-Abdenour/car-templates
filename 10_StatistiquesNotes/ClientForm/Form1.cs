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
                // MACHINE 1: change localhost to Machine 2's IP.
                remoteOperation = (IRemoteOperation) Activator.GetObject(typeof(IRemoteOperation), "tcp://localhost:1069/RemoteOperation");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connexion : " + ex.Message);
            }
        }
        private void Executer(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
        private void Afficher(DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0) throw new InvalidOperationException("Aucune table reçue.");
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            if (ds.Tables[0].Rows.Count == 0) MessageBox.Show("Aucun résultat.");
        }
        private int Matricule()
        {
            int n;
            if (!int.TryParse(txtMatricule.Text, out n) || n < 0 || n > 99999) throw new ArgumentException("Matricule invalide.");
            return n;
        }
        // Parse decimals with the local Windows separator.
        private decimal Note()
        {
            decimal n;
            if (!decimal.TryParse(txtNote.Text, out n) || n < 0 || n > 20) throw new ArgumentException("Note attendue entre 0 et 20.");
            return n;
        }
        private string Nom(TextBox t)
        {
            string n = t.Text.Trim();
            if (n.Length == 0 || n.Length > 30) throw new ArgumentException("Nom et prénom obligatoires (30 caractères maximum).");
            return n;
        }
        private void Resultat(int n)
        {
            MessageBox.Show(n == 0 ? "Étudiant introuvable." : n + " ligne(s) modifiée(s).");
            Afficher(remoteOperation.GetEtudiants());
        }
        private static string Nombre(decimal? n)
        {
            return n.HasValue ? n.Value.ToString("N2") : "N/A";
        }
        private static string Valeur(DataRow r, string colonne)
        {
            return r.IsNull(colonne) ? "N/A" : Convert.ToString(r[colonne]);
        }
        private void btnAfficher_Click(object s, EventArgs e)
        {
            Executer(() => Afficher(remoteOperation.GetEtudiants()));
        }
        private void btnRechercher_Click(object s, EventArgs e)
        {
            Executer(() => Afficher(remoteOperation.RechercherEtudiant(Matricule())));
        }
        private void btnAjouter_Click(object s, EventArgs e)
        {
            Executer(() => Resultat(remoteOperation.AjouterEtudiant(Matricule(), Nom(txtNom), Nom(txtPrenom), Note())));
        }
        private void btnModifier_Click(object s, EventArgs e)
        {
            Executer(() => Resultat(remoteOperation.ModifierEtudiant(Matricule(), Nom(txtNom), Nom(txtPrenom), Note())));
        }
        private void btnSupprimer_Click(object s, EventArgs e)
        {
            Executer(() => Resultat(remoteOperation.SupprimerEtudiant(Matricule())));
        }
        private void btnCalculerMoyenne_Click(object s, EventArgs e)
        {
            Executer(() => lblMoyenne.Text = "Moyenne : " + Nombre(remoteOperation.CalculerMoyenne()));
        }
        private void btnNoteMinimale_Click(object s, EventArgs e)
        {
            Executer(() => lblNoteMinimale.Text = "Minimum : " + Nombre(remoteOperation.GetNoteMinimale()));
        }
        private void btnNoteMaximale_Click(object s, EventArgs e)
        {
            Executer(() => lblNoteMaximale.Text = "Maximum : " + Nombre(remoteOperation.GetNoteMaximale()));
        }
        private void btnCompterAdmis_Click(object s, EventArgs e)
        {
            Executer(() => lblAdmis.Text = "Admis : " + remoteOperation.CompterAdmis());
        }
        private void btnCompterAjournes_Click(object s, EventArgs e)
        {
            Executer(() => lblAjournes.Text = "Ajournés : " + remoteOperation.CompterAjournes());
        }
        // TRICK 10: a single DataSet row can contain many aggregates; NULL means N/A, not a real grade of zero.
        private void btnStatistiques_Click(object s, EventArgs e)
        {
            Executer(() =>
            {
                DataSet ds = remoteOperation.GetStatistiques();
                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) throw new InvalidOperationException("Statistiques indisponibles.");
                DataRow r = ds.Tables[0].Rows[0];
                lblMoyenne.Text = "Moyenne : " + Valeur(r, "moyenne");
                lblNoteMinimale.Text = "Minimum : " + Valeur(r, "note_minimale");
                lblNoteMaximale.Text = "Maximum : " + Valeur(r, "note_maximale");
                lblAdmis.Text = "Admis : " + Valeur(r, "admis");
                lblAjournes.Text = "Ajournés : " + Valeur(r, "ajournes");
                Afficher(ds);
            });
        }
    }
}
