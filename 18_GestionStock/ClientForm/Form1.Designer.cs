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
        private System.Windows.Forms.TextBox txtIdProduit, txtDesignation, txtQuantiteActuelle, txtQuantiteMouvement, txtSeuilAlerte;
        private System.Windows.Forms.Button btnAfficher, btnAjouter, btnModifier, btnSupprimer, btnRechercher, btnEntree, btnSortie, btnConsulterStock, btnAfficherAlertes, btnAfficherEpuises;
        private System.Windows.Forms.Label lblResultat;
        private System.Windows.Forms.DataGridView dataGridView1;
        private void InitializeComponent()
        {
            this.txtIdProduit = new System.Windows.Forms.TextBox();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.txtQuantiteActuelle = new System.Windows.Forms.TextBox();
            this.txtQuantiteMouvement = new System.Windows.Forms.TextBox();
            this.txtSeuilAlerte = new System.Windows.Forms.TextBox();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.btnEntree = new System.Windows.Forms.Button();
            this.btnSortie = new System.Windows.Forms.Button();
            this.btnConsulterStock = new System.Windows.Forms.Button();
            this.btnAfficherAlertes = new System.Windows.Forms.Button();
            this.btnAfficherEpuises = new System.Windows.Forms.Button();
            this.lblResultat = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize) this.dataGridView1).BeginInit();
            this.SuspendLayout();
            this.txtIdProduit.Location = new System.Drawing.Point(125, 15);
            this.txtDesignation.Location = new System.Drawing.Point(125, 48);
            this.txtSeuilAlerte.Location = new System.Drawing.Point(125, 81);
            this.txtQuantiteActuelle.Location = new System.Drawing.Point(455, 15);
            this.txtQuantiteActuelle.ReadOnly = true;
            this.txtQuantiteMouvement.Location = new System.Drawing.Point(455, 48);
            this.Controls.Add(new System.Windows.Forms.Label { Text = "ID produit", Location = new System.Drawing.Point(15, 18) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Désignation", Location = new System.Drawing.Point(15, 51) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Seuil alerte", Location = new System.Drawing.Point(15, 84) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Stock actuel", Location = new System.Drawing.Point(330, 18) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Mouvement", Location = new System.Drawing.Point(330, 51) });
            this.btnAfficher.Text = "Afficher";
            this.btnAfficher.Location = new System.Drawing.Point(15, 130);
            this.btnAfficher.Click += this.btnAfficher_Click;
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.Location = new System.Drawing.Point(145, 130);
            this.btnRechercher.Click += this.btnRechercher_Click;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Location = new System.Drawing.Point(275, 130);
            this.btnAjouter.Click += this.btnAjouter_Click;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.Location = new System.Drawing.Point(405, 130);
            this.btnModifier.Click += this.btnModifier_Click;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.Location = new System.Drawing.Point(535, 130);
            this.btnSupprimer.Click += this.btnSupprimer_Click;
            this.btnEntree.Text = "Entrée";
            this.btnEntree.Location = new System.Drawing.Point(15, 170);
            this.btnEntree.Click += this.btnEntree_Click;
            this.btnSortie.Text = "Sortie";
            this.btnSortie.Location = new System.Drawing.Point(145, 170);
            this.btnSortie.Click += this.btnSortie_Click;
            this.btnConsulterStock.Text = "Consulter stock";
            this.btnConsulterStock.Location = new System.Drawing.Point(275, 170);
            this.btnConsulterStock.Click += this.btnConsulterStock_Click;
            this.btnAfficherAlertes.Text = "Alertes";
            this.btnAfficherAlertes.Location = new System.Drawing.Point(405, 170);
            this.btnAfficherAlertes.Click += this.btnAfficherAlertes_Click;
            this.btnAfficherEpuises.Text = "Épuisés";
            this.btnAfficherEpuises.Location = new System.Drawing.Point(535, 170);
            this.btnAfficherEpuises.Click += this.btnAfficherEpuises_Click;
            this.btnAfficher.Size = this.btnRechercher.Size = this.btnAjouter.Size = this.btnModifier.Size = this.btnSupprimer.Size = this.btnEntree.Size = this.btnSortie.Size = this.btnConsulterStock.Size = this.btnAfficherAlertes.Size = this.btnAfficherEpuises.Size = new System.Drawing.Size(120, 30);
            this.lblResultat.Location = new System.Drawing.Point(15, 210);
            this.lblResultat.Size = new System.Drawing.Size(750, 25);
            this.dataGridView1.Location = new System.Drawing.Point(15, 240);
            this.dataGridView1.Size = new System.Drawing.Size(770, 300);
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.txtIdProduit, this.txtDesignation, this.txtQuantiteActuelle, this.txtQuantiteMouvement, this.txtSeuilAlerte, this.btnAfficher, this.btnAjouter, this.btnModifier, this.btnSupprimer, this.btnRechercher, this.btnEntree, this.btnSortie, this.btnConsulterStock, this.btnAfficherAlertes, this.btnAfficherEpuises, this.lblResultat, this.dataGridView1 });
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.MinimumSize = new System.Drawing.Size(800, 560);
            this.Text = "Gestion du stock";
            ((System.ComponentModel.ISupportInitialize) this.dataGridView1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
