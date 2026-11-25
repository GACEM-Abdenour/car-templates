using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;

namespace ClientForm
{
    public partial class Form1 : Form
    {
        private IRemoteOperation remote;
        private Etudiant copie;
        public Form1()
        {
            InitializeComponent();
            try
            {
                string ip = ConfigurationManager.AppSettings["ServerIp"], port = ConfigurationManager.AppSettings["ServerPort"], uri = ConfigurationManager.AppSettings["ObjectUri"];
                lblAdresseServeur.Text = "tcp://" + ip + ":" + port + "/" + uri;
                ChannelServices.RegisterChannel(new TcpChannel(), false);
                remote = (IRemoteOperation) Activator.GetObject(typeof(IRemoteOperation), lblAdresseServeur.Text);
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
        private string Description(Etudiant e)
        {
            return e.Matricule + " " + e.Nom + " " + e.Prenom + " " + e.Note;
        }
        private Etudiant Lire()
        {
            int m;
            decimal n;
            if (!int.TryParse(txtMatricule.Text, out m) || !decimal.TryParse(txtNote.Text, out n) || n < 0 || n > 20 || string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtPrenom.Text)) throw new ArgumentException("Étudiant invalide.");
            return new Etudiant { Matricule = m, Nom = txtNom.Text.Trim(), Prenom = txtPrenom.Text.Trim(), Note = n };
        }
        private void btnTesterConnexion_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                lblConnexion.Text = remote.TesterConnexion(Environment.MachineName);
                txtJournal.AppendText("Proxy distant : " + RemotingServices.IsTransparentProxy(remote) + Environment.NewLine);
            });
        }
        private void btnRecevoirObjet_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                copie = remote.GetEtudiant();
                txtMatricule.Text = copie.Matricule.ToString();
                txtNom.Text = copie.Nom;
                txtPrenom.Text = copie.Prenom;
                txtNote.Text = copie.Note.ToString();
                lblObjetOriginal.Text = "Reçu : " + Description(copie);
            });
        }
        private void btnModifierCopieLocale_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                if (copie == null) throw new InvalidOperationException("Recevez d'abord un objet.");
                copie.Nom = txtNom.Text;
                lblObjetRetourne.Text = "Copie locale : " + Description(copie) + " ; serveur : " + Description(remote.GetEtudiant());
            });
        }
        private void btnEnvoyerObjet_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                Etudiant local = Lire();
                Etudiant resultat = remote.ModifierCopie(local);
                lblObjetOriginal.Text = "Local : " + Description(local);
                lblObjetRetourne.Text = "Retour : " + Description(resultat);
            });
        }
        private void btnAfficherListe_Click(object s, EventArgs e)
        {
            Run(() => dataGridView1.DataSource = remote.GetEtudiants());
        }
        private void Journal(ResultatCompteur r)
        {
            lblInstanceId.Text = "Instance : " + r.InstanceId;
            txtJournal.AppendText(r.InstanceId + " : " + r.Valeur + Environment.NewLine);
        }
        private void btnIncrementer_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                var r = remote.IncrementerCompteur();
                lblCompteur.Text = "Compteur : " + r.Valeur;
                Journal(r);
            });
        }
        private void btnGetCompteur_Click(object s, EventArgs e)
        {
            Run(() => lblCompteur.Text = "Compteur : " + remote.GetCompteur());
        }
        private void btnResetCompteur_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                remote.ReinitialiserCompteur();
                lblCompteur.Text = "Reset envoyé";
            });
        }
        private void btnInstanceId_Click(object s, EventArgs e)
        {
            Run(() => lblInstanceId.Text = "Instance : " + remote.GetInstanceId());
        }
        private void btnIncrementerGlobal_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                var r = remote.IncrementerCompteurGlobal();
                lblCompteurGlobal.Text = "Global : " + r.Valeur;
                Journal(r);
            });
        }
        // Concurrent calls return identity and count together; completion order need not equal call order.
        private async void btnTestConcurrent_Click(object s, EventArgs e)
        {
            btnTestConcurrent.Enabled = false;
            try
            {
                var resultats = await Task.WhenAll(Enumerable.Range(0, 100).Select(i => Task.Run(() =>
                {
                    try
                    {
                        var r = remote.IncrementerCompteur();
                        return r.InstanceId + " : " + r.Valeur;
                    }
                    catch (Exception ex)
                    {
                        return "ÉCHEC : " + ex.Message;
                    }
                })));
                foreach (string r in resultats) txtJournal.AppendText(r + Environment.NewLine);
                lblCompteur.Text = "Terminés : " + resultats.Length + ", échecs : " + resultats.Count(x => x.StartsWith("ÉCHEC"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnTestConcurrent.Enabled = true;
            }
        }
    }
}
