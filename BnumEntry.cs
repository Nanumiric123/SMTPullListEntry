using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMTPullListEntry
{
    public partial class BnumEntry : Form
    {
        public string BadgeNum;
        public BnumEntry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void txtNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNum.Text != "")
                {
                    txtPassword.Focus();
                }
                else
                {
                    MessageBox.Show("Enter Username");
                    txtNum.Focus();
                }
            }

        }

        private void BnumEntry_Load(object sender, EventArgs e)
        {
            txtNum.Focus();
        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNum.Text == "")
                {
                    MessageBox.Show("Enter Username");
                    txtNum.Focus();
                }
                else if (txtPassword.Text == "")
                {
                    MessageBox.Show("Enter Password");
                    txtPassword.Focus();
                }
                else
                {
                    if (CheckPasswordCorrect(txtNum.Text,txtPassword.Text))
                    {
                        BadgeNum = txtNum.Text;
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Wrong Badge Num or Password");
                        txtNum.Text = "";
                        txtPassword.Text = "";
                        txtNum.Focus();
                    }

                }
            }
        }

        private bool CheckPasswordCorrect(string username,string password)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=172.16.206.20;Initial Catalog=IBusiness;User ID=Data_writer;Password=Pasmy@2791381230");
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [IBusiness].[dbo].[ST_SY_User] WHERE [User] = @usr AND [Password] = @pwd", cnn);
            SqlParameter userparam = new SqlParameter();
            userparam.Value = username;
            userparam.ParameterName = "@usr";
            userparam.SqlDbType = SqlDbType.NVarChar;

            SqlParameter passwordParam = new SqlParameter();
            passwordParam.Value = password;
            passwordParam.ParameterName = "@pwd";
            passwordParam.SqlDbType= SqlDbType.NVarChar;

            cmd.Parameters.Add(userparam);
            cmd.Parameters.Add(passwordParam);
            int count = 0;
            try
            {
                cnn.Open();
                count = (int)cmd.ExecuteScalar();
            }
            catch
            {

            }
            finally
            {
                cnn.Close();
            }
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
