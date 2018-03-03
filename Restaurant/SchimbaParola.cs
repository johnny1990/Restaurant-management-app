using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Restaurant
{
    public partial class SchimbaParola : Form
    {
       
       SqlConnection con = null;
       SqlCommand cmd = null;
        ConnectionString cs = new ConnectionString();
        public SchimbaParola()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int RowsAffected = 0;
                if ((txtNumeUtilizator.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNumeUtilizator.Focus();
                    return;
                }
                if ((txtParolaVeche.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Please enter old password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtParolaVeche.Focus();
                    return;
                }
                if ((txtParolaNoua.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Please enter new password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtParolaNoua.Focus();
                    return;
                }
                if ((txtConfirmaParola.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Please confirm new password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtConfirmaParola.Focus();
                    return;
                }
                if ((txtParolaNoua.TextLength < 5))
                {
                    MessageBox.Show("The New Password Should be of Atleast 5 Characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtParolaNoua.Text = "";
                    txtConfirmaParola.Text = "";
                    txtParolaNoua.Focus();
                    return;
                }
                else if ((txtParolaNoua.Text != txtConfirmaParola.Text))
                {
                    MessageBox.Show("Password do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtParolaNoua.Text = "";
                    txtParolaVeche.Text = "";
                    txtConfirmaParola.Text = "";
                    txtParolaVeche.Focus();
                    return;
                }
                else if ((txtParolaVeche.Text == txtParolaNoua.Text))
                {
                    MessageBox.Show("Password is same..Re-enter new password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtParolaNoua.Text = "";
                    txtConfirmaParola.Text = "";
                    txtParolaNoua.Focus();
                    return;
                }
              
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string co = "Update Inregistrare set Parola = '" + txtParolaNoua.Text + "'where UserName='" + txtNumeUtilizator.Text + "' and Password = '" + txtParolaVeche.Text + "'";

                cmd = new SqlCommand(co);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if ((RowsAffected > 0))
                {
                    MessageBox.Show("Schimbat cu succes", "Parola", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    txtNumeUtilizator.Text = "";
                    txtParolaNoua.Text = "";
                    txtParolaVeche.Text = "";
                    txtConfirmaParola.Text = "";
                    Autentificare LoginForm1 = new Autentificare();
                    LoginForm1.Show();
                    LoginForm1.txtNumeUtilizator.Text = "";
                    LoginForm1.txtParola.Text = "";
                    LoginForm1.ProgressBar1.Visible = false;
                    LoginForm1.txtNumeUtilizator.Focus();
                }
                else
                {
                    MessageBox.Show("Nume utilizator sau parola gresite", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNumeUtilizator.Text = "";
                    txtParolaNoua.Text = "";
                    txtParolaVeche.Text = "";
                    txtConfirmaParola.Text = "";
                    txtNumeUtilizator.Focus();
                }
                if ((con.State == ConnectionState.Open))
                {
                    con.Close();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SchimbaParola_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Autentificare frm = new Autentificare();
            frm.txtNumeUtilizator.Text = "";
            frm.txtParola.Text = "";
            frm.ProgressBar1.Visible = false;
            frm.txtNumeUtilizator.Focus();
            frm.Show();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

        }

    }
}
