namespace ClientForm
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private System.Windows.Forms.TextBox txtMatricule, txtNom, txtPrenom, txtNote, txtNoteMin, txtNoteMax;
        private System.Windows.Forms.Button btnAfficher, btnAjouter, btnModifier, btnSupprimer, btnRechercher, btnAfficherAdmis, btnAfficherAjournes, btnRechercherNoteMin, btnRechercherIntervalle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblMatricule, lblNom, lblPrenom, lblNote, lblNoteMin, lblNoteMax;

        private void InitializeComponent()
        {
            this.txtMatricule = new System.Windows.Forms.TextBox(); this.txtNom = new System.Windows.Forms.TextBox(); this.txtPrenom = new System.Windows.Forms.TextBox(); this.txtNote = new System.Windows.Forms.TextBox(); this.txtNoteMin = new System.Windows.Forms.TextBox(); this.txtNoteMax = new System.Windows.Forms.TextBox();
            this.lblMatricule = new System.Windows.Forms.Label(); this.lblNom = new System.Windows.Forms.Label(); this.lblPrenom = new System.Windows.Forms.Label(); this.lblNote = new System.Windows.Forms.Label(); this.lblNoteMin = new System.Windows.Forms.Label(); this.lblNoteMax = new System.Windows.Forms.Label();
            this.btnAfficher = new System.Windows.Forms.Button(); this.btnAjouter = new System.Windows.Forms.Button(); this.btnModifier = new System.Windows.Forms.Button(); this.btnSupprimer = new System.Windows.Forms.Button(); this.btnRechercher = new System.Windows.Forms.Button(); this.btnAfficherAdmis = new System.Windows.Forms.Button(); this.btnAfficherAjournes = new System.Windows.Forms.Button(); this.btnRechercherNoteMin = new System.Windows.Forms.Button(); this.btnRechercherIntervalle = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit(); this.SuspendLayout();
            this.lblMatricule.Text="Matricule"; this.lblMatricule.Location=new System.Drawing.Point(15,18); this.txtMatricule.Location=new System.Drawing.Point(110,15);
            this.lblNom.Text="Nom"; this.lblNom.Location=new System.Drawing.Point(15,52); this.txtNom.Location=new System.Drawing.Point(110,49);
            this.lblPrenom.Text="Prénom"; this.lblPrenom.Location=new System.Drawing.Point(15,86); this.txtPrenom.Location=new System.Drawing.Point(110,83);
            this.lblNote.Text="Note"; this.lblNote.Location=new System.Drawing.Point(15,120); this.txtNote.Location=new System.Drawing.Point(110,117);
            this.lblNoteMin.Text="Note minimum"; this.lblNoteMin.Location=new System.Drawing.Point(265,18); this.txtNoteMin.Location=new System.Drawing.Point(370,15);
            this.lblNoteMax.Text="Note maximum"; this.lblNoteMax.Location=new System.Drawing.Point(265,52); this.txtNoteMax.Location=new System.Drawing.Point(370,49);
            this.btnAfficher.Text="Afficher"; this.btnAfficher.Location=new System.Drawing.Point(15,160); this.btnAfficher.Click+=new System.EventHandler(this.btnAfficher_Click);
            this.btnAjouter.Text="Ajouter"; this.btnAjouter.Location=new System.Drawing.Point(150,160); this.btnAjouter.Click+=new System.EventHandler(this.btnAjouter_Click);
            this.btnModifier.Text="Modifier"; this.btnModifier.Location=new System.Drawing.Point(285,160); this.btnModifier.Click+=new System.EventHandler(this.btnModifier_Click);
            this.btnSupprimer.Text="Supprimer"; this.btnSupprimer.Location=new System.Drawing.Point(420,160); this.btnSupprimer.Click+=new System.EventHandler(this.btnSupprimer_Click);
            this.btnRechercher.Text="Chercher matricule"; this.btnRechercher.Location=new System.Drawing.Point(555,160); this.btnRechercher.Click+=new System.EventHandler(this.btnRechercher_Click);
            this.btnAfficherAdmis.Text="Admis"; this.btnAfficherAdmis.Location=new System.Drawing.Point(15,200); this.btnAfficherAdmis.Click+=new System.EventHandler(this.btnAfficherAdmis_Click);
            this.btnAfficherAjournes.Text="Ajournés"; this.btnAfficherAjournes.Location=new System.Drawing.Point(150,200); this.btnAfficherAjournes.Click+=new System.EventHandler(this.btnAfficherAjournes_Click);
            this.btnRechercherNoteMin.Text="Note minimum"; this.btnRechercherNoteMin.Location=new System.Drawing.Point(285,200); this.btnRechercherNoteMin.Click+=new System.EventHandler(this.btnRechercherNoteMin_Click);
            this.btnRechercherIntervalle.Text="Entre deux notes"; this.btnRechercherIntervalle.Location=new System.Drawing.Point(420,200); this.btnRechercherIntervalle.Click+=new System.EventHandler(this.btnRechercherIntervalle_Click);
            this.btnAfficher.Size=this.btnAjouter.Size=this.btnModifier.Size=this.btnSupprimer.Size=this.btnRechercher.Size=this.btnAfficherAdmis.Size=this.btnAfficherAjournes.Size=this.btnRechercherNoteMin.Size=this.btnRechercherIntervalle.Size=new System.Drawing.Size(125,30);
            this.dataGridView1.Location=new System.Drawing.Point(15,245); this.dataGridView1.Size=new System.Drawing.Size(790,300); this.dataGridView1.Anchor=System.Windows.Forms.AnchorStyles.Top|System.Windows.Forms.AnchorStyles.Bottom|System.Windows.Forms.AnchorStyles.Left|System.Windows.Forms.AnchorStyles.Right; this.dataGridView1.ReadOnly=true; this.dataGridView1.AutoSizeColumnsMode=System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ClientSize=new System.Drawing.Size(820,560); this.MinimumSize=new System.Drawing.Size(820,560); this.Text="Gestion des notes";
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.lblMatricule,this.lblNom,this.lblPrenom,this.lblNote,this.lblNoteMin,this.lblNoteMax,this.txtMatricule,this.txtNom,this.txtPrenom,this.txtNote,this.txtNoteMin,this.txtNoteMax,this.btnAfficher,this.btnAjouter,this.btnModifier,this.btnSupprimer,this.btnRechercher,this.btnAfficherAdmis,this.btnAfficherAjournes,this.btnRechercherNoteMin,this.btnRechercherIntervalle,this.dataGridView1 });
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit(); this.ResumeLayout(false); this.PerformLayout();
        }
    }
}
