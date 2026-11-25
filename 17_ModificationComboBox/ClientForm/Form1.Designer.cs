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
        private System.Windows.Forms.ComboBox cmbEnseignant;
        private System.Windows.Forms.TextBox txtMatricule, txtNom, txtPrenom, txtSpecialite;
        private System.Windows.Forms.Button btnCharger, btnAfficher, btnAjouter, btnModifier, btnSupprimer, btnRechercher, btnActualiser, btnNouveau;
        private System.Windows.Forms.Label lblSelection;
        private System.Windows.Forms.DataGridView dataGridView1;
        private void InitializeComponent()
        {
            this.cmbEnseignant = new System.Windows.Forms.ComboBox();
            this.txtMatricule = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtSpecialite = new System.Windows.Forms.TextBox();
            this.btnCharger = new System.Windows.Forms.Button();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.btnActualiser = new System.Windows.Forms.Button();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.lblSelection = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize) this.dataGridView1).BeginInit();
            this.SuspendLayout();
            this.txtMatricule.Location = new System.Drawing.Point(120, 15);
            this.txtNom.Location = new System.Drawing.Point(120, 48);
            this.txtPrenom.Location = new System.Drawing.Point(120, 81);
            this.txtSpecialite.Location = new System.Drawing.Point(120, 114);
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Matricule", Location = new System.Drawing.Point(15, 18) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Nom", Location = new System.Drawing.Point(15, 51) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Prénom", Location = new System.Drawing.Point(15, 84) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Spécialité", Location = new System.Drawing.Point(15, 117) });
            this.cmbEnseignant.Location = new System.Drawing.Point(320, 15);
            this.cmbEnseignant.Width = 260;
            this.cmbEnseignant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEnseignant.SelectionChangeCommitted += this.cmbEnseignant_SelectionChangeCommitted;
            this.btnCharger.Text = "Charger";
            this.btnCharger.Location = new System.Drawing.Point(590, 15);
            this.btnCharger.Click += this.btnCharger_Click;
            this.btnAfficher.Text = "Afficher";
            this.btnAfficher.Location = new System.Drawing.Point(15, 155);
            this.btnAfficher.Click += this.btnAfficher_Click;
            this.btnRechercher.Text = "Chercher ID";
            this.btnRechercher.Location = new System.Drawing.Point(140, 155);
            this.btnRechercher.Click += this.btnRechercher_Click;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Location = new System.Drawing.Point(265, 155);
            this.btnAjouter.Click += this.btnAjouter_Click;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.Location = new System.Drawing.Point(390, 155);
            this.btnModifier.Click += this.btnModifier_Click;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.Location = new System.Drawing.Point(515, 155);
            this.btnSupprimer.Click += this.btnSupprimer_Click;
            this.btnNouveau.Text = "Nouveau";
            this.btnNouveau.Location = new System.Drawing.Point(640, 155);
            this.btnNouveau.Click += this.btnNouveau_Click;
            this.btnActualiser.Text = "Actualiser";
            this.btnActualiser.Location = new System.Drawing.Point(320, 55);
            this.btnActualiser.Click += this.btnActualiser_Click;
            this.btnCharger.Size = this.btnAfficher.Size = this.btnRechercher.Size = this.btnAjouter.Size = this.btnModifier.Size = this.btnSupprimer.Size = this.btnNouveau.Size = this.btnActualiser.Size = new System.Drawing.Size(115, 30);
            this.lblSelection.Location = new System.Drawing.Point(320, 100);
            this.lblSelection.Size = new System.Drawing.Size(360, 25);
            this.dataGridView1.Location = new System.Drawing.Point(15, 200);
            this.dataGridView1.Size = new System.Drawing.Size(770, 340);
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.cmbEnseignant, this.txtMatricule, this.txtNom, this.txtPrenom, this.txtSpecialite, this.btnCharger, this.btnAfficher, this.btnAjouter, this.btnModifier, this.btnSupprimer, this.btnRechercher, this.btnActualiser, this.btnNouveau, this.lblSelection, this.dataGridView1 });
            this.Shown += this.Form1_Shown;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.MinimumSize = new System.Drawing.Size(800, 560);
            this.Text = "Modification ComboBox";
            ((System.ComponentModel.ISupportInitialize) this.dataGridView1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
