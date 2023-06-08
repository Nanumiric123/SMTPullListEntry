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
using SMTPullListEntry.PI_WS;

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
        private ThirdService _TSWS = new ThirdService();

        private bool CheckPasswordCorrect(string username,string password)
        {
           return _TSWS.LOGINSMTPULLLISTENTRY(username,password);

        }
    }
}
