using System;
using System.Data;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;
using Interfaces;

namespace ClientForm {
 public partial class Form1 : Form {
  private IRemoteOperation remoteOperation;
  public Form1() { InitializeComponent(); try { ChannelServices.RegisterChannel(new TcpChannel(),false); // MACHINE 1: change localhost to the server IP.
   remoteOperation=(IRemoteOperation)Activator.GetObject(typeof(IRemoteOperation),"tcp://localhost:1069/RemoteOperation"); } catch(Exception ex) { MessageBox.Show("Connexion : "+ex.Message); } }
  private void Executer(Action action) { try { action(); } catch(Exception ex) { MessageBox.Show("Erreur : "+ex.Message); } }
  private void Afficher(DataSet ds) { if(ds==null||ds.Tables.Count==0) throw new InvalidOperationException("Aucune table reçue."); dataGridView1.DataSource=ds.Tables[0].DefaultView; if(ds.Tables[0].Rows.Count==0) MessageBox.Show("Aucun résultat."); }
  private int Id() { int n; if(!int.TryParse(txtIdVente.Text,out n)||n<0||n>99999) throw new ArgumentException("Identifiant invalide (0 à 99999)."); return n; }
  private int Quantite() { int n; if(!int.TryParse(txtQuantite.Text,out n)||n<=0||n>999999) throw new ArgumentException("Quantité invalide."); return n; }
  // Decimal.TryParse uses the current Windows culture's decimal separator.
  private decimal Prix() { decimal n; if(!decimal.TryParse(txtPrixUnitaire.Text,out n)||n<0||n>9999999999.99m) throw new ArgumentException("Prix invalide."); return n; }
  private string Produit() { string p=txtProduit.Text.Trim(); if(p.Length==0||p.Length>60) throw new ArgumentException("Produit obligatoire (60 caractères maximum)."); return p; }
  private void Resultat(int n) { MessageBox.Show(n==0?"Vente introuvable.":n+" ligne(s) modifiée(s)."); Afficher(remoteOperation.GetVentes()); }
  private void btnAfficher_Click(object s,EventArgs e) { Executer(()=>Afficher(remoteOperation.GetVentes())); }
  private void btnRechercher_Click(object s,EventArgs e) { Executer(()=>Afficher(remoteOperation.RechercherVente(Id()))); }
  private void btnAjouter_Click(object s,EventArgs e) { Executer(()=>Resultat(remoteOperation.AjouterVente(Id(),Produit(),Quantite(),Prix()))); }
  private void btnModifier_Click(object s,EventArgs e) { Executer(()=>Resultat(remoteOperation.ModifierVente(Id(),Produit(),Quantite(),Prix()))); }
  private void btnSupprimer_Click(object s,EventArgs e) { Executer(()=>Resultat(remoteOperation.SupprimerVente(Id()))); }
  // The calculated values come from Oracle on Machine 2; no SQL runs on the client.
  private void btnCalculerCA_Click(object s,EventArgs e) { Executer(()=>lblChiffreAffaires.Text="CA : "+remoteOperation.CalculerChiffreAffaires().ToString("N2")); }
  private void btnCalculerCAProduit_Click(object s,EventArgs e) { Executer(()=>{if(string.IsNullOrWhiteSpace(txtRechercheProduit.Text)) throw new ArgumentException("Produit de recherche obligatoire."); lblChiffreAffaires.Text="CA : "+remoteOperation.CalculerChiffreAffairesParProduit(txtRechercheProduit.Text.Trim()).ToString("N2");}); }
  private void btnCalculerQuantite_Click(object s,EventArgs e) { Executer(()=>lblQuantiteTotale.Text="Quantité : "+remoteOperation.CalculerQuantiteTotale()); }
 }
}
