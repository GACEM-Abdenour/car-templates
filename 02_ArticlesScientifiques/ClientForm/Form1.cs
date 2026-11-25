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
        private int Id()
        {
            int n;
            if (!int.TryParse(txtIdArticle.Text, out n) || n < 0 || n > 99999) throw new ArgumentException("Identifiant invalide.");
            return n;
        }
        private int Annee()
        {
            int n;
            if (!int.TryParse(txtAnneePublication.Text, out n) || n < 1 || n > 9999) throw new ArgumentException("Année invalide (1 à 9999).");
            return n;
        }
        private string Texte(TextBox box, int max, bool obligatoire)
        {
            string v = box.Text.Trim();
            if (v.Length > max || (obligatoire && v.Length == 0)) throw new ArgumentException("Texte obligatoire ou trop long : " + box.Name);
            return v;
        }
        private void Resultat(int n)
        {
            MessageBox.Show(n == 0 ? "Article introuvable." : n + " ligne(s) modifiée(s).");
            Afficher(remoteOperation.GetArticles());
        }
        private void btnAfficher_Click(object s, EventArgs e)
        {
            Executer(() => Afficher(remoteOperation.GetArticles()));
        }
        private void btnRechercher_Click(object s, EventArgs e)
        {
            Executer(() => Afficher(remoteOperation.RechercherArticle(Id())));
        }
        private void btnRechercherDOI_Click(object s, EventArgs e)
        {
            Executer(() => Afficher(remoteOperation.RechercherParDOI(Texte(txtDOI, 100, true))));
        }
        private void btnAjouter_Click(object s, EventArgs e)
        {
            Executer(() => Resultat(remoteOperation.AjouterArticle(Id(), Texte(txtTitre, 200, true), Texte(txtAuteur, 100, true), Texte(txtRevue, 100, false), Annee(), Texte(txtDOI, 100, true))));
        }
        private void btnModifier_Click(object s, EventArgs e)
        {
            Executer(() => Resultat(remoteOperation.ModifierArticle(Id(), Texte(txtTitre, 200, true), Texte(txtAuteur, 100, true), Texte(txtRevue, 100, false), Annee(), Texte(txtDOI, 100, true))));
        }
        private void btnSupprimer_Click(object s, EventArgs e)
        {
            Executer(() => Resultat(remoteOperation.SupprimerArticle(Id())));
        }
    }
}
