using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Restaurant.Business.Clase;
using Restaurant.Business.Operatii;
using Restaurant.Business.Helpers;

namespace Restaurant
{
    public partial class DetaliiCategoriiProduse : Form
    {
        #region Members
        private List<Table_Categorii> categorii = new List<Table_Categorii>();
        #endregion

        #region Construction
        public DetaliiCategoriiProduse()
        {
            InitializeComponent();
            categorii = CategoriiOperations.Get(null, null).ToList();
            dataGridView1.DataSource = categorii;
        }
        #endregion

        #region Events
        private void DetaliiCategoriiProduse_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Categorie frm = new Categorie();
            frm.Show();
        }
        #endregion
    }
}
        
    
