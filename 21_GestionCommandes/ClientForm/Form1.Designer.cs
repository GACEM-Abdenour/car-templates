using System;
using System.Drawing;
using System.Windows.Forms;

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
        private TextBox txtClient, txtNom, txtTelephone, txtProduit, txtDesignation, txtPrix, txtStock, txtIdCommande, txtQuantite;
        private ComboBox cmbClient, cmbProduit;
        private DateTimePicker dtpDateCommande;
        private DataGridView gridGestion, gridBrouillon, dataGridView1, dataGridView2, gridStats;
        private Label lblTotalCommande;
        private void InitializeComponent()
        {
            this.SuspendLayout();
            var tabs = new TabControl { Dock = DockStyle.Fill };
            var gestion = new TabPage("Clients / produits");
            var nouvelle = new TabPage("Nouvelle commande");
            var commandes = new TabPage("Commandes");
            var statistiques = new TabPage("Statistiques");
            tabs.TabPages.AddRange(new[] { gestion, nouvelle, commandes, statistiques });
            txtClient = Champ(gestion, "ID client", 15, 15);
            txtNom = Champ(gestion, "Nom", 15, 45);
            txtTelephone = Champ(gestion, "Téléphone", 15, 75);
            txtProduit = Champ(gestion, "ID produit", 350, 15);
            txtDesignation = Champ(gestion, "Désignation", 350, 45);
            txtPrix = Champ(gestion, "Prix", 350, 75);
            txtStock = Champ(gestion, "Stock initial", 350, 105);
            Bouton(gestion, "Clients", 15, 150, btnClients_Click);
            Bouton(gestion, "Chercher client", 140, 150, btnChercherClient_Click);
            Bouton(gestion, "Ajouter client", 265, 150, btnAjouterClient_Click);
            Bouton(gestion, "Modifier client", 390, 150, btnModifierClient_Click);
            Bouton(gestion, "Supprimer client", 515, 150, btnSupprimerClient_Click);
            Bouton(gestion, "Produits", 15, 185, btnProduits_Click);
            Bouton(gestion, "Chercher produit", 140, 185, btnChercherProduit_Click);
            Bouton(gestion, "Ajouter produit", 265, 185, btnAjouterProduit_Click);
            Bouton(gestion, "Modifier produit", 390, 185, btnModifierProduit_Click);
            Bouton(gestion, "Supprimer produit", 515, 185, btnSupprimerProduit_Click);
            gridGestion = Grille(gestion, 15, 225, 750, 260);
            txtIdCommande = Champ(nouvelle, "ID commande", 15, 15);
            txtQuantite = Champ(nouvelle, "Quantité", 15, 50);
            nouvelle.Controls.Add(new Label { Text = "Client", Location = new Point(330, 18) });
            nouvelle.Controls.Add(new Label { Text = "Produit", Location = new Point(330, 53) });
            cmbClient = new ComboBox { Location = new Point(440, 15), Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbProduit = new ComboBox { Location = new Point(440, 50), Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };
            dtpDateCommande = new DateTimePicker { Location = new Point(125, 85), Width = 180, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy HH:mm" };
            nouvelle.Controls.Add(new Label { Text = "Date", Location = new Point(15, 88) });
            nouvelle.Controls.AddRange(new Control[] { cmbClient, cmbProduit, dtpDateCommande });
            Bouton(nouvelle, "Ajouter ligne", 15, 130, btnAjouterLigne_Click);
            Bouton(nouvelle, "Retirer ligne", 140, 130, btnRetirerLigne_Click);
            Bouton(nouvelle, "Enregistrer", 265, 130, btnEnregistrerCommande_Click);
            gridBrouillon = Grille(nouvelle, 15, 170, 750, 315);
            Bouton(commandes, "Toutes", 15, 10, btnCommandes_Click);
            Bouton(commandes, "Par client", 140, 10, btnParClient_Click);
            Bouton(commandes, "Chercher ligne", 265, 10, btnChercherLigne_Click);
            lblTotalCommande = new Label { Text = "Total : —", Location = new Point(410, 15), Width = 300 };
            commandes.Controls.Add(lblTotalCommande);
            dataGridView1 = Grille(commandes, 15, 50, 750, 185);
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView2 = Grille(commandes, 15, 250, 750, 235);
            Bouton(statistiques, "CA par client", 15, 10, btnStats_Click);
            Bouton(statistiques, "Clients sans", 140, 10, btnClientsSans_Click);
            Bouton(statistiques, "Produits sans", 265, 10, btnProduitsSans_Click);
            Bouton(statistiques, "Deux bases", 390, 10, btnAfficherDeuxBases_Click);
            gridStats = Grille(statistiques, 15, 50, 750, 435);
            this.Controls.Add(tabs);
            this.ClientSize = new Size(800, 550);
            this.MinimumSize = new Size(800, 550);
            this.Text = "Gestion des commandes";
            this.Shown += Form1_Shown;
            this.ResumeLayout(false);
        }
        private TextBox Champ(Control parent, string nom, int x, int y)
        {
            var label = new Label { Text = nom, Location = new Point(x, y + 3), Width = 105 };
            var champ = new TextBox { Location = new Point(x + 110, y), Width = 160 };
            parent.Controls.Add(label);
            parent.Controls.Add(champ);
            return champ;
        }
        private void Bouton(Control parent, string nom, int x, int y, EventHandler clic)
        {
            var b = new Button { Text = nom, Location = new Point(x, y), Size = new Size(120, 30) };
            b.Click += clic;
            parent.Controls.Add(b);
        }
        private DataGridView Grille(Control parent, int x, int y, int w, int h)
        {
            var g = new DataGridView { Location = new Point(x, y), Size = new Size(w, h), ReadOnly = true, AllowUserToAddRows = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            parent.Controls.Add(g);
            return g;
        }
    }
}
