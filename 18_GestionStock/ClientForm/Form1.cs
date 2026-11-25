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
        private int Nombre(TextBox t, int min, int max)
        {
            int n;
            if (!int.TryParse(t.Text, out n) || n < min || n > max) throw new ArgumentException("Valeur invalide.");
            return n;
        }
        private int Id()
        {
            return Nombre(txtIdProduit, 0, 99999);
        }
        private int Seuil()
        {
            return Nombre(txtSeuilAlerte, 0, 99999999);
        }
        private int Mouvement()
        {
            return Nombre(txtQuantiteMouvement, 1, 99999999);
        }
        private string Designation()
        {
            string d = txtDesignation.Text.Trim();
            if (d.Length == 0 || d.Length > 60) throw new ArgumentException("Désignation invalide.");
            return d;
        }
        private void Afficher(DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0) throw new InvalidOperationException("Table absente.");
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            if (ds.Tables[0].Rows.Count == 0) MessageBox.Show("Aucun résultat.");
        }
        private void Consulter(int id)
        {
            int? q = remoteOperation.GetQuantiteStock(id);
            txtQuantiteActuelle.Text = q.HasValue ? q.Value.ToString() : "";
            if (!q.HasValue) MessageBox.Show("Produit introuvable.");
        }
        private void btnAfficher_Click(object s, EventArgs e)
        {
            Run(() => Afficher(remoteOperation.GetProduits()));
        }
        private void btnRechercher_Click(object s, EventArgs e)
        {
            Run(() => Afficher(remoteOperation.RechercherProduit(Id())));
        }
        private void btnAjouter_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                int id = Id();
                int n = remoteOperation.AjouterProduit(id, Designation(), Seuil());
                lblResultat.Text = n + " ligne(s) ajoutée(s).";
                Afficher(remoteOperation.GetProduits());
                Consulter(id);
            });
        }
        private void btnModifier_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                int n = remoteOperation.ModifierProduit(Id(), Designation(), Seuil());
                lblResultat.Text = n == 0 ? "Produit introuvable." : "Produit modifié.";
                Afficher(remoteOperation.GetProduits());
            });
        }
        private void btnSupprimer_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                int id = Id();
                if (MessageBox.Show("Supprimer si stock nul ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                int n = remoteOperation.SupprimerProduit(id);
                lblResultat.Text = n == 0 ? "Introuvable ou stock non nul." : "Produit supprimé.";
                txtQuantiteActuelle.Clear();
                Afficher(remoteOperation.GetProduits());
            });
        }
        // TRICK 18: the displayed stock is never used as authority for an exit.
        private void btnEntree_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                int id = Id();
                int n = remoteOperation.AjouterEntreeStock(id, Mouvement());
                lblResultat.Text = n == 0 ? "Produit introuvable." : "Entrée enregistrée.";
                Afficher(remoteOperation.GetProduits());
                Consulter(id);
            });
        }
        private void btnSortie_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                int id = Id();
                int n = remoteOperation.EnregistrerSortieStock(id, Mouvement());
                lblResultat.Text = n == 0 ? "Sortie non effectuée : introuvable ou stock insuffisant." : "Sortie enregistrée.";
                Afficher(remoteOperation.GetProduits());
                Consulter(id);
            });
        }
        private void btnConsulterStock_Click(object s, EventArgs e)
        {
            Run(() => Consulter(Id()));
        }
        private void btnAfficherAlertes_Click(object s, EventArgs e)
        {
            Run(() => Afficher(remoteOperation.GetProduitsEnAlerte()));
        }
        private void btnAfficherEpuises_Click(object s, EventArgs e)
        {
            Run(() => Afficher(remoteOperation.GetProduitsEpuises()));
        }
    }
}
