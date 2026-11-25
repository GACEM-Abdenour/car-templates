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
        private System.Windows.Forms.TextBox txtMatricule, txtNom, txtPrenom, txtDepartement, txtSalaire;
        private System.Windows.Forms.ComboBox cmbDepartement;
        private System.Windows.Forms.Button btnAfficher, btnRechercher, btnAjouter, btnModifier, btnSupprimer, btnFiltrer, btnReinitialiser;
        private System.Windows.Forms.DataGridView dataGridView1;
        private void InitializeComponent()
        {
            this.txtMatricule = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtDepartement = new System.Windows.Forms.TextBox();
            this.txtSalaire = new System.Windows.Forms.TextBox();
            this.cmbDepartement = new System.Windows.Forms.ComboBox();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnFiltrer = new System.Windows.Forms.Button();
            this.btnReinitialiser = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            this.txtMatricule.Location = new System.Drawing.Point(120, 15);
            this.txtNom.Location = new System.Drawing.Point(120, 48);
            this.txtPrenom.Location = new System.Drawing.Point(120, 81);
            this.txtDepartement.Location = new System.Drawing.Point(120, 114);
            this.txtSalaire.Location = new System.Drawing.Point(120, 147);
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Matricule", Location = new System.Drawing.Point(15, 18) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Nom", Location = new System.Drawing.Point(15, 51) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Prénom", Location = new System.Drawing.Point(15, 84) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Département", Location = new System.Drawing.Point(15, 117) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Salaire", Location = new System.Drawing.Point(15, 150) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Département", Location = new System.Drawing.Point(310, 18) });
            this.cmbDepartement.Location = new System.Drawing.Point(420, 15);
            this.cmbDepartement.Size = new System.Drawing.Size(170, 25);
            this.cmbDepartement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartement.SelectedIndexChanged += this.cmbDepartement_SelectedIndexChanged;
            this.btnFiltrer.Text = "Filtrer";
            this.btnFiltrer.Location = new System.Drawing.Point(310, 55);
            this.btnFiltrer.Click += this.btnFiltrer_Click;
            this.btnReinitialiser.Text = "Tous";
            this.btnReinitialiser.Location = new System.Drawing.Point(440, 55);
            this.btnReinitialiser.Click += this.btnReinitialiser_Click;
            this.btnAfficher.Text = "Afficher";
            this.btnAfficher.Location = new System.Drawing.Point(15, 195);
            this.btnAfficher.Click += this.btnAfficher_Click;
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.Location = new System.Drawing.Point(145, 195);
            this.btnRechercher.Click += this.btnRechercher_Click;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Location = new System.Drawing.Point(275, 195);
            this.btnAjouter.Click += this.btnAjouter_Click;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.Location = new System.Drawing.Point(405, 195);
            this.btnModifier.Click += this.btnModifier_Click;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.Location = new System.Drawing.Point(535, 195);
            this.btnSupprimer.Click += this.btnSupprimer_Click;
            this.btnAfficher.Size = this.btnRechercher.Size = this.btnAjouter.Size = this.btnModifier.Size = this.btnSupprimer.Size = this.btnFiltrer.Size = this.btnReinitialiser.Size = new System.Drawing.Size(120, 30);
            this.dataGridView1.Location = new System.Drawing.Point(15, 240);
            this.dataGridView1.Size = new System.Drawing.Size(770, 300);
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.txtMatricule, this.txtNom, this.txtPrenom, this.txtDepartement, this.txtSalaire, this.cmbDepartement, this.btnAfficher, this.btnRechercher, this.btnAjouter, this.btnModifier, this.btnSupprimer, this.btnFiltrer, this.btnReinitialiser, this.dataGridView1 });
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.MinimumSize = new System.Drawing.Size(800, 560);
            this.Text = "Filtrage par département";
            this.Shown += this.Form1_Shown;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
