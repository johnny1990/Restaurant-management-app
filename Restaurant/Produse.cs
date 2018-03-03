using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using Restaurant.Business.Clase;
using Restaurant.Business.Operatii;

namespace Restaurant
{
    public partial class Produse : Form
    {
        #region Members
        private List<Table_Categorii> categorii = new List<Table_Categorii>();
        private List<Table_Produse> produse = new List<Table_Produse>();
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        #endregion

        #region Construction
        public Produse()
        {
            InitializeComponent();
            cmbCategorie.DataSource = CategoriiOperations.Get(null, null);
            cmbCategorie.DisplayMember = "Nume_categorie";
            dataGridView1.DataSource = ProduseOperations.Get(null,null);
        }
        #endregion
        //public void GetData()
        //{
         //   try
         //   {
          //      con = new SqlConnection(cs.DBConn);
           //     con.Open();
            //    cmd = new SqlCommand("SELECT RTRIM(Id_produs),RTRIM(Nume_produs),RTRIM(Id_categorie),RTRIM(Nume_categorie),RTRIM(Pret) from Produse,Categorii where Produse.Id_categorie=Id  order by Nume_produs", con);
            //    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //    dataGridView1.Rows.Clear();
             //   while (rdr.Read() == true)
             //   {
             //       dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
             //   }
             //   con.Close();
          //  }
          //  catch (Exception ex)
         //   {
          //      MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
          //  }
       // }
        private void Produse_Load(object sender, EventArgs e)
        {
           // FillCombo();
            Autocomplete();
           // GetData();
        }
       // public void FillCombo()
      //  {
         //   try
           // {

           //     con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    string ct = "select RTRIM(Nume_categorie) from Categorii order by Nume_categorie";
             //   cmd = new SqlCommand(ct);
              //  cmd.Connection = con;
              //  rdr = cmd.ExecuteReader();

             //   while (rdr.Read())
             //   {
              //      cmbCategorie.Items.Add(rdr[0]);
             //   }
             //   con.Close();
               
           // }
           // catch (Exception ex)
           // {
              //  MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
           // }
     //   }

        private void Reset()
        {
            txtNumeProdus.Text = "";
            cmbCategorie.Text = "";
            txtPret.Text = "";
            textBox1.Text = "";
           // GetData();
            btnSterge.Enabled = false;
            btnActualziare.Enabled = false;
            btnSalvare.Enabled = true;
            txtNumeProdus.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNumeProdus.Text == "")
            {
                MessageBox.Show("Please enter product name", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumeProdus.Focus();
                return;
            }
            if (cmbCategorie.Text == "")
            {
                MessageBox.Show("Please select category", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCategorie.Focus();
                return;
            }
            if (txtPret.Text == "")
            {
                MessageBox.Show("Please enter price", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPret.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Nume_produs from Produse where Nume_produs='" + txtNumeProdus.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Un produs cu acelasi nume exista deja", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNumeProdus.Text = "";
                    txtNumeProdus.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Produse(Nume_produs,Id_categorie,Pret) VALUES ('" + txtNumeProdus.Text + "'," + txtIdCategorie.Text+ "," + txtPret.Text + ")";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Salvat cu succes", "Rand", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Autocomplete();
                //GetData();
                btnSalvare.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vrei sa stergi ?", "Confirmare", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }
        private void delete_records()
        {

            try
            {

                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from Produse where Id_produs=" + txtIdProdus.Text + "";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Sters cu succes", "Rand", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                   // GetData();
                    Autocomplete();
                }
                else
                {
                    MessageBox.Show("Nici un rand gasit", "Ne pare rau", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    Autocomplete();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Autocomplete()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT distinct Nume_produs FROM Produse", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Produse");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["Nume_produs"].ToString());

                }
                txtNumeProdus.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtNumeProdus.AutoCompleteCustomSource = col;
                txtNumeProdus.AutoCompleteMode = AutoCompleteMode.Suggest;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtNumeProdus.Text == "")
            {
                MessageBox.Show("Introduce numele produsului", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumeProdus.Focus();
                return;
            }
            if (cmbCategorie.Text == "")
            {
                MessageBox.Show("Selecteaza categoria", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCategorie.Focus();
                return;
            }
       
            if (txtPret.Text == "")
            {
                MessageBox.Show("Introduce pretul", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPret.Focus();
                return;
            }
            try
            {
              
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update produse set Nume_produs='" + txtNumeProdus.Text + "',Id_categorie=" + txtIdCategorie.Text + ",pret=" + txtPret.Text + " Where Id_produs='" + txtIdProdus.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Actualizat cu succes", "Rand", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Autocomplete();
               // GetData();
                btnActualziare.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
     
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
             // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT Id from Categorii WHERE Nume_categorie = '" + cmbCategorie.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    txtIdCategorie.Text = rdr.GetInt32(0).ToString().Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(Id_produs),RTRIM(Nume_produs),RTRIM(Id_categorie),RTRIM(Nume_categorie),RTRIM(Pret) from Produse,Categorii where Produse.Id_categorie=Id_categorie and Nume_produs like '" + textBox1.Text + "%' order by Nume_produs", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            // or simply use column name instead of index
            //dr.Cells["id"].Value.ToString();
            txtIdProdus.Text = dr.Cells[0].Value.ToString();
            txtNumeProdus.Text = dr.Cells[1].Value.ToString();
            txtIdCategorie.Text = dr.Cells[2].Value.ToString();
            cmbCategorie.Text = dr.Cells[3].Value.ToString();
            txtPret.Text = dr.Cells[4].Value.ToString();
            btnSterge.Enabled = true;
            btnActualziare.Enabled = true;
            txtNumeProdus.Focus();
            btnSalvare.Enabled = false;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
    
        }
      
     
    }
}
