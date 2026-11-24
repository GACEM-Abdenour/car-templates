namespace ClientForm {
 partial class Form1 {
  private System.ComponentModel.IContainer components=null;
  protected override void Dispose(bool disposing) { if(disposing && components!=null) components.Dispose(); base.Dispose(disposing); }
  private System.Windows.Forms.TextBox txtMatricule,txtNom,txtPrenom,txtNote;
  private System.Windows.Forms.Button btnAfficher,btnRechercher,btnAjouter,btnModifier,btnSupprimer,btnCalculerMoyenne,btnNoteMinimale,btnNoteMaximale,btnCompterAdmis,btnCompterAjournes,btnStatistiques;
  private System.Windows.Forms.Label lblMoyenne,lblNoteMinimale,lblNoteMaximale,lblAdmis,lblAjournes;
  private System.Windows.Forms.DataGridView dataGridView1;
  private void InitializeComponent() {
   this.txtMatricule=new System.Windows.Forms.TextBox(); this.txtNom=new System.Windows.Forms.TextBox(); this.txtPrenom=new System.Windows.Forms.TextBox(); this.txtNote=new System.Windows.Forms.TextBox();
   this.btnAfficher=new System.Windows.Forms.Button(); this.btnRechercher=new System.Windows.Forms.Button(); this.btnAjouter=new System.Windows.Forms.Button(); this.btnModifier=new System.Windows.Forms.Button(); this.btnSupprimer=new System.Windows.Forms.Button(); this.btnCalculerMoyenne=new System.Windows.Forms.Button(); this.btnNoteMinimale=new System.Windows.Forms.Button(); this.btnNoteMaximale=new System.Windows.Forms.Button(); this.btnCompterAdmis=new System.Windows.Forms.Button(); this.btnCompterAjournes=new System.Windows.Forms.Button(); this.btnStatistiques=new System.Windows.Forms.Button();
   this.lblMoyenne=new System.Windows.Forms.Label(); this.lblNoteMinimale=new System.Windows.Forms.Label(); this.lblNoteMaximale=new System.Windows.Forms.Label(); this.lblAdmis=new System.Windows.Forms.Label(); this.lblAjournes=new System.Windows.Forms.Label(); this.dataGridView1=new System.Windows.Forms.DataGridView();
   ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit(); this.SuspendLayout();
   this.txtMatricule.Location=new System.Drawing.Point(115,15); this.txtNom.Location=new System.Drawing.Point(115,48); this.txtPrenom.Location=new System.Drawing.Point(115,81); this.txtNote.Location=new System.Drawing.Point(115,114);
   this.Controls.Add(new System.Windows.Forms.Label {Text="Matricule",Location=new System.Drawing.Point(15,18)}); this.Controls.Add(new System.Windows.Forms.Label {Text="Nom",Location=new System.Drawing.Point(15,51)}); this.Controls.Add(new System.Windows.Forms.Label {Text="Prénom",Location=new System.Drawing.Point(15,84)}); this.Controls.Add(new System.Windows.Forms.Label {Text="Note",Location=new System.Drawing.Point(15,117)});
   this.btnAfficher.Text="Afficher"; this.btnAfficher.Location=new System.Drawing.Point(15,155); this.btnAfficher.Click+=this.btnAfficher_Click;
   this.btnRechercher.Text="Rechercher"; this.btnRechercher.Location=new System.Drawing.Point(140,155); this.btnRechercher.Click+=this.btnRechercher_Click;
   this.btnAjouter.Text="Ajouter"; this.btnAjouter.Location=new System.Drawing.Point(265,155); this.btnAjouter.Click+=this.btnAjouter_Click;
   this.btnModifier.Text="Modifier"; this.btnModifier.Location=new System.Drawing.Point(390,155); this.btnModifier.Click+=this.btnModifier_Click;
   this.btnSupprimer.Text="Supprimer"; this.btnSupprimer.Location=new System.Drawing.Point(515,155); this.btnSupprimer.Click+=this.btnSupprimer_Click;
   this.btnCalculerMoyenne.Text="Moyenne"; this.btnCalculerMoyenne.Location=new System.Drawing.Point(15,195); this.btnCalculerMoyenne.Click+=this.btnCalculerMoyenne_Click;
   this.btnNoteMinimale.Text="Minimum"; this.btnNoteMinimale.Location=new System.Drawing.Point(140,195); this.btnNoteMinimale.Click+=this.btnNoteMinimale_Click;
   this.btnNoteMaximale.Text="Maximum"; this.btnNoteMaximale.Location=new System.Drawing.Point(265,195); this.btnNoteMaximale.Click+=this.btnNoteMaximale_Click;
   this.btnCompterAdmis.Text="Compter admis"; this.btnCompterAdmis.Location=new System.Drawing.Point(390,195); this.btnCompterAdmis.Click+=this.btnCompterAdmis_Click;
   this.btnCompterAjournes.Text="Compter ajournés"; this.btnCompterAjournes.Location=new System.Drawing.Point(515,195); this.btnCompterAjournes.Click+=this.btnCompterAjournes_Click;
   this.btnStatistiques.Text="Statistiques"; this.btnStatistiques.Location=new System.Drawing.Point(640,195); this.btnStatistiques.Click+=this.btnStatistiques_Click;
   this.btnAfficher.Size=this.btnRechercher.Size=this.btnAjouter.Size=this.btnModifier.Size=this.btnSupprimer.Size=this.btnCalculerMoyenne.Size=this.btnNoteMinimale.Size=this.btnNoteMaximale.Size=this.btnCompterAdmis.Size=this.btnCompterAjournes.Size=this.btnStatistiques.Size=new System.Drawing.Size(115,30);
   this.lblMoyenne.Text="Moyenne : —"; this.lblMoyenne.Location=new System.Drawing.Point(15,238); this.lblNoteMinimale.Text="Minimum : —"; this.lblNoteMinimale.Location=new System.Drawing.Point(170,238); this.lblNoteMaximale.Text="Maximum : —"; this.lblNoteMaximale.Location=new System.Drawing.Point(325,238); this.lblAdmis.Text="Admis : —"; this.lblAdmis.Location=new System.Drawing.Point(480,238); this.lblAjournes.Text="Ajournés : —"; this.lblAjournes.Location=new System.Drawing.Point(635,238);
   this.lblMoyenne.Width=this.lblNoteMinimale.Width=this.lblNoteMaximale.Width=this.lblAdmis.Width=this.lblAjournes.Width=150;
   this.dataGridView1.Location=new System.Drawing.Point(15,270); this.dataGridView1.Size=new System.Drawing.Size(770,270); this.dataGridView1.Anchor=System.Windows.Forms.AnchorStyles.Top|System.Windows.Forms.AnchorStyles.Bottom|System.Windows.Forms.AnchorStyles.Left|System.Windows.Forms.AnchorStyles.Right; this.dataGridView1.ReadOnly=true; this.dataGridView1.AutoSizeColumnsMode=System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
   this.Controls.AddRange(new System.Windows.Forms.Control[]{this.txtMatricule,this.txtNom,this.txtPrenom,this.txtNote,this.btnAfficher,this.btnRechercher,this.btnAjouter,this.btnModifier,this.btnSupprimer,this.btnCalculerMoyenne,this.btnNoteMinimale,this.btnNoteMaximale,this.btnCompterAdmis,this.btnCompterAjournes,this.btnStatistiques,this.lblMoyenne,this.lblNoteMinimale,this.lblNoteMaximale,this.lblAdmis,this.lblAjournes,this.dataGridView1});
   this.ClientSize=new System.Drawing.Size(800,560); this.MinimumSize=new System.Drawing.Size(800,560); this.Text="Statistiques des notes"; ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit(); this.ResumeLayout(false); this.PerformLayout();
  }
 }
}
