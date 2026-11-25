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
        private System.Windows.Forms.TextBox txtMatricule, txtNom, txtPrenom, txtEmail;
        private System.Windows.Forms.Button btnAfficher, btnAjouter, btnModifier, btnSupprimer, btnRechercher, btnRechercherEmail, btnVerifierMatricule, btnVerifierEmail;
        private System.Windows.Forms.Label lblResultat;
        private System.Windows.Forms.DataGridView dataGridView1;
        private void InitializeComponent()
        {
            this.txtMatricule = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.btnRechercherEmail = new System.Windows.Forms.Button();
            this.btnVerifierMatricule = new System.Windows.Forms.Button();
            this.btnVerifierEmail = new System.Windows.Forms.Button();
            this.lblResultat = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize) this.dataGridView1).BeginInit();
            this.SuspendLayout();
            this.txtMatricule.Location = new System.Drawing.Point(125, 15);
            this.txtNom.Location = new System.Drawing.Point(125, 48);
            this.txtPrenom.Location = new System.Drawing.Point(125, 81);
            this.txtEmail.Location = new System.Drawing.Point(125, 114);
            this.txtEmail.Width = 240;
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Matricule", Location = new System.Drawing.Point(15, 18) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Nom", Location = new System.Drawing.Point(15, 51) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Prénom", Location = new System.Drawing.Point(15, 84) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Email", Location = new System.Drawing.Point(15, 117) });
            this.btnAfficher.Text = "Afficher";
            this.btnAfficher.Location = new System.Drawing.Point(15, 155);
            this.btnAfficher.Click += this.btnAfficher_Click;
            this.btnRechercher.Text = "Chercher ID";
            this.btnRechercher.Location = new System.Drawing.Point(145, 155);
            this.btnRechercher.Click += this.btnRechercher_Click;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Location = new System.Drawing.Point(275, 155);
            this.btnAjouter.Click += this.btnAjouter_Click;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.Location = new System.Drawing.Point(405, 155);
            this.btnModifier.Click += this.btnModifier_Click;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.Location = new System.Drawing.Point(535, 155);
            this.btnSupprimer.Click += this.btnSupprimer_Click;
            this.btnRechercherEmail.Text = "Chercher email";
            this.btnRechercherEmail.Location = new System.Drawing.Point(15, 195);
            this.btnRechercherEmail.Click += this.btnRechercherEmail_Click;
            this.btnVerifierMatricule.Text = "Vérifier ID";
            this.btnVerifierMatricule.Location = new System.Drawing.Point(145, 195);
            this.btnVerifierMatricule.Click += this.btnVerifierMatricule_Click;
            this.btnVerifierEmail.Text = "Vérifier email";
            this.btnVerifierEmail.Location = new System.Drawing.Point(275, 195);
            this.btnVerifierEmail.Click += this.btnVerifierEmail_Click;
            this.btnAfficher.Size = this.btnRechercher.Size = this.btnAjouter.Size = this.btnModifier.Size = this.btnSupprimer.Size = this.btnRechercherEmail.Size = this.btnVerifierMatricule.Size = this.btnVerifierEmail.Size = new System.Drawing.Size(120, 30);
            this.lblResultat.Location = new System.Drawing.Point(420, 200);
            this.lblResultat.Size = new System.Drawing.Size(350, 25);
            this.dataGridView1.Location = new System.Drawing.Point(15, 240);
            this.dataGridView1.Size = new System.Drawing.Size(770, 300);
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.txtMatricule, this.txtNom, this.txtPrenom, this.txtEmail, this.btnAfficher, this.btnAjouter, this.btnModifier, this.btnSupprimer, this.btnRechercher, this.btnRechercherEmail, this.btnVerifierMatricule, this.btnVerifierEmail, this.lblResultat, this.dataGridView1 });
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.MinimumSize = new System.Drawing.Size(800, 560);
            this.Text = "Gestion des doublons";
            ((System.ComponentModel.ISupportInitialize) this.dataGridView1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
