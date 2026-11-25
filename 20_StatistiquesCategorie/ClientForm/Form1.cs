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
        private int Entier(TextBox t, int min, int max)
        {
            int n;
            if (!int.TryParse(t.Text, out n) || n < min || n > max) throw new ArgumentException("Nombre invalide.");
            return n;
        }
        private decimal Prix(TextBox t)
        {
            decimal n;
            if (!decimal.TryParse(t.Text, out n) || n < 0 || n > 9999999999.99m) throw new ArgumentException("Montant invalide.");
            return n;
        }
        private string Texte(TextBox t, int max)
        {
            string v = t.Text.Trim();
            if (v.Length == 0 || v.Length > max) throw new ArgumentException("Texte invalide.");
            return v;
        }
        // TRICK 20: two separate DataSets bind to two independent grids.
        private void Afficher(DataGridView grid, DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0) throw new InvalidOperationException("Table absente.");
            grid.DataSource = ds.Tables[0].DefaultView;
            lblResultat.Text = ds.Tables[0].Rows.Count + " ligne(s).";
        }
        private void Resultat(int n)
        {
            lblResultat.Text = n == 0 ? "Vente introuvable." : n + " ligne(s) modifiée(s).";
            dataGridView2.DataSource = null;
            Afficher(dataGridView1, remoteOperation.GetVentes());
        }
        private void btnAfficher_Click(object s, EventArgs e)
        {
            Run(() => Afficher(dataGridView1, remoteOperation.GetVentes()));
        }
        private void btnRechercher_Click(object s, EventArgs e)
        {
            Run(() => Afficher(dataGridView1, remoteOperation.RechercherVente(Entier(txtIdVente, 0, 99999))));
        }
        private void btnAjouter_Click(object s, EventArgs e)
        {
            Run(() => Resultat(remoteOperation.AjouterVente(Entier(txtIdVente, 0, 99999), Texte(txtProduit, 60), Texte(txtCategorie, 40), Entier(txtQuantite, 1, 999999), Prix(txtPrixUnitaire))));
        }
        private void btnModifier_Click(object s, EventArgs e)
        {
            Run(() => Resultat(remoteOperation.ModifierVente(Entier(txtIdVente, 0, 99999), Texte(txtProduit, 60), Texte(txtCategorie, 40), Entier(txtQuantite, 1, 999999), Prix(txtPrixUnitaire))));
        }
        private void btnSupprimer_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                int id = Entier(txtIdVente, 0, 99999);
                if (MessageBox.Show("Confirmer la suppression ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                Resultat(remoteOperation.SupprimerVente(id));
            });
        }
        private void btnStatistiques_Click(object s, EventArgs e)
        {
            Run(() => Afficher(dataGridView2, remoteOperation.GetStatistiquesParCategorie()));
        }
        private void btnFiltrerCA_Click(object s, EventArgs e)
        {
            Run(() => Afficher(dataGridView2, remoteOperation.GetCategoriesParChiffreAffaires(Prix(txtSeuilCA))));
        }
        private void btnFiltrerNombre_Click(object s, EventArgs e)
        {
            Run(() => Afficher(dataGridView2, remoteOperation.GetCategoriesParNombreVentes(Entier(txtNombreMinimum, 0, int.MaxValue))));
        }
        private void btnStatistiquesProduit_Click(object s, EventArgs e)
        {
            Run(() => Afficher(dataGridView2, remoteOperation.GetStatistiquesParCategorieEtProduit()));
        }
        private void btnFiltrerPrix_Click(object s, EventArgs e)
        {
            Run(() => Afficher(dataGridView2, remoteOperation.GetStatistiquesPrixMinimum(Prix(txtPrixMinimum))));
        }
        private void btnPrixMoyenPondere_Click(object s, EventArgs e)
        {
            Run(() => Afficher(dataGridView2, remoteOperation.GetPrixMoyenPondereParCategorie()));
        }
    }
}
