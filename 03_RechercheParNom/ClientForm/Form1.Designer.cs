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
            this.txtMatricule = new System.Windows.Forms.TextBox();
            this.txtMatricule.Name = "txtMatricule";
            this.txtMatricule.Location = new System.Drawing.Point(15, 15);
            this.txtMatricule.Size = new System.Drawing.Size(130, 30);
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtNom.Name = "txtNom";
            this.txtNom.Location = new System.Drawing.Point(15, 53);
            this.txtNom.Size = new System.Drawing.Size(130, 30);
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Location = new System.Drawing.Point(15, 91);
            this.txtPrenom.Size = new System.Drawing.Size(130, 30);
            this.btnRechercherNom = new System.Windows.Forms.Button();
            this.btnRechercherNom.Name = "btnRechercherNom";
            this.btnRechercherNom.Location = new System.Drawing.Point(15, 129);
            this.btnRechercherNom.Size = new System.Drawing.Size(130, 30);
            this.btnRechercherNom.Text = "RechercherNom";
            this.btnRechercherNom.Click += new System.EventHandler(this.btnRechercherNom_Click);
            this.btnRechercherPrenom = new System.Windows.Forms.Button();
            this.btnRechercherPrenom.Name = "btnRechercherPrenom";
            this.btnRechercherPrenom.Location = new System.Drawing.Point(15, 167);
            this.btnRechercherPrenom.Size = new System.Drawing.Size(130, 30);
            this.btnRechercherPrenom.Text = "RechercherPrenom";
            this.btnRechercherPrenom.Click += new System.EventHandler(this.btnRechercherPrenom_Click);
            this.btnAfficher = new System.Windows.Forms.Button();
            this.btnAfficher.Name = "btnAfficher";
            this.btnAfficher.Location = new System.Drawing.Point(15, 205);
            this.btnAfficher.Size = new System.Drawing.Size(130, 30);
            this.btnAfficher.Text = "Afficher";
            this.btnAfficher.Click += new System.EventHandler(this.btnAfficher_Click);
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Location = new System.Drawing.Point(15, 243);
            this.btnAjouter.Size = new System.Drawing.Size(130, 30);
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Location = new System.Drawing.Point(15, 281);
            this.btnModifier.Size = new System.Drawing.Size(130, 30);
            this.btnModifier.Text = "Modifier";
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Location = new System.Drawing.Point(15, 319);
            this.btnSupprimer.Size = new System.Drawing.Size(130, 30);
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            this.btnRechercher = new System.Windows.Forms.Button();
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Location = new System.Drawing.Point(15, 357);
            this.btnRechercher.Size = new System.Drawing.Size(130, 30);
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Location = new System.Drawing.Point(15, 395);
            this.dataGridView1.Size = new System.Drawing.Size(850, 300);
            this.Controls.Add(this.txtMatricule);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.btnRechercherNom);
            this.Controls.Add(this.btnRechercherPrenom);
            this.Controls.Add(this.btnAfficher);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnRechercher);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Matricule", Location = new System.Drawing.Point(155, 18), AutoSize = true });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Nom", Location = new System.Drawing.Point(155, 56), AutoSize = true });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Prénom", Location = new System.Drawing.Point(155, 94), AutoSize = true });
            this.btnRechercherPrenom.Width = 150;
            this.dataGridView1.Size = new System.Drawing.Size(850, 290);
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView1.ReadOnly = true;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Text = "Recherche par nom";
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.TextBox txtMatricule;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.Button btnRechercherNom;
        private System.Windows.Forms.Button btnRechercherPrenom;
        private System.Windows.Forms.Button btnAfficher;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
