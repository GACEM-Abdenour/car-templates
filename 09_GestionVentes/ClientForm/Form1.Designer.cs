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
        private System.Windows.Forms.TextBox txtIdVente, txtProduit, txtQuantite, txtPrixUnitaire, txtRechercheProduit;
        private System.Windows.Forms.Button btnAfficher, btnRechercher, btnAjouter, btnModifier, btnSupprimer, btnCalculerCA, btnCalculerCAProduit, btnCalculerQuantite;
        private System.Windows.Forms.Label lblChiffreAffaires, lblQuantiteTotale;
        private System.Windows.Forms.DataGridView dataGridView1;
        private void InitializeComponent()
        {
            this.txtIdVente = new System.Windows.Forms.TextBox();
            this.txtProduit = new System.Windows.Forms.TextBox();
            this.txtQuantite = new System.Windows.Forms.TextBox();
            this.txtPrixUnitaire = new System.Windows.Forms.TextBox();
            this.txtRechercheProduit = new System.Windows.Forms.TextBox();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnCalculerCA = new System.Windows.Forms.Button();
            this.btnCalculerCAProduit = new System.Windows.Forms.Button();
            this.btnCalculerQuantite = new System.Windows.Forms.Button();
            this.lblChiffreAffaires = new System.Windows.Forms.Label();
            this.lblQuantiteTotale = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            this.txtIdVente.Location = new System.Drawing.Point(120, 15);
            this.txtProduit.Location = new System.Drawing.Point(120, 48);
            this.txtQuantite.Location = new System.Drawing.Point(120, 81);
            this.txtPrixUnitaire.Location = new System.Drawing.Point(120, 114);
            this.txtRechercheProduit.Location = new System.Drawing.Point(460, 15);
            this.txtRechercheProduit.Width = 150;
            this.Controls.Add(new System.Windows.Forms.Label { Text = "ID vente", Location = new System.Drawing.Point(15, 18) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Produit", Location = new System.Drawing.Point(15, 51) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Quantité", Location = new System.Drawing.Point(15, 84) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Prix unitaire", Location = new System.Drawing.Point(15, 117) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Produit CA", Location = new System.Drawing.Point(350, 18) });
            this.btnAfficher.Text = "Afficher";
            this.btnAfficher.Location = new System.Drawing.Point(15, 155);
            this.btnAfficher.Click += this.btnAfficher_Click;
            this.btnRechercher.Text = "Rechercher ID";
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
            this.btnCalculerCA.Text = "CA total";
            this.btnCalculerCA.Location = new System.Drawing.Point(15, 195);
            this.btnCalculerCA.Click += this.btnCalculerCA_Click;
            this.btnCalculerCAProduit.Text = "CA produit";
            this.btnCalculerCAProduit.Location = new System.Drawing.Point(145, 195);
            this.btnCalculerCAProduit.Click += this.btnCalculerCAProduit_Click;
            this.btnCalculerQuantite.Text = "Quantité totale";
            this.btnCalculerQuantite.Location = new System.Drawing.Point(275, 195);
            this.btnCalculerQuantite.Click += this.btnCalculerQuantite_Click;
            this.btnAfficher.Size = this.btnRechercher.Size = this.btnAjouter.Size = this.btnModifier.Size = this.btnSupprimer.Size = this.btnCalculerCA.Size = this.btnCalculerCAProduit.Size = this.btnCalculerQuantite.Size = new System.Drawing.Size(120, 30);
            this.lblChiffreAffaires.Location = new System.Drawing.Point(420, 200);
            this.lblChiffreAffaires.Size = new System.Drawing.Size(170, 25);
            this.lblChiffreAffaires.Text = "CA : —";
            this.lblQuantiteTotale.Location = new System.Drawing.Point(610, 200);
            this.lblQuantiteTotale.Size = new System.Drawing.Size(160, 25);
            this.lblQuantiteTotale.Text = "Quantité : —";
            this.dataGridView1.Location = new System.Drawing.Point(15, 240);
            this.dataGridView1.Size = new System.Drawing.Size(770, 300);
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.txtIdVente, this.txtProduit, this.txtQuantite, this.txtPrixUnitaire, this.txtRechercheProduit, this.btnAfficher, this.btnRechercher, this.btnAjouter, this.btnModifier, this.btnSupprimer, this.btnCalculerCA, this.btnCalculerCAProduit, this.btnCalculerQuantite, this.lblChiffreAffaires, this.lblQuantiteTotale, this.dataGridView1 });
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.MinimumSize = new System.Drawing.Size(800, 560);
            this.Text = "Gestion des ventes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
