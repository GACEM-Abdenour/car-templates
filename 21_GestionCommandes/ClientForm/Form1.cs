using System;
using System.Data;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;
using Interfaces;

namespace ClientForm
{
    public partial class Form1 : Form
    {
        private IRemoteOperation remote;
        private readonly DataTable lignes = new DataTable();
        private bool chargement;
        public Form1()
        {
            InitializeComponent();
            lignes.Columns.Add("IDPRODUIT", typeof(int));
            lignes.Columns.Add("QUANTITE", typeof(int));
            gridBrouillon.DataSource = lignes;
            try
            {
                ChannelServices.RegisterChannel(new TcpChannel(), false);
                // MACHINE 1: change localhost to the server IP.
                remote = (IRemoteOperation) Activator.GetObject(typeof(IRemoteOperation), "tcp://localhost:1069/RemoteOperation");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Run(Action a)
        {
            try
            {
                a();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
        private int Nombre(TextBox t, int min, int max)
        {
            int n;
            if (!int.TryParse(t.Text, out n) || n < min || n > max) throw new ArgumentException("Nombre invalide.");
            return n;
        }
        private decimal Prix()
        {
            decimal n;
            if (!decimal.TryParse(txtPrix.Text, out n) || n < 0 || n > 9999999999.99m) throw new ArgumentException("Prix invalide.");
            return n;
        }
        private string Texte(TextBox t, int max)
        {
            string v = t.Text.Trim();
            if (v.Length == 0 || v.Length > max) throw new ArgumentException("Texte obligatoire ou trop long.");
            return v;
        }
        private int Selection(ComboBox c)
        {
            int n;
            if (c.SelectedValue == null || !int.TryParse(c.SelectedValue.ToString(), out n)) throw new ArgumentException("Choisissez une valeur.");
            return n;
        }
        private void Afficher(DataGridView g, DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0) throw new InvalidOperationException("Table absente.");
            g.DataSource = ds.Tables[0].DefaultView;
        }
        private void ChargerListes()
        {
            chargement = true;
            try
            {
                DataSet c = remote.GetClients(), p = remote.GetProduits();
                if (c == null || p == null || c.Tables.Count == 0 || p.Tables.Count == 0) throw new InvalidOperationException("Listes absentes.");
                cmbClient.DisplayMember = "NOM";
                cmbClient.ValueMember = "IDCLIENT";
                cmbClient.DataSource = c.Tables[0];
                cmbClient.SelectedIndex = -1;
                cmbProduit.DisplayMember = "DESIGNATION";
                cmbProduit.ValueMember = "IDPRODUIT";
                cmbProduit.DataSource = p.Tables[0];
                cmbProduit.SelectedIndex = -1;
            }
            finally
            {
                chargement = false;
            }
        }
        private void btnClients_Click(object s, EventArgs e)
        {
            Run(() => Afficher(gridGestion, remote.GetClients()));
        }
        private void btnProduits_Click(object s, EventArgs e)
        {
            Run(() => Afficher(gridGestion, remote.GetProduits()));
        }
        private void btnChercherClient_Click(object s, EventArgs e)
        {
            Run(() => Afficher(gridGestion, remote.RechercherClient(Nombre(txtClient, 1, 99999))));
        }
        private void btnChercherProduit_Click(object s, EventArgs e)
        {
            Run(() => Afficher(gridGestion, remote.RechercherProduit(Nombre(txtProduit, 1, 99999))));
        }
        private void btnAjouterClient_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                remote.AjouterClient(Nombre(txtClient, 1, 99999), Texte(txtNom, 60), txtTelephone.Text.Trim());
                Afficher(gridGestion, remote.GetClients());
                ChargerListes();
            });
        }
        private void btnModifierClient_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                int n = remote.ModifierClient(Nombre(txtClient, 1, 99999), Texte(txtNom, 60), txtTelephone.Text.Trim());
                MessageBox.Show(n + " ligne(s).");
                Afficher(gridGestion, remote.GetClients());
                ChargerListes();
            });
        }
        private void btnSupprimerClient_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                int id = Nombre(txtClient, 1, 99999);
                if (MessageBox.Show("Supprimer ce client ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                MessageBox.Show(remote.SupprimerClient(id) + " ligne(s).");
                Afficher(gridGestion, remote.GetClients());
                ChargerListes();
            });
        }
        private void btnAjouterProduit_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                remote.AjouterProduit(Nombre(txtProduit, 1, 99999), Texte(txtDesignation, 60), Prix(), Nombre(txtStock, 0, 99999999));
                Afficher(gridGestion, remote.GetProduits());
                ChargerListes();
            });
        }
        private void btnModifierProduit_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                MessageBox.Show(remote.ModifierProduit(Nombre(txtProduit, 1, 99999), Texte(txtDesignation, 60), Prix()) + " ligne(s).");
                Afficher(gridGestion, remote.GetProduits());
                ChargerListes();
            });
        }
        private void btnSupprimerProduit_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                int id = Nombre(txtProduit, 1, 99999);
                if (MessageBox.Show("Supprimer ce produit ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                MessageBox.Show(remote.SupprimerProduit(id) + " ligne(s).");
                Afficher(gridGestion, remote.GetProduits());
                ChargerListes();
            });
        }
        // TRICK 21: draft has only IDs and quantities; the server rejects duplicate products and retrieves authoritative prices.
        private void btnAjouterLigne_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                int id = Selection(cmbProduit), q = Nombre(txtQuantite, 1, 99999999);
                foreach (DataRow r in lignes.Rows) if ((int) r["IDPRODUIT"] == id) throw new ArgumentException("Produit déjà présent.");
                lignes.Rows.Add(id, q);
            });
        }
        private void btnRetirerLigne_Click(object s, EventArgs e)
        {
            if (gridBrouillon.CurrentRow == null) return;
            DataRowView row = gridBrouillon.CurrentRow.DataBoundItem as DataRowView;
            if (row != null) row.Delete();
        }
        private void btnEnregistrerCommande_Click(object s, EventArgs e)
        {
            Run(() =>
            {
                int n = remote.AjouterCommande(Nombre(txtIdCommande, 1, 99999999), Selection(cmbClient), dtpDateCommande.Value, lignes);
                MessageBox.Show(n + " commande enregistrée.");
                lignes.Clear();
                ChargerListes();
                Afficher(dataGridView1, remote.GetCommandes());
            });
        }
        private void btnCommandes_Click(object s, EventArgs e)
        {
            Run(() => AfficherCommandes(remote.GetCommandes()));
        }
        private void btnParClient_Click(object s, EventArgs e)
        {
            Run(() => AfficherCommandes(remote.GetCommandesParClient(Selection(cmbClient))));
        }
        private void AfficherCommandes(DataSet ds)
        {
            chargement = true;
            try
            {
                Afficher(dataGridView1, ds);
                dataGridView1.ClearSelection();
                dataGridView2.DataSource = null;
                lblTotalCommande.Text = "Total : —";
            }
            finally
            {
                chargement = false;
            }
        }
        // Master/detail: obtain the key from the selected bound row; header clicks have negative indices.
        private void dataGridView1_CellClick(object s, DataGridViewCellEventArgs e)
        {
            if (chargement || e.RowIndex < 0) return;
            Run(() =>
            {
                var row = dataGridView1.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (row == null || row.Row.IsNull("IDCOMMANDE")) return;
                int id = Convert.ToInt32(row["IDCOMMANDE"]);
                Afficher(dataGridView2, remote.GetLignesCommande(id));
                lblTotalCommande.Text = "Total : " + remote.CalculerTotalCommande(id).ToString("N2");
            });
        }
        private void btnStats_Click(object s, EventArgs e)
        {
            Run(() => Afficher(gridStats, remote.GetChiffreAffairesParClient()));
        }
        private void btnClientsSans_Click(object s, EventArgs e)
        {
            Run(() => Afficher(gridStats, remote.GetClientsSansCommandes()));
        }
        private void btnProduitsSans_Click(object s, EventArgs e)
        {
            Run(() => Afficher(gridStats, remote.GetProduitsJamaisCommandes()));
        }
        private void btnAfficherDeuxBases_Click(object s, EventArgs e)
        {
            Run(() => Afficher(gridStats, remote.GetProduitsDeuxBases()));
        }
        private void btnChercherLigne_Click(object s, EventArgs e)
        {
            Run(() => Afficher(dataGridView2, remote.RechercherLigneCommande(Nombre(txtIdCommande, 1, 99999999), Nombre(txtProduit, 1, 99999))));
        }
        private void Form1_Shown(object s, EventArgs e)
        {
            Run(ChargerListes);
        }
    }
}
