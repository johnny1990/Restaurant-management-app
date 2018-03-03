using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class MeniuPrincipal : Form
    {
        public MeniuPrincipal()
        {
            InitializeComponent();
        }

        private void produseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produse frm = new Produse();
            frm.Show();
        }

        private void categoriiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categorie frm = new Categorie();
            frm.Show();
        }

        private void despreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DespreAplicatie frm = new DespreAplicatie();
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ToolStripStatusLabel4.Text = System.DateTime.Now.ToString();
        }

        private void inregistrareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inregistrare frm = new Inregistrare();
            frm.Show();
        }

        private void DetaliiAutentificareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetaliiAutentificare frm = new DetaliiAutentificare();
            frm.Show();
        }

        private void profilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clienti frm = new Clienti();
            frm.Show();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vanzari frm = new Vanzari();
            frm.Show();
        }

        private void clientiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RaportClienti frm = new RaportClienti();
            frm.Show();
        }

        private void vanzariToolStripMenuItem_Click(object sender, EventArgs e)
        {
           RaportVanzari frm = new RaportVanzari();
            frm.Show();
        }

        private void restaurantInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InformatiiRestaurant frm = new InformatiiRestaurant();
            frm.Show();
        }

        private void valutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TipMoneda frm = new TipMoneda();
            frm.Show();
        }
    }
}
