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
namespace Restaurant
{
    public partial class Categorie : Form
    {
        #region Members
       // private Table_Categorii table_categorii;
        //private List<Table_Categorii> categorii = new List<Table_Categorii>();
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        #endregion

        #region Construction
        public Categorie()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void Categorie_Load(object sender, EventArgs e)
        {
            Autocomplete();
        }

        private void btnSalvare_Click(object sender, EventArgs e)
        {
            if (txtNumeCategorie.Text == "")
            {
                 MessageBox.Show("Introduce categoria", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 txtNumeCategorie.Focus();
                   return;
                 }

               // foreach (Table_Categorii table_categorii in categorii)
                //{
                //    CategoriiOperations.Insert(table_categorii);
               // }

                 try
                {  
                string cb = "insert into Categorii(Nume_categorii) VALUES ('" + txtNumeCategorie.Text + "')";

                 cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                 con.Close();
                MessageBox.Show("Salvat cu succes", "Informatii", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Autocomplete();
                btnSalvare.Enabled = false;



                }
                 catch (Exception ex)
                 {
                   MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
            }
        

        private void btnSterge_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }
        private void delete_records()
        {

            try
            {
                //
                //CategoriiOperations.Delete(table_categorii.Id);
                //

                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from Categorii where Id=" + txtId.Text + "";
                cmd = new SqlCommand(cq);
               cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    Autocomplete();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    Autocomplete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Autocomplete()
        {
            try
            {
                //
                //categorii = CategoriiOperations.Get(null, null).ToList();

                //

                 con = new SqlConnection(cs.DBConn);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT distinct Nume_categorie FROM Categorii", con);
                DataSet ds = new DataSet();
               SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Categorii");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["Nume_categorie"].ToString());

                }
                txtNumeCategorie.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtNumeCategorie.AutoCompleteCustomSource = col;
                txtNumeCategorie.AutoCompleteMode = AutoCompleteMode.Suggest;

                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizeaza_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumeCategorie.Text == "")
                {
                    MessageBox.Show("Introduce numele categoriei", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNumeCategorie.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();

                //
               // CategoriiOperations.Update(table_categorii);
                //


                string cb = "update Categorii set Nume_categorie='" + txtNumeCategorie.Text + "' where Id=" + txtId.Text + "";//
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
               con.Close();
                MessageBox.Show("Actualizat cu succes", "Informatii", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Autocomplete();
                btnActualizeaza.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void Reset()
        {
            txtNumeCategorie.Text = "";
            btnSalvare.Enabled = true;
            btnSterge.Enabled = false;
            btnActualizeaza.Enabled = false;
            txtNumeCategorie.Focus();
        }
        
        private void btnNou_Click(object sender, EventArgs e)
        {
            Reset();
        }
        
        private void btnAfiseazaCategorii_Click(object sender, EventArgs e)
        {
            this.Hide();
            DetaliiCategoriiProduse frm = new DetaliiCategoriiProduse();
            frm.Show();           
        }
        #endregion
    }
}
