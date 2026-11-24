using System; using System.Data; using System.Runtime.Remoting.Channels; using System.Runtime.Remoting.Channels.Tcp; using System.Windows.Forms; using Interfaces;
namespace ClientForm { public partial class Form1:Form {
 private IRemoteOperation remoteOperation;
 public Form1(){InitializeComponent();try{ChannelServices.RegisterChannel(new TcpChannel(),false); // MACHINE 1: replace localhost by Machine 2 IP.
 remoteOperation=(IRemoteOperation)Activator.GetObject(typeof(IRemoteOperation),"tcp://localhost:1069/RemoteOperation");}catch(Exception ex){MessageBox.Show("Connexion : "+ex.Message);}}
 private void Executer(Action a){try{a();}catch(Exception ex){MessageBox.Show("Erreur : "+ex.Message);}}
 private int Matricule(){int n;if(!int.TryParse(txtMatricule.Text,out n)||n<0||n>99999)throw new ArgumentException("Matricule invalide.");return n;}
 private decimal Salaire(){decimal n;if(!decimal.TryParse(txtSalaire.Text,out n)||n<0||n>9999999999.99m)throw new ArgumentException("Salaire invalide.");return n;}
 private string Texte(TextBox t,int max){string s=t.Text.Trim();if(s.Length==0||s.Length>max)throw new ArgumentException("Champ obligatoire ou trop long.");return s;}
 private void Afficher(DataSet ds){if(ds==null||ds.Tables.Count==0)throw new InvalidOperationException("Aucune table reçue.");dataGridView1.DataSource=ds.Tables[0].DefaultView;if(ds.Tables[0].Rows.Count==0)MessageBox.Show("Aucun résultat.");}
 private void Resultat(int n){lblResultat.Text=n==0?"Employé introuvable.":n+" ligne(s) modifiée(s).";if(n>0)Afficher(remoteOperation.GetEmployes());}
 private void btnAfficher_Click(object s,EventArgs e){Executer(()=>Afficher(remoteOperation.GetEmployes()));}
 private void btnRechercher_Click(object s,EventArgs e){Executer(()=>Afficher(remoteOperation.RechercherEmploye(Matricule())));}
 private void btnAjouter_Click(object s,EventArgs e){Executer(()=>Resultat(remoteOperation.AjouterEmploye(Matricule(),Texte(txtNom,30),Texte(txtPrenom,30),Texte(txtDepartement,40),txtTelephone.Text,Salaire())));}
 private void btnModifier_Click(object s,EventArgs e){Executer(()=>Resultat(remoteOperation.ModifierEmploye(Matricule(),Texte(txtNom,30),Texte(txtPrenom,30),Texte(txtDepartement,40),txtTelephone.Text,Salaire())));}
 private void btnSupprimer_Click(object s,EventArgs e){Executer(()=>Resultat(remoteOperation.SupprimerEmploye(Matricule())));}
 private void btnModifierSalaire_Click(object s,EventArgs e){Executer(()=>Resultat(remoteOperation.ModifierSalaire(Matricule(),Salaire())));}
 private void btnModifierDepartement_Click(object s,EventArgs e){Executer(()=>Resultat(remoteOperation.ModifierDepartement(Matricule(),Texte(txtDepartement,40))));}
 private void btnModifierTelephone_Click(object s,EventArgs e){Executer(()=>Resultat(remoteOperation.ModifierTelephone(Matricule(),txtTelephone.Text)));}
 // TRICK 13: only selected fields are validated; a selected blank telephone clears it.
 private void btnModifierSelection_Click(object s,EventArgs e){Executer(()=>{bool salaire=chkModifierSalaire.Checked,departement=chkModifierDepartement.Checked,telephone=chkModifierTelephone.Checked;if(!salaire&&!departement&&!telephone)throw new ArgumentException("Sélectionnez au moins un champ.");decimal montant=salaire?Salaire():0m;string service=departement?Texte(txtDepartement,40):null;Resultat(remoteOperation.ModifierEmployePartiellement(Matricule(),salaire,montant,departement,service,telephone,txtTelephone.Text));});}
} }
