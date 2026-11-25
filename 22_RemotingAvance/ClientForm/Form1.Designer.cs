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
        private TextBox txtMatricule, txtNom, txtPrenom, txtNote, txtJournal;
        private Label lblAdresseServeur, lblConnexion, lblObjetOriginal, lblObjetRetourne, lblCompteur, lblCompteurGlobal, lblInstanceId;
        private DataGridView dataGridView1;
        private Button btnTestConcurrent;
        private void InitializeComponent()
        {
            this.SuspendLayout();
            var tabs = new TabControl { Dock = DockStyle.Fill };
            var connexion = new TabPage("Connexion");
            var objets = new TabPage("Sérialisation");
            var activation = new TabPage("Activation");
            tabs.TabPages.AddRange(new[] { connexion, objets, activation });
            lblAdresseServeur = new Label { Location = new Point(15, 20), Width = 700 };
            lblConnexion = new Label { Location = new Point(15, 95), Width = 700 };
            connexion.Controls.AddRange(new Control[] { lblAdresseServeur, lblConnexion });
            Bouton(connexion, "Tester connexion", 15, 50, btnTesterConnexion_Click);
            txtMatricule = Champ(objets, "Matricule", 15, 15);
            txtNom = Champ(objets, "Nom", 15, 48);
            txtPrenom = Champ(objets, "Prénom", 15, 81);
            txtNote = Champ(objets, "Note", 15, 114);
            Bouton(objets, "Recevoir", 15, 155, btnRecevoirObjet_Click);
            Bouton(objets, "Copie locale", 140, 155, btnModifierCopieLocale_Click);
            Bouton(objets, "Envoyer", 265, 155, btnEnvoyerObjet_Click);
            Bouton(objets, "Liste", 390, 155, btnAfficherListe_Click);
            lblObjetOriginal = new Label { Location = new Point(15, 195), Size = new Size(750, 25) };
            lblObjetRetourne = new Label { Location = new Point(15, 225), Size = new Size(750, 40) };
            dataGridView1 = new DataGridView { Location = new Point(15, 270), Size = new Size(750, 215), ReadOnly = true, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom };
            objets.Controls.AddRange(new Control[] { lblObjetOriginal, lblObjetRetourne, dataGridView1 });
            Bouton(activation, "Incrémenter", 15, 15, btnIncrementer_Click);
            Bouton(activation, "Lire compteur", 140, 15, btnGetCompteur_Click);
            Bouton(activation, "Reset", 265, 15, btnResetCompteur_Click);
            Bouton(activation, "Instance ID", 390, 15, btnInstanceId_Click);
            Bouton(activation, "Global", 515, 15, btnIncrementerGlobal_Click);
            btnTestConcurrent = Bouton(activation, "100 appels", 640, 15, btnTestConcurrent_Click);
            lblCompteur = new Label { Location = new Point(15, 55), Width = 200 };
            lblCompteurGlobal = new Label { Location = new Point(225, 55), Width = 200 };
            lblInstanceId = new Label { Location = new Point(15, 85), Width = 730 };
            txtJournal = new TextBox { Location = new Point(15, 115), Size = new Size(750, 370), Multiline = true, ScrollBars = ScrollBars.Both, ReadOnly = true, Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right };
            activation.Controls.AddRange(new Control[] { lblCompteur, lblCompteurGlobal, lblInstanceId, txtJournal });
            this.Controls.Add(tabs);
            this.ClientSize = new Size(800, 550);
            this.MinimumSize = new Size(800, 550);
            this.Text = "Remoting avancé";
            this.ResumeLayout(false);
        }
        private TextBox Champ(Control p, string nom, int x, int y)
        {
            p.Controls.Add(new Label { Text = nom, Location = new Point(x, y + 3), Width = 100 });
            var t = new TextBox { Location = new Point(x + 110, y), Width = 180 };
            p.Controls.Add(t);
            return t;
        }
        private Button Bouton(Control p, string texte, int x, int y, EventHandler e)
        {
            var b = new Button { Text = texte, Location = new Point(x, y), Size = new Size(120, 30) };
            b.Click += e;
            p.Controls.Add(b);
            return b;
        }
    }
}
