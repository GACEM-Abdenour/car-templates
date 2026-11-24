using System; using System.Data; using System.Runtime.Remoting.Channels; using System.Runtime.Remoting.Channels.Tcp; using System.Windows.Forms; using Interfaces;
namespace ClientForm { public partial class Form1:Form {
 private IRemoteOperation remoteOperation;
 public Form1(){InitializeComponent();try{ChannelServices.RegisterChannel(new TcpChannel(),false); // MACHINE 1: replace localhost by Machine 2 IP.
 remoteOperation=(IRemoteOperation)Activator.GetObject(typeof(IRemoteOperation),"tcp://localhost:1069/RemoteOperation");}catch(Exception ex){MessageBox.Show("Connexion : "+ex.Message);}}
 private void Executer(Action a){try{a();}catch(Exception ex){MessageBox.Show("Erreur : "+ex.Message);}}
 private int Id(){int n;if(!int.TryParse(txtIdProduit.Text,out n)||n<0||n>99999)throw new ArgumentException("Identifiant invalide.");return n;}
 private int Quantite(){int n;if(!int.TryParse(txtQuantite.Text,out n)||n<0||n>999999)throw new ArgumentException("Quantité invalide.");return n;}
 private string Texte(TextBox t,int max){string v=t.Text.Trim();if(v.Length==0||v.Length>max)throw new ArgumentException("Champ obligatoire ou trop long.");return v;}
 private void Afficher(DataSet ds){if(ds==null||ds.Tables.Count==0)throw new InvalidOperationException("Aucune table reçue.");dataGridView1.DataSource=ds.Tables[0].DefaultView;if(ds.Tables[0].Rows.Count==0)MessageBox.Show("Aucun résultat.");}
 private void Resultat(int n){lblResultat.Text=n+" ligne(s) modifiée(s).";Afficher(remoteOperation.GetProduits());}
 private bool Confirmer(string message){return MessageBox.Show(message,"Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes;}
 private void btnAfficher_Click(object s,EventArgs e){Executer(()=>Afficher(remoteOperation.GetProduits()));}
 private void btnRechercher_Click(object s,EventArgs e){Executer(()=>Afficher(remoteOperation.RechercherProduit(Id())));}
 private void btnAjouter_Click(object s,EventArgs e){Executer(()=>Resultat(remoteOperation.AjouterProduit(Id(),Texte(txtDesignation,60),Texte(txtCategorie,40),Quantite())));}
 private void btnModifier_Click(object s,EventArgs e){Executer(()=>Resultat(remoteOperation.ModifierProduit(Id(),Texte(txtDesignation,60),Texte(txtCategorie,40),Quantite())));}
 private void btnAfficherEpuises_Click(object s,EventArgs e){Executer(()=>Afficher(remoteOperation.GetProduitsEpuises()));}
 // TRICK 14: confirmation protects against mistakes; server SQL independently enforces stock=0.
 private void btnSupprimer_Click(object s,EventArgs e){Executer(()=>{int id=Id();if(!Confirmer("Supprimer ce produit si son stock est nul ?"))return;int n=remoteOperation.SupprimerProduitSiStockNul(id);lblResultat.Text=n==0?"Aucun produit supprimé : introuvable ou stock non nul.":"1 produit supprimé.";Afficher(remoteOperation.GetProduits());});}
 private void btnSupprimerTousEpuises_Click(object s,EventArgs e){if(!Confirmer("Supprimer tous les produits dont le stock est nul ?"))return;Executer(()=>Resultat(remoteOperation.SupprimerProduitsEpuises()));}
 private void btnSupprimerEpuisesCategorie_Click(object s,EventArgs e){Executer(()=>{string cat=Texte(txtCategorie,40);if(!Confirmer("Supprimer les produits épuisés de cette catégorie ?"))return;Resultat(remoteOperation.SupprimerProduitsEpuisesParCategorie(cat));});}
} }
