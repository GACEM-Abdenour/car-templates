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
        private int? matriculeSelectionne;
        private bool chargementEnCours;
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
        private int Matricule()
        {
            int m;
            if (!int.TryParse(txtMatricule.Text, out m) || m < 0 || m > 99999) throw new ArgumentException("Matricule invalide.");
            return m;
        }
        private string Nom(TextBox t)
        {
            string v = t.Text.Trim();
            if (v.Length == 0 || v.Length > 20) throw new ArgumentException("Nom ou prénom invalide.");
            return v;
        }
        // TRICK 16: rebinding may fire SelectionChanged; clear the previous identity while guarded.
        private void Afficher(DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0) throw new InvalidOperationException("Aucune table reçue.");
            chargementEnCours = true;
            try
            {
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                dataGridView1.ClearSelection();
                matriculeSelectionne = null;
                txtMatricule.ReadOnly = false;
                txtMatricule.Clear();
                txtNom.Clear();
                txtPrenom.Clear();
                lblSelection.Text = "Aucune sélection.";
            }
            finally
            {
                chargementEnCours = false;
            }
            if (ds.Tables[0].Rows.Count == 0) MessageBox.Show("Aucun résultat.");
        }
        // DataGridViewRow is the visual row; DataRowView is its bound record. Names survive column reorder.
        private void Selectionner(DataGridViewRow row)
        {
            DataRowView ligne = row.DataBoundItem as DataRowView;
            if (ligne == null || ligne.Row.IsNull("MATRICULE") || ligne.Row.IsNull("NOM") || ligne.Row.IsNull("PRENOM")) return;
            int m = Convert.ToInt32(ligne["MATRICULE"]);
            matriculeSelectionne = m;
            txtMatricule.Text = m.ToString();
            txtMatricule.ReadOnly = true;
            txtNom.Text = Convert.ToString(ligne["NOM"]);
            txtPrenom.Text = Convert.ToString(ligne["PRENOM"]);
            lblSelection.Text = "Sélection : " + m;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (chargementEnCours || e.RowIndex < 0) return;
            Selectionner(dataGridView1.Rows[e.RowIndex]);
        }
        // Alternative: SelectionChanged can fire during rebinding. Guard it and use SelectedRows, not a possibly stale CurrentRow.
        // if (!chargementEnCours && dataGridView1.SelectedRows.Count > 0) Selectionner(dataGridView1.SelectedRows[0]);
        // CellDoubleClick can call Selectionner(dataGridView1.Rows[e.RowIndex]) after checking e.RowIndex >= 0.
        // Cell values can also be read by name: row.Cells["MATRICULE"].Value; index 0 is fragile after column reordering.
        private void Nouveau()
        {
            chargementEnCours = true;
            try
            {
                matriculeSelectionne = null;
                dataGridView1.ClearSelection();
                txtMatricule.ReadOnly = false;
                txtMatricule.Clear();
                txtNom.Clear();
                txtPrenom.Clear();
                lblSelection.Text = "Nouvel étudiant.";
                txtMatricule.Focus();
            }
            finally
            {
                chargementEnCours = false;
            }
        }
        private void btnNouveau_Click(object s, EventArgs e)
        {
            Nouveau();
        }
        private void btnAfficher_Click(object s, EventArgs e)
        {
            Run(() => Afficher(remoteOperation.GetEtudiants()));
        }
        private void btnRechercher_Click(object s, EventArgs e)
        {
            Run(() => Afficher(remoteOperation.RechercherEtudiant(Matricule())));
        }
        private void btnAjouter_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                if (matriculeSelectionne.HasValue) throw new ArgumentException("Choisissez Nouveau avant l'ajout.");
                remoteOperation.AjouterEtudiant(Matricule(), Nom(txtNom), Nom(txtPrenom));
                Afficher(remoteOperation.GetEtudiants());
            });
        }
        private void btnModifier_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                if (!matriculeSelectionne.HasValue) throw new ArgumentException("Sélectionnez un étudiant.");
                int n = remoteOperation.ModifierEtudiant(matriculeSelectionne.Value, Nom(txtNom), Nom(txtPrenom));
                MessageBox.Show(n + " ligne(s) modifiée(s).");
                Afficher(remoteOperation.GetEtudiants());
            });
        }
        private void btnSupprimer_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                if (!matriculeSelectionne.HasValue) throw new ArgumentException("Sélectionnez un étudiant.");
                if (MessageBox.Show("Confirmer la suppression ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                int n = remoteOperation.SupprimerEtudiant(matriculeSelectionne.Value);
                MessageBox.Show(n + " ligne(s) supprimée(s).");
                Afficher(remoteOperation.GetEtudiants());
            });
        }
    }
}
