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
            this.txtCodeBarre = new System.Windows.Forms.TextBox();
            this.txtCodeBarre.Name = "txtCodeBarre";
            this.txtCodeBarre.Location = new System.Drawing.Point(15, 15);
            this.txtCodeBarre.Size = new System.Drawing.Size(130, 30);
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Location = new System.Drawing.Point(15, 53);
            this.txtDesignation.Size = new System.Drawing.Size(130, 30);
            this.txtQuantite = new System.Windows.Forms.TextBox();
            this.txtQuantite.Name = "txtQuantite";
            this.txtQuantite.Location = new System.Drawing.Point(15, 91);
            this.txtQuantite.Size = new System.Drawing.Size(130, 30);
            this.txtPrix = new System.Windows.Forms.TextBox();
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Location = new System.Drawing.Point(15, 129);
            this.txtPrix.Size = new System.Drawing.Size(130, 30);
            this.btnAfficher = new System.Windows.Forms.Button();
            this.btnAfficher.Name = "btnAfficher";
            this.btnAfficher.Location = new System.Drawing.Point(15, 167);
            this.btnAfficher.Size = new System.Drawing.Size(130, 30);
            this.btnAfficher.Text = "Afficher";
            this.btnAfficher.Click += new System.EventHandler(this.btnAfficher_Click);
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Location = new System.Drawing.Point(15, 205);
            this.btnAjouter.Size = new System.Drawing.Size(130, 30);
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            this.btnRechercher = new System.Windows.Forms.Button();
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Location = new System.Drawing.Point(15, 243);
            this.btnRechercher.Size = new System.Drawing.Size(130, 30);
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Location = new System.Drawing.Point(15, 357);
            this.dataGridView1.Size = new System.Drawing.Size(850, 300);
            this.Controls.Add(this.txtCodeBarre);
            this.Controls.Add(this.txtDesignation);
            this.Controls.Add(this.txtQuantite);
            this.Controls.Add(this.txtPrix);
            this.Controls.Add(this.btnAfficher);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.btnRechercher);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Code-barres", Location = new System.Drawing.Point(155, 18), AutoSize = true });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Désignation", Location = new System.Drawing.Point(155, 56), AutoSize = true });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Quantité", Location = new System.Drawing.Point(155, 94), AutoSize = true });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Prix", Location = new System.Drawing.Point(155, 132), AutoSize = true });
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView1.ReadOnly = true;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Text = "Gestion des produits";
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.TextBox txtCodeBarre;
        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.TextBox txtQuantite;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.Button btnAfficher;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
