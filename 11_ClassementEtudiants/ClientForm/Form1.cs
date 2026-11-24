using System;
using System.Data;
using System.Globalization;
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
                // MACHINE 1: replace localhost with the Machine 2 IP for physical deployment.
                remoteOperation = (IRemoteOperation)Activator.GetObject(typeof(IRemoteOperation), "tcp://localhost:1069/RemoteOperation");
            }
            catch (Exception ex) { MessageBox.Show("Erreur de connexion : " + ex.Message); }
        }

        private void Executer(Action action)
        {
            try { action(); }
            catch (Exception ex) { MessageBox.Show("Erreur : " + ex.Message); }
        }

        // MACHINE 1: display all rows returned by Machine 2, including an empty result.
        private void Afficher(DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0) throw new InvalidOperationException("Aucune table reçue du serveur.");
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            if (ds.Tables[0].Rows.Count == 0) MessageBox.Show("Aucun résultat.");
        }

        private int LireMatricule()
        {
            int valeur;
            if (!int.TryParse(txtMatricule.Text, out valeur) || valeur < 0 || valeur > 99999)
                throw new ArgumentException("Matricule entier attendu entre 0 et 99999.");
            return valeur;
        }

        // TRICK 06: TryParse uses the Windows current culture's decimal separator.
        private decimal LireNote(TextBox champ)
        {
            decimal valeur;
            if (!decimal.TryParse(champ.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out valeur) || valeur < 0 || valeur > 20)
                throw new ArgumentException("La note doit être un nombre entre 0 et 20, avec le séparateur décimal local.");
            return valeur;
        }

        private void VerifierNoms()
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtPrenom.Text) || txtNom.Text.Trim().Length > 30 || txtPrenom.Text.Trim().Length > 30)
                throw new ArgumentException("Nom et prénom sont obligatoires (30 caractères maximum).");
        }

        private void ResultatEcriture(int lignes)
        {
            MessageBox.Show(lignes == 0 ? "Étudiant introuvable." : lignes + " ligne(s) modifiée(s).");
            Afficher(remoteOperation.GetEtudiants());
        }

        private void btnAfficher_Click(object sender, EventArgs e) { Executer(() => Afficher(remoteOperation.GetEtudiants())); }
        private void btnRechercher_Click(object sender, EventArgs e) { Executer(() => Afficher(remoteOperation.RechercherEtudiant(LireMatricule()))); }
        private void btnAjouter_Click(object sender, EventArgs e) { Executer(() => { VerifierNoms(); ResultatEcriture(remoteOperation.AjouterEtudiant(LireMatricule(), txtNom.Text.Trim(), txtPrenom.Text.Trim(), LireNote(txtNote))); }); }
        private void btnModifier_Click(object sender, EventArgs e) { Executer(() => { VerifierNoms(); ResultatEcriture(remoteOperation.ModifierEtudiant(LireMatricule(), txtNom.Text.Trim(), txtPrenom.Text.Trim(), LireNote(txtNote))); }); }
        private void btnSupprimer_Click(object sender, EventArgs e) { Executer(() => ResultatEcriture(remoteOperation.SupprimerEtudiant(LireMatricule()))); }
        // TRICK 11: Machine 1 sends N; Machine 2 sorts before limiting.
        private void btnTrierNom_Click(object sender,EventArgs e){Executer(()=>Afficher(remoteOperation.TrierParNom()));}
        private void btnTrierCroissant_Click(object sender,EventArgs e){Executer(()=>Afficher(remoteOperation.TrierParNoteCroissante()));}
        private void btnTrierDecroissant_Click(object sender,EventArgs e){Executer(()=>Afficher(remoteOperation.TrierParNoteDecroissante()));}
        private void btnMeilleurs_Click(object sender,EventArgs e){Executer(()=>{int n;if(!int.TryParse(txtNombre.Text,out n)||n<=0)throw new ArgumentException("Nombre positif requis.");Afficher(remoteOperation.GetMeilleursEtudiants(n));});}
        private void btnClassement_Click(object sender,EventArgs e){Executer(()=>Afficher(remoteOperation.GetClassement()));}
    }
}
