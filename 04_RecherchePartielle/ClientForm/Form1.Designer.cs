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
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Location = new System.Drawing.Point(15, 15);
            this.txtRecherche.Size = new System.Drawing.Size(130, 30);
            this.btnAfficher = new System.Windows.Forms.Button();
            this.btnAfficher.Name = "btnAfficher";
            this.btnAfficher.Location = new System.Drawing.Point(15, 53);
            this.btnAfficher.Size = new System.Drawing.Size(130, 30);
            this.btnAfficher.Text = "Afficher";
            this.btnAfficher.Click += new System.EventHandler(this.btnAfficher_Click);
            this.btnCommencePar = new System.Windows.Forms.Button();
            this.btnCommencePar.Name = "btnCommencePar";
            this.btnCommencePar.Location = new System.Drawing.Point(15, 91);
            this.btnCommencePar.Size = new System.Drawing.Size(130, 30);
            this.btnCommencePar.Text = "CommencePar";
            this.btnCommencePar.Click += new System.EventHandler(this.btnCommencePar_Click);
            this.btnContient = new System.Windows.Forms.Button();
            this.btnContient.Name = "btnContient";
            this.btnContient.Location = new System.Drawing.Point(15, 129);
            this.btnContient.Size = new System.Drawing.Size(130, 30);
            this.btnContient.Text = "Contient";
            this.btnContient.Click += new System.EventHandler(this.btnContient_Click);
            this.btnTerminePar = new System.Windows.Forms.Button();
            this.btnTerminePar.Name = "btnTerminePar";
            this.btnTerminePar.Location = new System.Drawing.Point(15, 167);
            this.btnTerminePar.Size = new System.Drawing.Size(130, 30);
            this.btnTerminePar.Text = "TerminePar";
            this.btnTerminePar.Click += new System.EventHandler(this.btnTerminePar_Click);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Location = new System.Drawing.Point(15, 205);
            this.dataGridView1.Size = new System.Drawing.Size(850, 300);
            this.Controls.Add(this.txtRecherche);
            this.Controls.Add(this.btnAfficher);
            this.Controls.Add(this.btnCommencePar);
            this.Controls.Add(this.btnContient);
            this.Controls.Add(this.btnTerminePar);
            this.Controls.Add(this.dataGridView1);
            this.txtMatricule = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(400, 15) };
            this.txtNom = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(400, 48) };
            this.txtPrenom = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(400, 81) };
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Recherche", Location = new System.Drawing.Point(155, 18), AutoSize = true });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Matricule", Location = new System.Drawing.Point(300, 18), AutoSize = true });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Nom", Location = new System.Drawing.Point(300, 51), AutoSize = true });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Prénom", Location = new System.Drawing.Point(300, 84), AutoSize = true });
            this.btnRechercher = new System.Windows.Forms.Button { Text = "Rechercher ID", Location = new System.Drawing.Point(300, 120), Width = 120 };
            this.btnRechercher.Click += this.btnRechercher_Click;
            this.btnAjouter = new System.Windows.Forms.Button { Text = "Ajouter", Location = new System.Drawing.Point(430, 120), Width = 120 };
            this.btnAjouter.Click += this.btnAjouter_Click;
            this.btnModifier = new System.Windows.Forms.Button { Text = "Modifier", Location = new System.Drawing.Point(300, 155), Width = 120 };
            this.btnModifier.Click += this.btnModifier_Click;
            this.btnSupprimer = new System.Windows.Forms.Button { Text = "Supprimer", Location = new System.Drawing.Point(430, 155), Width = 120 };
            this.btnSupprimer.Click += this.btnSupprimer_Click;
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.txtMatricule, this.txtNom, this.txtPrenom, this.btnRechercher, this.btnAjouter, this.btnModifier, this.btnSupprimer });
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView1.ReadOnly = true;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Text = "Recherche partielle";
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.TextBox txtMatricule, txtNom, txtPrenom;
        private System.Windows.Forms.Button btnRechercher, btnAjouter, btnModifier, btnSupprimer;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.Button btnAfficher;
        private System.Windows.Forms.Button btnCommencePar;
        private System.Windows.Forms.Button btnContient;
        private System.Windows.Forms.Button btnTerminePar;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
