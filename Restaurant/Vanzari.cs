using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using Restaurant.Business.Clase;
using Restaurant.Business.Operatii;

namespace Restaurant
{
    public partial class Vanzari : Form
    {
        #region Members
        private List<Table_Produse> produse = new List<Table_Produse>();
        private List<Table_Moneda> moneda = new List<Table_Moneda>();
        #endregion
        SqlCommand cmd;
        SqlConnection con;
        DataTable dtable;
        SqlDataAdapter adp;
        DataSet ds;
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr;
        public Vanzari()
        {
            InitializeComponent();
            //cmbNumeProdus.DataSource = ProduseOperations.Get(null, null).ToList();
           // cmbNumeProdus.DisplayMember = "Nume_produs";
           // cmbMoneda.DataSource = MonedaOperations.Get(null, null).ToList();
           // cmbMoneda.DisplayMember = "Nume_moneda";
        }

        private void auto()
        {
          int Num = 0;
          con = new SqlConnection(cs.DBConn);
          con.Open();
          string sql = "SELECT MAX(Id+1) FROM Informatii_facturi";
          cmd = new SqlCommand(sql);
          cmd.Connection = con;
          if (Convert.IsDBNull(cmd.ExecuteScalar()))
          {
          Num = 1;
          txtIdFactura.Text = Convert.ToString(Num);
          txtBillNo.Text = Convert.ToString("B" + Num);
       }
       else {
       Num =(int)(cmd.ExecuteScalar());
          txtIdFactura.Text = Convert.ToString(Num);
          txtBillNo.Text = Convert.ToString("B" + Num);
      }
          cmd.Dispose();
          con.Close();
          con.Dispose();
        
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMoneda.Text == "")
                {
                    MessageBox.Show("Selecteaza moneda", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   cmbMoneda.Focus();
                    return;
                }
                if (txtTaxPer.Text == "")
                {
                    MessageBox.Show("Please enter tax percentage", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTaxPer.Focus();
                    return;
                }
                if (txtDiscountPer.Text == "")
                {
                    MessageBox.Show("Please enter discount percentage", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDiscountPer.Focus();
                    return;
                }
                if (txtCash.Text == "")
                {
                    MessageBox.Show("Please enter Cash", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCash.Focus();
                    return;
                }

                if (ListView1.Items.Count == 0)
                {
                    MessageBox.Show("sorry no product added", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                auto();

                con = new SqlConnection(cs.DBConn);
                con.Open();

                string cb = "insert Into Informatii_facturi(Nr_factura,Data_factura,Subtotal,Tva_per,Valoare_tva,Reducere_per,Valoare_reducere,Total_general,Cash,Change,Opinii,Id_moneda,Id_restaurant) VALUES ('" + txtBillNo.Text + "','" + dtpBillDate.Text + "','" + txtSubTotal.Text + "','" + txtTaxPer.Text + "','" + txtTaxAmt.Text + "','" + txtDiscountPer.Text + "','" + txtDiscountAmount.Text + "','" + txtTotal.Text + "','" + txtCash.Text + "','" + txtChange.Text + "','" + txtRemarks.Text + "','" + txtIdMoneda.Text + "','"+ txtIdRestaurant.Text +"')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Close();


                for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                {
                    con = new SqlConnection(cs.DBConn);

                    string cd = "insert Into Produse_vandute(Id_factura,Id_produs,Nume_produs,Cantitate,Pret,Valoare_totala) VALUES (@d1,@d2,@d3,@d4,@d5,@d6)";
                    cmd = new SqlCommand(cd);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("d1", txtIdFactura.Text);
                    cmd.Parameters.AddWithValue("d2", ListView1.Items[i].SubItems[1].Text);
                    cmd.Parameters.AddWithValue("d3", ListView1.Items[i].SubItems[2].Text);
                    cmd.Parameters.AddWithValue("d4", ListView1.Items[i].SubItems[4].Text);
                    cmd.Parameters.AddWithValue("d5", ListView1.Items[i].SubItems[3].Text);
                    cmd.Parameters.AddWithValue("d6", ListView1.Items[i].SubItems[5].Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
             
                Salvare.Enabled = false;
                btnPrint.Enabled = true;
                MessageBox.Show("Adaugat cu succes", "Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void Calculate()
        {

            try{
                double val1 = 0;
                double val2 = 0;
                double val3 = 0;
                double val4 = 0;
                double val5 = 0;
            if (txtTaxPer.Text != "")
            {
                val1 = Convert.ToDouble((Convert.ToDouble(txtSubTotal.Text) * Convert.ToDouble(txtTaxPer.Text) / 100));
                val1 = Math.Round(val1, 2);
                txtTaxAmt.Text = val1.ToString();

            }
            if (txtDiscountPer.Text != "")
            {
                val3 = Convert.ToDouble(((Convert.ToDouble(txtSubTotal.Text) + Convert.ToDouble(txtTaxAmt.Text)) * Convert.ToDouble(txtDiscountPer.Text) / 100));
                val3 = Math.Round(val3, 2);
                txtDiscountAmount.Text = val3.ToString();
            }
            
            double.TryParse(txtTaxAmt.Text, out val1);
            double.TryParse(txtSubTotal.Text, out val2);
            double.TryParse(txtDiscountAmount.Text, out val3);
            double.TryParse(txtTotal.Text, out val4);
            double.TryParse(txtCash.Text, out val5);
            val1 = Math.Round(val1, 2);
            val2 = Math.Round(val2, 2);
            val3 = Math.Round(val3, 2);
            val4 = val1 + val2 - val3;
            val4 = Math.Round(val4, 2);
            txtTotal.Text = val4.ToString();
            double I = (val5 - val4);
            I = Math.Round(I, 2);
            txtChange.Text = I.ToString();
              }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtSaleQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double val1 = 0;
                double val2 = 0;
                double.TryParse(txtPret.Text, out val1);
                double.TryParse(txtCant.Text, out val2);
                val1 = Math.Round(val1, 2);
                val2 = Math.Round(val2, 2);
                double I = (val1 * val2);
                I = Math.Round(I, 2);
                txtValoareTotala.Text = I.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public double subtot()
        {
            int i = 0;
            int j = 0;
            double k = 0;
            i = 0;
            j = 0;
            k = 0;


            try
            {

                j = ListView1.Items.Count;
                for (i = 0; i <= j - 1; i++)
                {
                    k = k + Convert.ToDouble(ListView1.Items[i].SubItems[5].Text);
                    k = Math.Round(k, 2);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return k;

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            try
            {

                if (cmbNumeProdus.Text == "")
                {
                    MessageBox.Show("Please select product name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtCant.Text == "")
                {
                    MessageBox.Show("Please enter quantity", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCant.Focus();
                    return;
                }
                int SaleQty = Convert.ToInt32(txtCant.Text);
                if (SaleQty == 0)
                {
                    MessageBox.Show("no. of quantity can not be zero", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCant.Focus();
                    return;
                }

                if (ListView1.Items.Count == 0)
                {

                    ListViewItem lst = new ListViewItem();
                    lst.SubItems.Add(txtIdProdus.Text);
                    lst.SubItems.Add(cmbNumeProdus.Text);
                    lst.SubItems.Add(txtPret.Text);
                    lst.SubItems.Add(txtCant.Text);
                    lst.SubItems.Add(txtValoareTotala.Text);
                    ListView1.Items.Add(lst);
                    txtSubTotal.Text = subtot().ToString();

                    Calculate();
                    cmbNumeProdus.Text = "";
                    txtIdProdus.Text = "";
                    txtPret.Text = "";
                    txtCant.Text = "";
                    txtValoareTotala.Text = "";
                    return;
                }

                for (int j = 0; j <= ListView1.Items.Count - 1; j++)
                {
                    if (ListView1.Items[j].SubItems[1].Text == txtIdProdus.Text)
                    {
                        ListView1.Items[j].SubItems[1].Text = txtIdProdus.Text;
                        ListView1.Items[j].SubItems[2].Text = cmbNumeProdus.Text;
                        ListView1.Items[j].SubItems[3].Text = txtPret.Text;
                        ListView1.Items[j].SubItems[4].Text = (Convert.ToInt32(ListView1.Items[j].SubItems[4].Text) + Convert.ToInt32(txtCant.Text)).ToString();
                        ListView1.Items[j].SubItems[5].Text = (Convert.ToInt32(ListView1.Items[j].SubItems[5].Text) + Convert.ToInt32(txtValoareTotala.Text)).ToString();
                        txtSubTotal.Text = subtot().ToString();
                        Calculate();
                        cmbNumeProdus.Text = "";
                        txtIdProdus.Text = "";
                        txtPret.Text = "";
                        txtCant.Text = "";
                        txtValoareTotala.Text = "";
                        return;

                    }
                }

                ListViewItem lst1 = new ListViewItem();

                lst1.SubItems.Add(txtIdProdus.Text);
                lst1.SubItems.Add(cmbNumeProdus.Text);
                lst1.SubItems.Add(txtPret.Text);
                lst1.SubItems.Add(txtCant.Text);
                lst1.SubItems.Add(txtValoareTotala.Text);
                ListView1.Items.Add(lst1);
                txtSubTotal.Text = subtot().ToString();
                Calculate();
                cmbNumeProdus.Text = "";
                txtIdProdus.Text = "";
                txtPret.Text = "";
                txtCant.Text = "";
                txtValoareTotala.Text = "";
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListView1.Items.Count == 0)
                {
                    MessageBox.Show("No items to remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int itmCnt = 0;
                    int i = 0;
                    int t = 0;

                    ListView1.FocusedItem.Remove();
                    itmCnt = ListView1.Items.Count;
                    t = 1;

                    for (i = 1; i <= itmCnt + 1; i++)
                    {
                        //Dim lst1 As New ListViewItem(i)
                        //ListView1.Items(i).SubItems(0).Text = t
                        t = t + 1;

                    }
                    txtSubTotal.Text = subtot().ToString();
                    Calculate();
                }

                btnSterge.Enabled = false;
                if (ListView1.Items.Count == 0)
                {
                    txtSubTotal.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTaxPer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTaxPer.Text))
                {
                    txtTaxAmt.Text = "";
                    txtTotal.Text = "";
                    return;
                }
                Calculate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSterge.Enabled = true;
        }





        private void Reset()
        {
            txtBillNo.Text = "";
            dtpBillDate.Text = DateTime.Today.ToString();

            cmbNumeProdus.Text = "";
            txtIdProdus.Text = "";
            txtPret.Text = "";

            txtCant.Text = "";
            txtValoareTotala.Text = "";
            ListView1.Items.Clear();
            txtDiscountAmount.Text = "";
            txtDiscountPer.Text = "";
            cmbMoneda.Text = "";
            txtSubTotal.Text = "";
            txtTaxPer.Text = "";
            txtTaxAmt.Text = "";
            txtTotal.Text = "";
            txtCash.Text = "";
            txtChange.Text = "";
            txtRemarks.Text = "";
            Salvare.Enabled = true;
            Delete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSterge.Enabled = false;
            btnPrint.Enabled = false;
            ListView1.Enabled = true;
            Button7.Enabled = true;

        }

        private void NewRecord_Click(object sender, EventArgs e)
        {
            Reset();
            Reset();
        }

        private void Delete_Click(object sender, EventArgs e)
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

                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq1 = "delete from Produse_vandute where Id_factura =" + txtIdFactura.Text + "";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from Informatii_facturi where Id_factura= " + txtIdFactura.Text + "";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtTotalPayment_TextChanged(object sender, EventArgs e)
        {
            Calculate();
                
        }

     
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                rptFactura rpt = new rptFactura();
                //The report you created.
                cmd = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                //The DataSet you created.
                con = new SqlConnection(cs.DBConn);
                cmd.Connection = con;
                // de inlocuit
                cmd.CommandText = "SELECT Nr_factura,Data_factura,Subtotal,TVA_per,Valoare_TVA,Reducere_per,Valoare_reducere,Total_general,Cash,Change,Opinii,Id_moneda,Id_restaurant,Id_factura,Id_produs,Nume_produs,Cantitate,Pret,Valoare_totala,Nume_moneda,Nume_restaurant, Adresa, Mobil, Mobil_director, Email, Serie, Id_nr from Informatii_facturi,Produse_vandute,Moneda,Informatii_restaurante where Informatii_facturi.Id=Produse_vandute.Id_factura and Informatii_facturi.Id_moneda=Moneda.Id and Informatii_facturi.Id_restaurant=Informatii_restaurante.Id and Informatii_facturi.Nr_factura='" + txtBillNo.Text + "'";                
                // de inlocuit                                                                                                                                                
                cmd.CommandType = CommandType.Text;
                myDA.SelectCommand = cmd;
                myDA.Fill(myDS, "Informatii_facturi");
                myDA.Fill(myDS, "Produse_vandute");
                myDA.Fill(myDS, "Informatii_restaurante");
                myDA.Fill(myDS, "Moneda");
                rpt.SetDataSource(myDS);
                RaportFactura frm = new RaportFactura();
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMoneda.Text == "")
                {
                    MessageBox.Show("Please select currency", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbMoneda.Focus();
                    return;
                }
                if (txtTaxPer.Text == "")
                {
                    MessageBox.Show("Please enter tax percentage", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTaxPer.Focus();
                    return;
                }
                if (txtDiscountPer.Text == "")
                {
                    MessageBox.Show("Please enter discount percentage", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDiscountPer.Focus();
                    return;
                }
                if (txtCash.Text == "")
                {
                    MessageBox.Show("Please enter Cash", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCash.Focus();
                    return;
                }

                if (ListView1.Items.Count == 0)
                {
                    MessageBox.Show("sorry no product added", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String cb = "update Informatii_facturi set  Tva_per=" + txtTaxPer.Text + ",Valoare_TVA=" + txtTaxAmt.Text + ",Reducere_per=" + txtDiscountPer.Text + ",Valoare_reducere=" + txtDiscountAmount.Text + ",Total_general= " + txtTotal.Text + ",Cash= " + txtCash.Text + ",Change= " + txtChange.Text + ",Opinii='" + txtRemarks.Text + "',id_moneda=" + txtIdMoneda.Text + " where Nr_plata= '" + txtBillNo.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                btnUpdate.Enabled = false;
                MessageBox.Show("Adaugat cu succes", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void txtSaleQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

      
        private void txtTaxPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtDiscountPer_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }
        public void FillCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Nume_produs) from Produse order by Nume_produs";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbNumeProdus.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Vanzari_Load(object sender, EventArgs e)
        {
            FillCombo();
            HotelID();
            fillCurrency();// cmbMoneda
        }
        public void fillCurrency()
        {
            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(Nume_moneda) FROM Moneda", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                cmbMoneda.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    cmbMoneda.Items.Add(drow[0].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void HotelID()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Id FROM Informatii_restaurante";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtIdRestaurant.Text = rdr.GetValue(0).ToString();
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
        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT Id_produs,Pret from Produse WHERE Nume_produs = '" + cmbNumeProdus.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    txtIdProdus.Text = rdr.GetInt32(0).ToString().Trim();
                    txtPret.Text = rdr.GetValue(1).ToString().Trim();
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

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            this.Hide();
            DetaliiVanzari frm = new DetaliiVanzari();
            frm.DataGridView1.DataSource = null;
            frm.dtpInvoiceDateFrom.Text = DateTime.Today.ToString();
            frm.dtpInvoiceDateTo.Text = DateTime.Today.ToString();
            frm.GroupBox3.Visible = false;
            frm.Show();
        }

        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Id FROM Moneda where Nume_moneda='" + cmbMoneda.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtIdMoneda.Text = rdr.GetValue(0).ToString();
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
    }
}