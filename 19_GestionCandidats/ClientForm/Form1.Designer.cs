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
        private System.Windows.Forms.TextBox txtIdCandidat, txtNom, txtPrenom, txtNoteEcrit, txtNoteOral;
        private System.Windows.Forms.ComboBox cmbDecision;
        private System.Windows.Forms.Button btnAfficher, btnAjouter, btnModifier, btnSupprimer, btnRechercher, btnAfficherResultats, btnAfficherAdmis, btnFiltrerDecision, btnCompterDecision;
        private System.Windows.Forms.Label lblResultat;
        private System.Windows.Forms.DataGridView dataGridView1;
        private void InitializeComponent()
        {
            this.txtIdCandidat = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtNoteEcrit = new System.Windows.Forms.TextBox();
            this.txtNoteOral = new System.Windows.Forms.TextBox();
            this.cmbDecision = new System.Windows.Forms.ComboBox();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.btnAfficherResultats = new System.Windows.Forms.Button();
            this.btnAfficherAdmis = new System.Windows.Forms.Button();
            this.btnFiltrerDecision = new System.Windows.Forms.Button();
            this.btnCompterDecision = new System.Windows.Forms.Button();
            this.lblResultat = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize) this.dataGridView1).BeginInit();
            this.SuspendLayout();
            this.txtIdCandidat.Location = new System.Drawing.Point(125, 15);
            this.txtNom.Location = new System.Drawing.Point(125, 48);
            this.txtPrenom.Location = new System.Drawing.Point(125, 81);
            this.txtNoteEcrit.Location = new System.Drawing.Point(420, 15);
            this.txtNoteOral.Location = new System.Drawing.Point(420, 48);
            this.cmbDecision.Location = new System.Drawing.Point(420, 81);
            this.cmbDecision.Width = 180;
            this.cmbDecision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDecision.Items.AddRange(new object[] { "ADMIS", "ADMIS AVEC MENTION", "AJOURNE", "ELIMINE" });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "ID candidat", Location = new System.Drawing.Point(15, 18) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Nom", Location = new System.Drawing.Point(15, 51) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Prénom", Location = new System.Drawing.Point(15, 84) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Note écrit", Location = new System.Drawing.Point(310, 18) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Note oral", Location = new System.Drawing.Point(310, 51) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Décision", Location = new System.Drawing.Point(310, 84) });
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
            this.btnAfficherResultats.Text = "Résultats";
            this.btnAfficherResultats.Location = new System.Drawing.Point(15, 170);
            this.btnAfficherResultats.Click += this.btnAfficherResultats_Click;
            this.btnAfficherAdmis.Text = "Tous admis";
            this.btnAfficherAdmis.Location = new System.Drawing.Point(145, 170);
            this.btnAfficherAdmis.Click += this.btnAfficherAdmis_Click;
            this.btnFiltrerDecision.Text = "Filtrer décision";
            this.btnFiltrerDecision.Location = new System.Drawing.Point(275, 170);
            this.btnFiltrerDecision.Click += this.btnFiltrerDecision_Click;
            this.btnCompterDecision.Text = "Compter décision";
            this.btnCompterDecision.Location = new System.Drawing.Point(405, 170);
            this.btnCompterDecision.Click += this.btnCompterDecision_Click;
            this.btnAfficher.Size = this.btnRechercher.Size = this.btnAjouter.Size = this.btnModifier.Size = this.btnSupprimer.Size = this.btnAfficherResultats.Size = this.btnAfficherAdmis.Size = this.btnFiltrerDecision.Size = this.btnCompterDecision.Size = new System.Drawing.Size(120, 30);
            this.lblResultat.Location = new System.Drawing.Point(550, 177);
            this.lblResultat.Width = 220;
            this.dataGridView1.Location = new System.Drawing.Point(15, 215);
            this.dataGridView1.Size = new System.Drawing.Size(770, 325);
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.txtIdCandidat, this.txtNom, this.txtPrenom, this.txtNoteEcrit, this.txtNoteOral, this.cmbDecision, this.btnAfficher, this.btnAjouter, this.btnModifier, this.btnSupprimer, this.btnRechercher, this.btnAfficherResultats, this.btnAfficherAdmis, this.btnFiltrerDecision, this.btnCompterDecision, this.lblResultat, this.dataGridView1 });
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.MinimumSize = new System.Drawing.Size(800, 560);
            this.Text = "Gestion des candidats";
            ((System.ComponentModel.ISupportInitialize) this.dataGridView1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
