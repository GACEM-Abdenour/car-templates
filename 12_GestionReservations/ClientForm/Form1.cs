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
        private IRemoteOperation remoteOperation;
        public Form1()
        {
            InitializeComponent();
            try
            {
                ChannelServices.RegisterChannel(new TcpChannel(), false);
                // MACHINE 1: replace localhost with Machine 2 IP.
                remoteOperation = (IRemoteOperation) Activator.GetObject(typeof(IRemoteOperation), "tcp://localhost:1069/RemoteOperation");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connexion : " + ex.Message);
            }
        }
        private void Executer(Action a)
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
        private int Id()
        {
            int n;
            if (!int.TryParse(txtIdReservation.Text, out n) || n < 0 || n > 99999) throw new ArgumentException("Identifiant invalide.");
            return n;
        }
        private string Texte(TextBox t, int max)
        {
            string v = t.Text.Trim();
            if (v.Length == 0 || v.Length > max) throw new ArgumentException("Champ obligatoire ou trop long.");
            return v;
        }
        private void Afficher(DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0) throw new InvalidOperationException("Aucune table reçue.");
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            if (ds.Tables[0].Rows.Count == 0) MessageBox.Show("Aucun résultat.");
        }
        private void Resultat(int n)
        {
            MessageBox.Show(n == 0 ? "Réservation introuvable." : n + " ligne(s) modifiée(s).");
            Afficher(remoteOperation.GetReservations());
        }
        private void btnAfficher_Click(object s, EventArgs e)
        {
            Executer(() => Afficher(remoteOperation.GetReservations()));
        }
        private void btnRechercher_Click(object s, EventArgs e)
        {
            Executer(() => Afficher(remoteOperation.RechercherReservation(Id())));
        }
        // TRICK 12: DateTimePicker.Value carries the date and time directly to the server.
        private void btnAjouter_Click(object s, EventArgs e)
        {
            Executer(() => Resultat(remoteOperation.AjouterReservation(Id(), Texte(txtResponsable, 60), Texte(txtSalle, 30), dtpReservation.Value)));
        }
        private void btnModifier_Click(object s, EventArgs e)
        {
            Executer(() => Resultat(remoteOperation.ModifierReservation(Id(), Texte(txtResponsable, 60), Texte(txtSalle, 30), dtpReservation.Value)));
        }
        private void btnSupprimer_Click(object s, EventArgs e)
        {
            Executer(() => Resultat(remoteOperation.SupprimerReservation(Id())));
        }
        private void btnRechercherDate_Click(object s, EventArgs e)
        {
            Executer(() => Afficher(remoteOperation.GetReservationsParDate(dtpRecherche.Value.Date)));
        }
        private void btnRechercherIntervalle_Click(object s, EventArgs e)
        {
            Executer(() =>
            {
                DateTime debut = dtpDateDebut.Value.Date, fin = dtpDateFin.Value.Date;
                if (debut > fin || fin == DateTime.MaxValue.Date) throw new ArgumentException("Intervalle invalide.");
                Afficher(remoteOperation.GetReservationsEntre(debut, fin));
            });
        }
        private void btnReservationsFutures_Click(object s, EventArgs e)
        {
            Executer(() => Afficher(remoteOperation.GetReservationsFutures()));
        }
        private void btnAujourdhui_Click(object s, EventArgs e)
        {
            Executer(() => Afficher(remoteOperation.GetReservationsAujourdhui()));
        }
    }
}
