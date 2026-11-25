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
        private System.Windows.Forms.TextBox txtMatricule, txtNom, txtPrenom;
        private System.Windows.Forms.Button btnAfficher, btnAjouter, btnModifier, btnSupprimer, btnRechercher, btnNouveau;
        private System.Windows.Forms.Label lblSelection;
        private System.Windows.Forms.DataGridView dataGridView1;
        private void InitializeComponent()
        {
            this.txtMatricule = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.lblSelection = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize) this.dataGridView1).BeginInit();
            this.SuspendLayout();
            this.txtMatricule.Location = new System.Drawing.Point(120, 15);
            this.txtNom.Location = new System.Drawing.Point(120, 48);
            this.txtPrenom.Location = new System.Drawing.Point(120, 81);
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Matricule", Location = new System.Drawing.Point(15, 18) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Nom", Location = new System.Drawing.Point(15, 51) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Prénom", Location = new System.Drawing.Point(15, 84) });
            this.btnAfficher.Text = "Afficher";
            this.btnAfficher.Location = new System.Drawing.Point(15, 130);
            this.btnAfficher.Click += this.btnAfficher_Click;
            this.btnRechercher.Text = "Chercher ID";
            this.btnRechercher.Location = new System.Drawing.Point(140, 130);
            this.btnRechercher.Click += this.btnRechercher_Click;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Location = new System.Drawing.Point(265, 130);
            this.btnAjouter.Click += this.btnAjouter_Click;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.Location = new System.Drawing.Point(390, 130);
            this.btnModifier.Click += this.btnModifier_Click;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.Location = new System.Drawing.Point(515, 130);
            this.btnSupprimer.Click += this.btnSupprimer_Click;
            this.btnNouveau.Text = "Nouveau";
            this.btnNouveau.Location = new System.Drawing.Point(640, 130);
            this.btnNouveau.Click += this.btnNouveau_Click;
            this.btnAfficher.Size = this.btnRechercher.Size = this.btnAjouter.Size = this.btnModifier.Size = this.btnSupprimer.Size = this.btnNouveau.Size = new System.Drawing.Size(115, 30);
            this.lblSelection.Text = "Aucune sélection.";
            this.lblSelection.Location = new System.Drawing.Point(15, 170);
            this.lblSelection.Size = new System.Drawing.Size(400, 25);
            this.dataGridView1.Location = new System.Drawing.Point(15, 200);
            this.dataGridView1.Size = new System.Drawing.Size(770, 340);
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CellClick += this.dataGridView1_CellClick;
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.txtMatricule, this.txtNom, this.txtPrenom, this.btnAfficher, this.btnRechercher, this.btnAjouter, this.btnModifier, this.btnSupprimer, this.btnNouveau, this.lblSelection, this.dataGridView1 });
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.MinimumSize = new System.Drawing.Size(800, 560);
            this.Text = "Sélection DataGridView";
            ((System.ComponentModel.ISupportInitialize) this.dataGridView1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
