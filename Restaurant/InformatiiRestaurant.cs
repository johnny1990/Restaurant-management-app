using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace Restaurant
{
    public partial class InformatiiRestaurant : Form
    {
        SqlDataReader rdr = null;
        SqlConnection con = null;
        SqlCommand cmd = null;
        ConnectionString cs = new ConnectionString();
        public InformatiiRestaurant()
        {
            InitializeComponent();
        }
        public void Reset()
        {
            txtNumeRestaurant.Text = "";
            txtMobilDirector.Text = "";
            txtMobil.Text = "";
            txtAdresa.Text = "";
            txtIdNr.Text = "";
            txtSerie.Text = "";
            txtEmail.Text = "";
            btnSave.Enabled = true;            
            btnUpdate_record.Enabled = false;
            btnDelete.Enabled = false;
            txtNumeRestaurant.Focus();
        }
        private void frmHotelInfo_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtNumeRestaurant.Text=="")
            {
                MessageBox.Show("Introduce numele restaurantului", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumeRestaurant.Focus();
                return;
            }
            if (txtAdresa.Text =="")
            {
                MessageBox.Show("Introduce adresa", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAdresa.Focus();
                return;
            }
            if (txtMobil.Text == "")
            {
                MessageBox.Show("Introduce nr de contact.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMobil.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select count(*) from Informatii_restaurante Having count(*) >= 1";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Informatiile exista deja" + "\n" + "Actualizeaza informatiile restaurantului", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Informatii_restaurante( Nume_restaurant, Adresa, Mobil, Mobil_director, Email, Serie, Id_nr) VALUES ('" + txtNumeRestaurant.Text + "','" + txtAdresa.Text + "','" + txtMobil.Text + "','" + txtMobilDirector.Text + "','" + txtEmail.Text + "','" + txtSerie.Text + "','" + txtIdNr.Text + "',@d1)";
                cmd = new SqlCommand(cb);
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                MemoryStream ms = new MemoryStream();
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@d1",SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Salvat cu succes", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                GetData();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(ID), RTRIM(HotelName), RTRIM(Address), RTRIM(ContactNo), RTRIM(ContactNo1), RTRIM(Email), RTRIM(TIN), RTRIM(STNo), Logo from HotelInfo", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while ((rdr.Read() == true))
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtNumeRestaurant.Text == "")
                {
                    MessageBox.Show("Please enter restaurant name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNumeRestaurant.Focus();
                    return;
                }
                if (txtAdresa.Text == "")
                {
                    MessageBox.Show("Please enter address", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAdresa.Focus();
                    return;
                }
                if (txtMobil.Text == "")
                {
                    MessageBox.Show("Please enter contact no.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMobil.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update HotelInfo set  HotelName='" + txtNumeRestaurant.Text + "', Address='" + txtAdresa.Text + "', ContactNo='" + txtMobil.Text + "', ContactNo1='" + txtMobilDirector.Text + "', Email='" + txtEmail.Text + "', TIN='" + txtSerie.Text + "', STNo='" + txtIdNr.Text + "', Logo=@d1 where ID=" + txtID.Text + "";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                MemoryStream ms = new MemoryStream();           
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@d1", SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
                GetData();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteRecord()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from HotelInfo where ID=" + txtID.Text + "";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    GetData();
                }
                else
                {
                    MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    DeleteRecord();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                txtID.Text = dr.Cells[0].Value.ToString();
                txtNumeRestaurant.Text = dr.Cells[1].Value.ToString();
                txtAdresa.Text = dr.Cells[2].Value.ToString();
                txtMobil.Text = dr.Cells[3].Value.ToString();
                txtMobilDirector.Text = dr.Cells[4].Value.ToString();
                txtEmail.Text = dr.Cells[5].Value.ToString();
                txtSerie.Text = dr.Cells[6].Value.ToString();
                txtIdNr.Text = dr.Cells[7].Value.ToString();
                byte[] data = (byte[])dr.Cells[8].Value;
                MemoryStream ms = new MemoryStream(data);              
                btnDelete.Enabled = true;
                btnUpdate_record.Enabled = true;
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
