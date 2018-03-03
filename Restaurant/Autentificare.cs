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
    public partial class Autentificare : Form
    {
        #region Members
        private List<Table_Inregistrare> inregistrare = new List<Table_Inregistrare>();
        #endregion

        ConnectionString cs = new ConnectionString();
        DataTable dt = new DataTable();

        #region Construction
        public Autentificare()
        {
            InitializeComponent();
        }
        #endregion
        private void btnOK_Click(object sender, EventArgs e)
        {

            if (txtNumeUtilizator.Text == "")
            {
                MessageBox.Show("Introduce utilizatorul", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumeUtilizator.Focus();
                return;
            }
            if (txtParola.Text == "")
            {
                MessageBox.Show("Introduce parola", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtParola.Focus();
                return;
            }
            

            try
            {
                SqlConnection myConnection = default(SqlConnection);
                myConnection = new SqlConnection(cs.DBConn);

                SqlCommand myCommand = default(SqlCommand);

                //
               // inregistrare = InregistrareOperations.Get(null, null);
               //

                myCommand = new SqlCommand("SELECT Nume_utilizator,Parola FROM Inregistrare WHERE Nume_utilizator = @Nume_utilizator AND parola = @Parola", myConnection);
                SqlParameter uName = new SqlParameter("@Nume_utilizator", SqlDbType.VarChar);
                SqlParameter uPassword = new SqlParameter("@Parola", SqlDbType.VarChar);
                uName.Value = txtNumeUtilizator.Text;
                uPassword.Value = txtParola.Text;
                myCommand.Parameters.Add(uName);
                myCommand.Parameters.Add(uPassword);

                myCommand.Connection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (myReader.Read() == true)
                {
                    int i;
                    ProgressBar1.Visible = true;
                    ProgressBar1.Maximum = 5000;
                    ProgressBar1.Minimum = 0;
                    ProgressBar1.Value = 4;
                    ProgressBar1.Step = 1;

                    for (i = 0; i <= 5000; i++)
                    {
                        ProgressBar1.PerformStep();
                    }
                 
                        this.Hide();
                        MeniuPrincipal frm = new MeniuPrincipal();
                        frm.Show();
                        frm.lblUser.Text = txtNumeUtilizator.Text;
                 
                    }
                

                else
                {
                    MessageBox.Show("Login is Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtNumeUtilizator.Clear();
                    txtParola.Clear();
                    txtNumeUtilizator.Focus();

                }
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Dispose();
                }

              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      //OK
        private void Form1_Load(object sender, EventArgs e)
        {
            ProgressBar1.Visible = false;
            txtNumeUtilizator.Focus();
        }
        //OK
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            
        }
        //OK
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            
        }
        //OK
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SchimbaParola frm = new SchimbaParola();
            frm.Show();
            frm.txtNumeUtilizator.Text = "";
            frm.txtParolaNoua.Text = "";
            frm.txtParolaVeche.Text = "";
            frm.txtConfirmaParola.Text = "";
        }
        //OK
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RecuperareParola frm = new RecuperareParola();
            frm.txtEmail.Focus();
            frm.Show();
        }

     
    }
}
