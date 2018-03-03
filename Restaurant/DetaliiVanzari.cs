using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
namespace Restaurant
{
    public partial class DetaliiVanzari : Form
    {
   
    SqlConnection con = null;
    SqlCommand cmd = null;
    DataTable dt= new DataTable();
    SqlDataReader rdr;
    ConnectionString cs = new ConnectionString();
    
        public DetaliiVanzari()
        {
            InitializeComponent();
        }

     
        private void Button3_Click(object sender, EventArgs e)
        {
            if (DataGridView1.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = DataGridView1.RowCount - 1;
                colsTotal = DataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = DataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = DataGridView1.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

       
        private void Button2_Click(object sender, EventArgs e)
        {
        DataGridView1.DataSource = null;
        dtpInvoiceDateFrom.Text = DateTime.Today.ToString();
        dtpInvoiceDateTo.Text = DateTime.Today.ToString();
        GroupBox3.Visible = false;
        }

    
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
            GroupBox3.Visible = true;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = new SqlCommand("SELECT RTRIM(Invoice_Info.ID) as [Bill ID],RTRIM(BillNo) as [Bill No.],CONVERT(DateTime,BillDate,105) as [Bill Date],RTRIM(SubTotal) as [SubTotal],RTRIM(VATPer) as [Vat+ST %],RTRIM(VATAmount) as [VAT+ST Amount],RTRIM(DiscountPer) as [Discount %],RTRIM(DiscountAmount) as [Discount Amount],RTRIM(GrandTotal) as [Grand Total],RTRIM(Cash) as [Cash],RTRIM(Change) as [Change],RTRIM(Currency.ID) as [Currency ID],RTRIM(CurrencyName) as [Currency],Remarks from Invoice_Info,Currency where Invoice_Info.CurrencyID=Currency.ID and BillDate between @d1 and @d2 order by BillDate", con);
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "BillDate").Value = dtpInvoiceDateFrom.Value.Date;
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "BillDate").Value = dtpInvoiceDateTo.Value.Date;
            SqlDataAdapter myDA = new SqlDataAdapter(cmd);
            DataSet myDataSet = new DataSet();
            myDA.Fill(myDataSet, "Invoice_Info");
            DataGridView1.DataSource = myDataSet.Tables["Invoice_Info"].DefaultView;
            double sum = 0;
           
            foreach (DataGridViewRow r in this.DataGridView1.Rows)
            {
                double i = Convert.ToDouble(r.Cells[8].Value);
                sum = sum + i;
             
            }
            sum = Math.Round(sum, 2);
            TextBox1.Text = sum.ToString();
         
            con.Close();
            }
        catch (Exception ex)
            {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
      
        private void frmSalesRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Vanzari frm = new Vanzari();
            frm.Show();
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                Vanzari frmSales = new Vanzari();
                // or simply use column name instead of index
                // dr.Cells["id"].Value.ToString();
                frmSales.Show();
                frmSales.txtIdFactura.Text = dr.Cells[0].Value.ToString();
                frmSales.txtBillNo.Text = dr.Cells[1].Value.ToString();
                frmSales.dtpBillDate.Text = dr.Cells[2].Value.ToString();
                frmSales.txtSubTotal.Text = dr.Cells[3].Value.ToString();
                frmSales.txtTaxPer.Text = dr.Cells[4].Value.ToString();
                frmSales.txtTaxAmt.Text = dr.Cells[5].Value.ToString();
                frmSales.txtDiscountPer.Text = dr.Cells[6].Value.ToString();
                frmSales.txtDiscountAmount.Text = dr.Cells[7].Value.ToString();
                frmSales.txtTotal.Text = dr.Cells[8].Value.ToString();
                frmSales.txtCash.Text = dr.Cells[9].Value.ToString();
                frmSales.txtChange.Text = dr.Cells[10].Value.ToString();
                frmSales.txtIdMoneda.Text = dr.Cells[11].Value.ToString();
                frmSales.cmbMoneda.Text = dr.Cells[12].Value.ToString();
                frmSales.txtRemarks.Text = dr.Cells[13].Value.ToString();
                frmSales.btnUpdate.Enabled = true;
                frmSales.Delete.Enabled = true;
                frmSales.btnPrint.Enabled = true;
                frmSales.Salvare.Enabled = false;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT Product.ProductID,ProductSold.Productname,ProductSold.Price,ProductSold.Quantity,ProductSold.TotalAmount from Invoice_Info,ProductSold,Product where Invoice_info.ID=ProductSold.BillID and Product.ProductID=ProductSold.ProductID and invoice_Info.BillNo='" + dr.Cells[1].Value.ToString() + "'", con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read()==true)
                {
                    ListViewItem lst = new ListViewItem();
                    lst.SubItems.Add(rdr[0].ToString().Trim());
                    lst.SubItems.Add(rdr[1].ToString().Trim());
                    lst.SubItems.Add(rdr[2].ToString().Trim());
                    lst.SubItems.Add(rdr[3].ToString().Trim());
                    lst.SubItems.Add(rdr[4].ToString().Trim());
                    frmSales.ListView1.Items.Add(lst);
                 }
                frmSales.ListView1.Enabled = false;
                frmSales.Button7.Enabled = false;
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

     
    
      
        private void TabControl1_Click(object sender, EventArgs e)
        {
            DataGridView1.DataSource = null;
            dtpInvoiceDateFrom.Text = DateTime.Today.ToString();
            dtpInvoiceDateTo.Text = DateTime.Today.ToString();
            GroupBox3.Visible = false;
          
        }

        private void cmbCustomerName_Format(object sender, ListControlConvertEventArgs e)
        {
            if (object.ReferenceEquals(e.DesiredType, typeof(string)))
            {
                e.Value = e.Value.ToString().Trim();
            }
        }

        private void frmSalesRecord_Load(object sender, EventArgs e)
        {

        }
    }

}
