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
                // MACHINE 1: replace localhost with Machine 2 IP.
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
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
        private int Id()
        {
            int n;
            if (!int.TryParse(txtIdCandidat.Text, out n) || n < 0 || n > 99999) throw new ArgumentException("Identifiant invalide.");
            return n;
        }
        private decimal Note(TextBox t)
        {
            decimal n;
            if (!decimal.TryParse(t.Text, out n) || n < 0 || n > 20) throw new ArgumentException("Note invalide (0 à 20).");
            return n;
        }
        private string Nom(TextBox t)
        {
            string v = t.Text.Trim();
            if (v.Length == 0 || v.Length > 30) throw new ArgumentException("Nom ou prénom invalide.");
            return v;
        }
        private string Decision()
        {
            if (cmbDecision.SelectedItem == null) throw new ArgumentException("Sélectionnez une décision.");
            return cmbDecision.SelectedItem.ToString();
        }
        private void Afficher(DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0) throw new InvalidOperationException("Table absente.");
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            if (ds.Tables[0].Rows.Count == 0) MessageBox.Show("Aucun résultat.");
        }
        private void Resultat(int n)
        {
            lblResultat.Text = n == 0 ? "Candidat introuvable." : n + " ligne(s) modifiée(s).";
            Afficher(remoteOperation.GetCandidats());
        }
        private void btnAfficher_Click(object s, EventArgs e)
        {
            Run(() => Afficher(remoteOperation.GetCandidats()));
        }
        private void btnRechercher_Click(object s, EventArgs e)
        {
            Run(() => Afficher(remoteOperation.RechercherCandidat(Id())));
        }
        private void btnAjouter_Click(object s, EventArgs e)
        {
            Run(() => Resultat(remoteOperation.AjouterCandidat(Id(), Nom(txtNom), Nom(txtPrenom), Note(txtNoteEcrit), Note(txtNoteOral))));
        }
        private void btnModifier_Click(object s, EventArgs e)
        {
            Run(() => Resultat(remoteOperation.ModifierCandidat(Id(), Nom(txtNom), Nom(txtPrenom), Note(txtNoteEcrit), Note(txtNoteOral))));
        }
        private void btnSupprimer_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                int id = Id();
                if (MessageBox.Show("Confirmer la suppression ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                Resultat(remoteOperation.SupprimerCandidat(id));
            });
        }
        // TRICK 19: Oracle calculates decisions; the fixed ComboBox does not duplicate classification logic.
        private void btnAfficherResultats_Click(object s, EventArgs e)
        {
            Run(() => Afficher(remoteOperation.GetCandidatsAvecResultats()));
        }
        private void btnAfficherAdmis_Click(object s, EventArgs e)
        {
            Run(() => Afficher(remoteOperation.GetAdmis()));
        }
        private void btnFiltrerDecision_Click(object s, EventArgs e)
        {
            Run(() => Afficher(remoteOperation.GetCandidatsParDecision(Decision())));
        }
        private void btnCompterDecision_Click(object s, EventArgs e)
        {
            Run(() => lblResultat.Text = "Nombre : " + remoteOperation.CompterCandidatsParDecision(Decision()));
        }
    }
}
