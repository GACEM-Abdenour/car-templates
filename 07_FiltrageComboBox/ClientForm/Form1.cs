using System;
using System.Data;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;
using Interfaces;
namespace ClientForm {
 public partial class Form1 : Form {
  private IRemoteOperation remoteOperation;
  private bool chargementCombo=true;
  public Form1() { InitializeComponent(); try { ChannelServices.RegisterChannel(new TcpChannel(),false); // MACHINE 1: change localhost to the server IP.
   remoteOperation=(IRemoteOperation)Activator.GetObject(typeof(IRemoteOperation),"tcp://localhost:1069/RemoteOperation"); } catch(Exception ex) { MessageBox.Show("Connexion : "+ex.Message); } }
  private void Executer(Action action) { try { action(); } catch(Exception ex) { MessageBox.Show("Erreur : "+ex.Message); } }
  private void Afficher(DataSet ds) { if(ds==null||ds.Tables.Count==0) throw new InvalidOperationException("Aucune table reçue."); dataGridView1.DataSource=ds.Tables[0].DefaultView; if(ds.Tables[0].Rows.Count==0) MessageBox.Show("Aucun résultat."); }
  private int Matricule() { int n; if(!int.TryParse(txtMatricule.Text,out n)||n<0||n>99999) throw new ArgumentException("Matricule invalide."); return n; }
  private decimal Salaire() { decimal n; if(!decimal.TryParse(txtSalaire.Text,out n)||n<0||n>9999999999.99m) throw new ArgumentException("Salaire invalide."); return n; }
  private string Texte(TextBox t,int max) { string v=t.Text.Trim(); if(v.Length==0||v.Length>max) throw new ArgumentException("Tous les champs texte sont obligatoires."); return v; }
  // TRICK 07: DISTINCT values come from Oracle, while the synthetic Tous entry uses a separate empty value.
  private void ChargerDepartements() {
   chargementCombo=true;
   try { DataSet ds=remoteOperation.GetDepartements(); if(ds==null||ds.Tables.Count==0) throw new InvalidOperationException("Départements indisponibles.");
    DataTable choix=new DataTable(); choix.Columns.Add("libelle",typeof(string)); choix.Columns.Add("valeur",typeof(string)); choix.Rows.Add("Tous","");
    foreach(DataRow row in ds.Tables[0].Rows) if(!row.IsNull("departement")) { string d=Convert.ToString(row["departement"]); choix.Rows.Add(d,d); }
    cmbDepartement.DisplayMember="libelle"; cmbDepartement.ValueMember="valeur"; cmbDepartement.DataSource=choix; cmbDepartement.SelectedIndex=0;
   } finally { chargementCombo=false; }
  }
  private void AppliquerFiltre() { string d=Convert.ToString(cmbDepartement.SelectedValue); Afficher(string.IsNullOrEmpty(d)?remoteOperation.GetEmployes():remoteOperation.GetEmployesParDepartement(d)); }
  private void Actualiser() { ChargerDepartements(); Afficher(remoteOperation.GetEmployes()); }
  private void Form1_Shown(object s,EventArgs e) { Executer(Actualiser); }
  private void btnAfficher_Click(object s,EventArgs e) { Executer(Actualiser); }
  private void btnFiltrer_Click(object s,EventArgs e) { Executer(AppliquerFiltre); }
  private void cmbDepartement_SelectedIndexChanged(object s,EventArgs e) { if(!chargementCombo && remoteOperation!=null) Executer(AppliquerFiltre); }
  private void btnReinitialiser_Click(object s,EventArgs e) { Executer(()=>{chargementCombo=true;try {cmbDepartement.SelectedIndex=0;} finally {chargementCombo=false;} Afficher(remoteOperation.GetEmployes());}); }
  private void btnRechercher_Click(object s,EventArgs e) { Executer(()=>Afficher(remoteOperation.RechercherEmploye(Matricule()))); }
  private void Resultat(int n) { MessageBox.Show(n==0?"Employé introuvable.":n+" ligne(s) modifiée(s)."); Actualiser(); }
  private void btnAjouter_Click(object s,EventArgs e) { Executer(()=>Resultat(remoteOperation.AjouterEmploye(Matricule(),Texte(txtNom,30),Texte(txtPrenom,30),Texte(txtDepartement,40),Salaire()))); }
  private void btnModifier_Click(object s,EventArgs e) { Executer(()=>Resultat(remoteOperation.ModifierEmploye(Matricule(),Texte(txtNom,30),Texte(txtPrenom,30),Texte(txtDepartement,40),Salaire()))); }
  private void btnSupprimer_Click(object s,EventArgs e) { Executer(()=>Resultat(remoteOperation.SupprimerEmploye(Matricule()))); }
 }
}
