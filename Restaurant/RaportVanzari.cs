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
namespace Restaurant
{
    public partial class RaportVanzari : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr;
        public RaportVanzari()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            dtpInvoiceDateFrom.Text = System.DateTime.Today.ToString();
            dtpInvoiceDateTo.Text = System.DateTime.Today.ToString();
            crystalReportViewer1.ReportSource = null;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            dtpInvoiceDateFrom.Text = System.DateTime.Today.ToString();
            dtpInvoiceDateTo.Text = System.DateTime.Today.ToString();
            crystalReportViewer1.ReportSource = null;
            cmbCurrency.Text = "";
            dateTimePicker1.Text = System.DateTime.Today.ToString();
            dateTimePicker2.Text = System.DateTime.Today.ToString();
            crystalReportViewer2.ReportSource = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmbCurrency.Text = "";
            dateTimePicker1.Text = System.DateTime.Today.ToString();
            dateTimePicker2.Text = System.DateTime.Today.ToString();
            crystalReportViewer2.ReportSource = null;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                rptVanzari rpt = new rptVanzari();
                //The report you created.
                cmd = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                //The DataSet you created.
                con = new SqlConnection(cs.DBConn);
                cmd.Connection = con;
                cmd.CommandText = "SELECT Nr_factura,Data_factura,Valoare_TVA,Valoare_reducere,Total_general,Nume_moneda from Informatii_facturi,Moneda where Informatii_facturi.Id_moneda=Id_moneda and Data_factura between @d1 and @d2 order by Data_factura";
                cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Data_factura").Value = dtpInvoiceDateFrom.Value.Date;
                cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Data_factura").Value = dtpInvoiceDateTo.Value.Date;
                cmd.CommandType = CommandType.Text;
                myDA.SelectCommand = cmd;
                myDA.Fill(myDS, "Informatii_facturi");
                myDA.Fill(myDS, "Moneda");
                rpt.SetDataSource(myDS);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCurrency.Text == "")
                {
                    MessageBox.Show("Selectati moneda", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbCurrency.Focus();
                    return;
                }
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                rptVanzari rpt = new rptVanzari();
                //The report you created.
                cmd = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                //The DataSet you created.
                con = new SqlConnection(cs.DBConn);
                cmd.Connection = con;
                cmd.CommandText = "SELECT Nr_plata,Data_plata,Valoare_TVA,Valoare_reducere,Total_general,Nume_moneda from Informatii_facturi,Moneda where Informatii_facturi.Id_moneda=Id_moneda and Data_plata between @d1 and @d2 and Nume_moneda='" + cmbCurrency.Text + "' order by Data_plata";
                cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Data_plata").Value = dateTimePicker2.Value.Date;
                cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Data_plata").Value = dateTimePicker1.Value.Date;
                cmd.CommandType = CommandType.Text;
                myDA.SelectCommand = cmd;
                myDA.Fill(myDS, "Informatii_facturi");
                myDA.Fill(myDS, "Moneda");
                rpt.SetDataSource(myDS);
                crystalReportViewer2.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select distinct RTRIM(Nume_moneda) from Informatii_facturi,Moneda where Informatii_facturi.Id_moneda=Id_moneda";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbCurrency.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void f_Load(object sender, EventArgs e)
        {
            FillCombo();
        }
    }
}
