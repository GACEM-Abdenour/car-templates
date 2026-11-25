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
        private void Executer(Action a)
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
        private string Texte(TextBox t, int max)
        {
            string v = t.Text.Trim();
            if (v.Length == 0 || v.Length > max) throw new ArgumentException("Champ obligatoire ou trop long.");
            return v;
        }
        private void Resultat(int n)
        {
            MessageBox.Show(n == 0 ? "Étudiant introuvable." : n + " ligne(s) modifiée(s).");
            Afficher(remoteOperation.GetEtudiants());
        }
        private void btnAfficher_Click(object s, EventArgs e)
        {
            Executer(() => Afficher(remoteOperation.GetEtudiants()));
        }
        // Empty optional filters intentionally return all students.
        private void btnRechercher_Click(object s, EventArgs e)
        {
            Executer(() => Afficher(remoteOperation.RechercherEtudiants(txtFiltreNom.Text.Trim(), txtFiltrePrenom.Text.Trim(), txtFiltreGroupe.Text.Trim())));
        }
        private void btnRechercherMatricule_Click(object s, EventArgs e)
        {
            Executer(() => Afficher(remoteOperation.RechercherEtudiant(Matricule())));
        }
        private void btnRechercherNomOuPrenom_Click(object s, EventArgs e)
        {
            Executer(() => Afficher(remoteOperation.RechercherNomOuPrenom(Texte(txtMotCle, 30))));
        }
        private void btnReinitialiser_Click(object s, EventArgs e)
        {
            txtFiltreNom.Clear();
            txtFiltrePrenom.Clear();
            txtFiltreGroupe.Clear();
            txtMotCle.Clear();
            btnAfficher_Click(s, e);
        }
        private void btnAjouter_Click(object s, EventArgs e)
        {
            Executer(() => Resultat(remoteOperation.AjouterEtudiant(Matricule(), Texte(txtNom, 30), Texte(txtPrenom, 30), Texte(txtGroupe, 10))));
        }
        private void btnModifier_Click(object s, EventArgs e)
        {
            Executer(() => Resultat(remoteOperation.ModifierEtudiant(Matricule(), Texte(txtNom, 30), Texte(txtPrenom, 30), Texte(txtGroupe, 10))));
        }
        private void btnSupprimer_Click(object s, EventArgs e)
        {
            Executer(() => Resultat(remoteOperation.SupprimerEtudiant(Matricule())));
        }
    }
}
