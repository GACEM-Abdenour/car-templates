using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
                TcpChannel channel = new TcpChannel();
                ChannelServices.RegisterChannel(channel, false);

                remoteOperation = (IRemoteOperation)Activator.GetObject(
                    typeof(IRemoteOperation),
                    "tcp://localhost:1069/RemoteOperation" );
            }
            catch (Exception ex)
            {
               
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = remoteOperation.GetEtudiants();
                DataView dvSample = ds.Tables["Etudiant"].DefaultView;
                dataGridView1.DataSource = dvSample;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur affichage : " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                int mat = int.Parse(txtMatricule.Text);
                int x = remoteOperation.AjouterEtudiant(mat, txtNom.Text, txtPrenom.Text);
                if (x == 1)
                {
                    MessageBox.Show("Enregistrement ajoute avec succes...");
                    btnAfficher_Click(sender, e); // Refresh DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur ajout : " + ex.Message);
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            try
            {
                int mat = int.Parse(txtMatricule.Text);
                DataSet ds = remoteOperation.RechercherEtudiant(mat);
                dataGridView1.DataSource = ds.Tables["Etudiant"].DefaultView;

                if (ds.Tables["Etudiant"].Rows.Count > 0)
                {
                    txtNom.Text = ds.Tables["Etudiant"].Rows[0][1].ToString();
                    txtPrenom.Text = ds.Tables["Etudiant"].Rows[0][2].ToString();
                }
                else
                {
                    MessageBox.Show("Enregistrement introuvable...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur recherche : " + ex.Message);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                int mat = int.Parse(txtMatricule.Text);
                int x = remoteOperation.ModifierEtudiant(mat, txtNom.Text, txtPrenom.Text);
                if (x == 1)
                {
                    MessageBox.Show("Enregistrement modifie avec succes...");
                    btnAfficher_Click(sender, e); // Refresh DataGridView
                }
                else
                {
                    MessageBox.Show("Enregistrement introuvable...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur modification : " + ex.Message);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                int mat = int.Parse(txtMatricule.Text);
                int x = remoteOperation.SupprimerEtudiant(mat);
                if (x == 1)
                {
                    MessageBox.Show("Enregistrement supprime avec succes...");
                    txtMatricule.Clear();
                    txtNom.Clear();
                    txtPrenom.Clear();
                    btnAfficher_Click(sender, e); // Refresh DataGridView
                }
                else
                {
                    MessageBox.Show("Enregistrement introuvable...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur suppression : " + ex.Message);
            }
        }
    }
}
