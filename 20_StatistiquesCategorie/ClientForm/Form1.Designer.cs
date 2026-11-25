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
        private System.Windows.Forms.TextBox txtIdVente, txtProduit, txtCategorie, txtQuantite, txtPrixUnitaire, txtSeuilCA, txtNombreMinimum, txtPrixMinimum;
        private System.Windows.Forms.Button btnAfficher, btnAjouter, btnModifier, btnSupprimer, btnRechercher, btnStatistiques, btnFiltrerCA, btnFiltrerNombre, btnStatistiquesProduit, btnFiltrerPrix, btnPrixMoyenPondere;
        private System.Windows.Forms.Label lblResultat;
        private System.Windows.Forms.DataGridView dataGridView1, dataGridView2;
        private void InitializeComponent()
        {
            this.txtIdVente = new System.Windows.Forms.TextBox();
            this.txtProduit = new System.Windows.Forms.TextBox();
            this.txtCategorie = new System.Windows.Forms.TextBox();
            this.txtQuantite = new System.Windows.Forms.TextBox();
            this.txtPrixUnitaire = new System.Windows.Forms.TextBox();
            this.txtSeuilCA = new System.Windows.Forms.TextBox();
            this.txtNombreMinimum = new System.Windows.Forms.TextBox();
            this.txtPrixMinimum = new System.Windows.Forms.TextBox();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.btnStatistiques = new System.Windows.Forms.Button();
            this.btnFiltrerCA = new System.Windows.Forms.Button();
            this.btnFiltrerNombre = new System.Windows.Forms.Button();
            this.btnStatistiquesProduit = new System.Windows.Forms.Button();
            this.btnFiltrerPrix = new System.Windows.Forms.Button();
            this.btnPrixMoyenPondere = new System.Windows.Forms.Button();
            this.lblResultat = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize) this.dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.dataGridView2).BeginInit();
            this.SuspendLayout();
            this.txtIdVente.Location = new System.Drawing.Point(120, 10);
            this.txtProduit.Location = new System.Drawing.Point(120, 40);
            this.txtCategorie.Location = new System.Drawing.Point(120, 70);
            this.txtQuantite.Location = new System.Drawing.Point(120, 100);
            this.txtPrixUnitaire.Location = new System.Drawing.Point(120, 130);
            this.txtSeuilCA.Location = new System.Drawing.Point(420, 10);
            this.txtNombreMinimum.Location = new System.Drawing.Point(420, 40);
            this.txtPrixMinimum.Location = new System.Drawing.Point(420, 70);
            this.Controls.Add(new System.Windows.Forms.Label { Text = "ID", Location = new System.Drawing.Point(15, 13) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Produit", Location = new System.Drawing.Point(15, 43) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Catégorie", Location = new System.Drawing.Point(15, 73) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Quantité", Location = new System.Drawing.Point(15, 103) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Prix unitaire", Location = new System.Drawing.Point(15, 133) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Seuil CA", Location = new System.Drawing.Point(310, 13) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Nombre min", Location = new System.Drawing.Point(310, 43) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Prix min", Location = new System.Drawing.Point(310, 73) });
            this.btnAfficher.Text = "Afficher";
            this.btnAfficher.Location = new System.Drawing.Point(15, 165);
            this.btnAfficher.Click += this.btnAfficher_Click;
            this.btnRechercher.Text = "Chercher";
            this.btnRechercher.Location = new System.Drawing.Point(140, 165);
            this.btnRechercher.Click += this.btnRechercher_Click;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Location = new System.Drawing.Point(265, 165);
            this.btnAjouter.Click += this.btnAjouter_Click;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.Location = new System.Drawing.Point(390, 165);
            this.btnModifier.Click += this.btnModifier_Click;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.Location = new System.Drawing.Point(515, 165);
            this.btnSupprimer.Click += this.btnSupprimer_Click;
            this.btnStatistiques.Text = "Par catégorie";
            this.btnStatistiques.Location = new System.Drawing.Point(15, 200);
            this.btnStatistiques.Click += this.btnStatistiques_Click;
            this.btnFiltrerCA.Text = "Seuil CA";
            this.btnFiltrerCA.Location = new System.Drawing.Point(140, 200);
            this.btnFiltrerCA.Click += this.btnFiltrerCA_Click;
            this.btnFiltrerNombre.Text = "Nombre min";
            this.btnFiltrerNombre.Location = new System.Drawing.Point(265, 200);
            this.btnFiltrerNombre.Click += this.btnFiltrerNombre_Click;
            this.btnStatistiquesProduit.Text = "Par produit";
            this.btnStatistiquesProduit.Location = new System.Drawing.Point(390, 200);
            this.btnStatistiquesProduit.Click += this.btnStatistiquesProduit_Click;
            this.btnFiltrerPrix.Text = "Prix minimum";
            this.btnFiltrerPrix.Location = new System.Drawing.Point(515, 200);
            this.btnFiltrerPrix.Click += this.btnFiltrerPrix_Click;
            this.btnPrixMoyenPondere.Text = "Prix pondéré";
            this.btnPrixMoyenPondere.Location = new System.Drawing.Point(640, 200);
            this.btnPrixMoyenPondere.Click += this.btnPrixMoyenPondere_Click;
            this.btnAfficher.Size = this.btnRechercher.Size = this.btnAjouter.Size = this.btnModifier.Size = this.btnSupprimer.Size = this.btnStatistiques.Size = this.btnFiltrerCA.Size = this.btnFiltrerNombre.Size = this.btnStatistiquesProduit.Size = this.btnFiltrerPrix.Size = this.btnPrixMoyenPondere.Size = new System.Drawing.Size(115, 28);
            this.lblResultat.Location = new System.Drawing.Point(550, 135);
            this.lblResultat.Size = new System.Drawing.Size(220, 25);
            this.dataGridView1.Location = new System.Drawing.Point(15, 235);
            this.dataGridView1.Size = new System.Drawing.Size(770, 150);
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView2.Location = new System.Drawing.Point(15, 395);
            this.dataGridView2.Size = new System.Drawing.Size(770, 150);
            this.dataGridView2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.txtIdVente, this.txtProduit, this.txtCategorie, this.txtQuantite, this.txtPrixUnitaire, this.txtSeuilCA, this.txtNombreMinimum, this.txtPrixMinimum, this.btnAfficher, this.btnAjouter, this.btnModifier, this.btnSupprimer, this.btnRechercher, this.btnStatistiques, this.btnFiltrerCA, this.btnFiltrerNombre, this.btnStatistiquesProduit, this.btnFiltrerPrix, this.btnPrixMoyenPondere, this.lblResultat, this.dataGridView1, this.dataGridView2 });
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.MinimumSize = new System.Drawing.Size(800, 560);
            this.Text = "Statistiques par catégorie";
            ((System.ComponentModel.ISupportInitialize) this.dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.dataGridView2).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
