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
        private int? selection;
        private bool chargement;
        public Form1()
        {
            InitializeComponent();
            try
            {
                ChannelServices.RegisterChannel(new TcpChannel(), false);
                // MACHINE 1: replace localhost with the server IP.
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
            int m;
            if (!int.TryParse(txtMatricule.Text, out m) || m < 0 || m > 99999) throw new ArgumentException("Matricule invalide.");
            return m;
        }
        private string Nom(TextBox t)
        {
            string v = t.Text.Trim();
            if (v.Length == 0 || v.Length > 30) throw new ArgumentException("Nom ou prénom invalide.");
            return v;
        }
        private string Specialite()
        {
            string v = txtSpecialite.Text.Trim();
            if (v.Length > 60) throw new ArgumentException("Spécialité trop longue.");
            return v;
        }
        private void Afficher(DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0) throw new InvalidOperationException("Table absente.");
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        // TRICK 17: DisplayMember is the label; ValueMember is the key. SelectedIndex is only a position; SelectedItem is a DataRowView.
        private void ChargerListeEnseignants(int? conserver = null)
        {
            chargement = true;
            try
            {
                DataSet ds = remoteOperation.GetListeEnseignants();
                if (ds == null || ds.Tables.Count == 0) throw new InvalidOperationException("Liste absente.");
                cmbEnseignant.DisplayMember = "NOM_COMPLET";
                cmbEnseignant.ValueMember = "MATRICULE";
                cmbEnseignant.DataSource = ds.Tables[0];
                cmbEnseignant.SelectedIndex = -1;
                if (conserver.HasValue) cmbEnseignant.SelectedValue = conserver.Value;
            }
            finally
            {
                chargement = false;
            }
        }
        private void ChargerEnseignantSelectionne()
        {
            int m;
            if (cmbEnseignant.SelectedValue == null || !int.TryParse(cmbEnseignant.SelectedValue.ToString(), out m)) throw new ArgumentException("Sélectionnez un enseignant.");
            DataSet ds = remoteOperation.RechercherEnseignant(m);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                Nouveau();
                MessageBox.Show("Enseignant introuvable.");
                return;
            }
            DataRow r = ds.Tables[0].Rows[0];
            selection = m;
            txtMatricule.Text = m.ToString();
            txtMatricule.ReadOnly = true;
            txtNom.Text = Convert.ToString(r["NOM"]);
            txtPrenom.Text = Convert.ToString(r["PRENOM"]);
            txtSpecialite.Text = r.IsNull("SPECIALITE") ? "" : Convert.ToString(r["SPECIALITE"]);
            lblSelection.Text = "Sélection : " + m;
        }
        // SelectionChangeCommitted fires for a user selection; SelectedIndexChanged would also need an initialization guard.
        private void cmbEnseignant_SelectionChangeCommitted(object s, EventArgs e)
        {
            if (!chargement) Run(ChargerEnseignantSelectionne);
        }
        private void btnCharger_Click(object s, EventArgs e)
        {
            Run(ChargerEnseignantSelectionne);
        }
        private void Nouveau()
        {
            selection = null;
            chargement = true;
            try
            {
                cmbEnseignant.SelectedIndex = -1;
            }
            finally
            {
                chargement = false;
            }
            txtMatricule.ReadOnly = false;
            txtMatricule.Clear();
            txtNom.Clear();
            txtPrenom.Clear();
            txtSpecialite.Clear();
            lblSelection.Text = "Nouvel enseignant.";
        }
        private void btnNouveau_Click(object s, EventArgs e)
        {
            Nouveau();
        }
        private void btnActualiser_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                ChargerListeEnseignants();
                Nouveau();
                Afficher(remoteOperation.GetEnseignants());
            });
        }
        private void btnAfficher_Click(object s, EventArgs e)
        {
            Run(() => Afficher(remoteOperation.GetEnseignants()));
        }
        private void btnRechercher_Click(object s, EventArgs e)
        {
            Run(() => Afficher(remoteOperation.RechercherEnseignant(Id())));
        }
        private void btnAjouter_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                if (selection.HasValue) throw new ArgumentException("Choisissez Nouveau.");
                int m = Id();
                remoteOperation.AjouterEnseignant(m, Nom(txtNom), Nom(txtPrenom), Specialite());
                Afficher(remoteOperation.GetEnseignants());
                ChargerListeEnseignants(m);
                ChargerEnseignantSelectionne();
            });
        }
        private void btnModifier_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                if (!selection.HasValue) throw new ArgumentException("Sélectionnez un enseignant.");
                int m = selection.Value;
                int n = remoteOperation.ModifierEnseignant(m, Nom(txtNom), Nom(txtPrenom), Specialite());
                if (n == 0)
                {
                    MessageBox.Show("Enseignant introuvable.");
                    ChargerListeEnseignants();
                    Nouveau();
                    return;
                }
                Afficher(remoteOperation.GetEnseignants());
                ChargerListeEnseignants(m);
                ChargerEnseignantSelectionne();
            });
        }
        private void btnSupprimer_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                if (!selection.HasValue) throw new ArgumentException("Sélectionnez un enseignant.");
                if (MessageBox.Show("Confirmer la suppression ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                int n = remoteOperation.SupprimerEnseignant(selection.Value);
                MessageBox.Show(n + " ligne(s) supprimée(s).");
                ChargerListeEnseignants();
                Nouveau();
                Afficher(remoteOperation.GetEnseignants());
            });
        }
        private void Form1_Shown(object s, EventArgs e)
        {
            btnActualiser_Click(s, e);
        }
    }
}
