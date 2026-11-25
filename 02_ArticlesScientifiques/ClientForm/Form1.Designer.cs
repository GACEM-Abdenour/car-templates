namespace ClientForm
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.txtIdArticle = new System.Windows.Forms.TextBox();
            this.txtIdArticle.Name = "txtIdArticle";
            this.txtIdArticle.Location = new System.Drawing.Point(15, 15);
            this.txtIdArticle.Size = new System.Drawing.Size(130, 30);
            this.txtTitre = new System.Windows.Forms.TextBox();
            this.txtTitre.Name = "txtTitre";
            this.txtTitre.Location = new System.Drawing.Point(15, 53);
            this.txtTitre.Size = new System.Drawing.Size(130, 30);
            this.txtAuteur = new System.Windows.Forms.TextBox();
            this.txtAuteur.Name = "txtAuteur";
            this.txtAuteur.Location = new System.Drawing.Point(15, 91);
            this.txtAuteur.Size = new System.Drawing.Size(130, 30);
            this.txtRevue = new System.Windows.Forms.TextBox();
            this.txtRevue.Name = "txtRevue";
            this.txtRevue.Location = new System.Drawing.Point(15, 129);
            this.txtRevue.Size = new System.Drawing.Size(130, 30);
            this.txtAnneePublication = new System.Windows.Forms.TextBox();
            this.txtAnneePublication.Name = "txtAnneePublication";
            this.txtAnneePublication.Location = new System.Drawing.Point(15, 167);
            this.txtAnneePublication.Size = new System.Drawing.Size(130, 30);
            this.txtDOI = new System.Windows.Forms.TextBox();
            this.txtDOI.Name = "txtDOI";
            this.txtDOI.Location = new System.Drawing.Point(15, 205);
            this.txtDOI.Size = new System.Drawing.Size(130, 30);
            this.btnAfficher = new System.Windows.Forms.Button();
            this.btnAfficher.Name = "btnAfficher";
            this.btnAfficher.Location = new System.Drawing.Point(15, 243);
            this.btnAfficher.Size = new System.Drawing.Size(130, 30);
            this.btnAfficher.Text = "Afficher";
            this.btnAfficher.Click += new System.EventHandler(this.btnAfficher_Click);
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Location = new System.Drawing.Point(15, 281);
            this.btnAjouter.Size = new System.Drawing.Size(130, 30);
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Location = new System.Drawing.Point(15, 319);
            this.btnModifier.Size = new System.Drawing.Size(130, 30);
            this.btnModifier.Text = "Modifier";
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Location = new System.Drawing.Point(15, 357);
            this.btnSupprimer.Size = new System.Drawing.Size(130, 30);
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            this.btnRechercher = new System.Windows.Forms.Button();
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Location = new System.Drawing.Point(15, 395);
            this.btnRechercher.Size = new System.Drawing.Size(130, 30);
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            this.btnRechercherDOI = new System.Windows.Forms.Button();
            this.btnRechercherDOI.Name = "btnRechercherDOI";
            this.btnRechercherDOI.Location = new System.Drawing.Point(15, 433);
            this.btnRechercherDOI.Size = new System.Drawing.Size(130, 30);
            this.btnRechercherDOI.Text = "RechercherDOI";
            this.btnRechercherDOI.Click += new System.EventHandler(this.btnRechercherDOI_Click);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Location = new System.Drawing.Point(15, 471);
            this.dataGridView1.Size = new System.Drawing.Size(850, 300);
            this.Controls.Add(this.txtIdArticle);
            this.Controls.Add(this.txtTitre);
            this.Controls.Add(this.txtAuteur);
            this.Controls.Add(this.txtRevue);
            this.Controls.Add(this.txtAnneePublication);
            this.Controls.Add(this.txtDOI);
            this.Controls.Add(this.btnAfficher);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnRechercher);
            this.Controls.Add(this.btnRechercherDOI);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Identifiant", Location = new System.Drawing.Point(155, 18), AutoSize = true });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Titre", Location = new System.Drawing.Point(155, 56), AutoSize = true });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Auteur", Location = new System.Drawing.Point(155, 94), AutoSize = true });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Revue (facultative)", Location = new System.Drawing.Point(155, 132), AutoSize = true });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Année", Location = new System.Drawing.Point(155, 170), AutoSize = true });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "DOI", Location = new System.Drawing.Point(155, 208), AutoSize = true });
            this.dataGridView1.Location = new System.Drawing.Point(15, 480);
            this.dataGridView1.Size = new System.Drawing.Size(850, 200);
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView1.ReadOnly = true;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Text = "Gestion des articles scientifiques";
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.TextBox txtIdArticle;
        private System.Windows.Forms.TextBox txtTitre;
        private System.Windows.Forms.TextBox txtAuteur;
        private System.Windows.Forms.TextBox txtRevue;
        private System.Windows.Forms.TextBox txtAnneePublication;
        private System.Windows.Forms.TextBox txtDOI;
        private System.Windows.Forms.Button btnAfficher;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.Button btnRechercherDOI;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
