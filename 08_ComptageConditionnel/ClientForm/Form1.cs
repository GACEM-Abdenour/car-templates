using Interfaces; using System; using System.Data; using System.Runtime.Remoting.Channels; using System.Runtime.Remoting.Channels.Tcp; using System.Windows.Forms;
namespace ClientForm { public partial class Form1 : Form {
 private IRemoteOperation remoteOperation;
 public Form1() { InitializeComponent(); try { ChannelServices.RegisterChannel(new TcpChannel(),false); // MACHINE 1: replace localhost by Machine 2 IP.
 remoteOperation=(IRemoteOperation)Activator.GetObject(typeof(IRemoteOperation),"tcp://localhost:1069/RemoteOperation"); } catch(Exception ex) { MessageBox.Show("Erreur Remoting: "+ex.Message); } }
 private void Afficher(DataSet ds) { if(ds==null || ds.Tables.Count==0) { dataGridView1.DataSource=null; return; } dataGridView1.DataSource=ds.Tables[0].DefaultView; if(ds.Tables[0].Rows.Count==0) MessageBox.Show("Aucun résultat."); }
 private void Executer(Action action){try{action();}catch(Exception ex){MessageBox.Show("Erreur : "+ex.Message);}}
 private int LireId(){int id;if(!int.TryParse(txtIdCours.Text,out id)||id<0||id>99999)throw new ArgumentException("Identifiant invalide.");return id;}
 private decimal LireVolume(){decimal volume;if(!decimal.TryParse(txtVolumeHoraire.Text,out volume)||volume<0||volume>999.99m)throw new ArgumentException("Volume invalide.");return volume;}
 private void VerifierTexte(){if(string.IsNullOrWhiteSpace(txtIntitule.Text)||txtIntitule.Text.Trim().Length>80||string.IsNullOrWhiteSpace(txtEnseignant.Text)||txtEnseignant.Text.Trim().Length>60)throw new ArgumentException("Intitulé et enseignant obligatoires.");}
 private void btnAjouter_Click(object s,EventArgs e){Executer(()=>{VerifierTexte();int n=remoteOperation.AjouterCours(LireId(),txtIntitule.Text.Trim(),txtEnseignant.Text.Trim(),LireVolume());MessageBox.Show(n+" ligne(s) ajoutée(s).");Afficher(remoteOperation.GetCours());});}
 private void btnModifier_Click(object s,EventArgs e){Executer(()=>{VerifierTexte();int n=remoteOperation.ModifierCours(LireId(),txtIntitule.Text.Trim(),txtEnseignant.Text.Trim(),LireVolume());MessageBox.Show(n+" ligne(s) modifiée(s).");Afficher(remoteOperation.GetCours());});}
 private void btnSupprimer_Click(object s,EventArgs e){Executer(()=>{int n=remoteOperation.SupprimerCours(LireId());MessageBox.Show(n+" ligne(s) supprimée(s).");Afficher(remoteOperation.GetCours());});}
 private void btnRechercher_Click(object s,EventArgs e){Executer(()=>Afficher(remoteOperation.RechercherCours(LireId())));}
 private void btnAfficher_Click(object s,EventArgs e){Executer(()=>Afficher(remoteOperation.GetCours()));}
 private void btnCompterTous_Click(object s,EventArgs e){Executer(()=>lblResultat.Text="Résultat : "+remoteOperation.CompterCours());}
 private void btnCompterPlusDe30_Click(object s,EventArgs e){Executer(()=>lblResultat.Text="Résultat : "+remoteOperation.CompterCoursPlusDe30Heures());}
 private void btnCompterParSeuil_Click(object s,EventArgs e){Executer(()=>{decimal n;if(!decimal.TryParse(txtSeuil.Text,out n)||n<0)throw new ArgumentException("Seuil invalide.");lblResultat.Text="Résultat : "+remoteOperation.CompterCoursParVolumeHoraire(n);});}
 private void btnCompterEnseignant_Click(object s,EventArgs e){Executer(()=>{if(string.IsNullOrWhiteSpace(txtEnseignant.Text))throw new ArgumentException("Enseignant obligatoire.");lblResultat.Text="Résultat : "+remoteOperation.CompterCoursParEnseignant(txtEnseignant.Text.Trim());});}
} }
