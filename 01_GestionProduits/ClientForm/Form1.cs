using Interfaces;
using System;
using System.Data;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class Form1 : Form
    {
        private IRemoteOperation remoteOperation;
        private bool chargementCombo;
        public Form1()
        {
            InitializeComponent();
            try
            {
                ChannelServices.RegisterChannel(new TcpChannel(), false);
                // MACHINE 1: replace localhost by Machine 2 IP.
                remoteOperation = (IRemoteOperation) Activator.GetObject(typeof(IRemoteOperation), "tcp://localhost:1069/RemoteOperation");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur Remoting: " + ex.Message);
            }
        }
        private void Afficher(DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0)
            {
                dataGridView1.DataSource = null;
                return;
            }
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            if (ds.Tables[0].Rows.Count == 0) MessageBox.Show("Aucun resultat.");
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
        private long Code()
        {
            long c;
            if (!long.TryParse(txtCodeBarre.Text, out c) || c < 0 || c > 9999999999L) throw new ArgumentException("Code-barres invalide (10 chiffres maximum).");
            return c;
        }
        private int Quantite()
        {
            int q;
            if (!int.TryParse(txtQuantite.Text, out q) || q < 0 || q > 999999) throw new ArgumentException("Quantité invalide.");
            return q;
        }
        // Decimal uses the Windows culture's separator.
        private decimal Prix()
        {
            decimal p;
            if (!decimal.TryParse(txtPrix.Text, out p) || p < 0 || p > 9999999999.99m) throw new ArgumentException("Prix invalide.");
            return p;
        }
        private string Designation()
        {
            string d = txtDesignation.Text.Trim();
            if (d.Length == 0 || d.Length > 50) throw new ArgumentException("Désignation obligatoire (50 caractères maximum).");
            return d;
        }
        private void Resultat(int n)
        {
            MessageBox.Show(n == 0 ? "Produit introuvable." : n + " ligne(s) modifiée(s).");
            Afficher(remoteOperation.GetProduits());
        }
        private void btnAfficher_Click(object s, EventArgs e)
        {
            Executer(() => Afficher(remoteOperation.GetProduits()));
        }
        private void btnRechercher_Click(object s, EventArgs e)
        {
            Executer(() => Afficher(remoteOperation.RechercherProduit(Code())));
        }
        private void btnAjouter_Click(object s, EventArgs e)
        {
            Executer(() => Resultat(remoteOperation.AjouterProduit(Code(), Designation(), Quantite(), Prix())));
        }
        private void btnModifier_Click(object s, EventArgs e)
        {
            Executer(() => Resultat(remoteOperation.ModifierProduit(Code(), Designation(), Quantite(), Prix())));
        }
        private void btnSupprimer_Click(object s, EventArgs e)
        {
            Executer(() => Resultat(remoteOperation.SupprimerProduit(Code())));
        }
    }
}
