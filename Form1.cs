using SMTPullListEntry.GETPARTLOC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SMTPullListEntry
{


    public partial class Form1 : Form
    {
        private string gLocation;
        private int gReelQty;
        private string gMaterial;
        private SqlConnection cnn;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (txtMaterial.Text == "")
                {

                    MessageBox.Show("Enter PART NUMBER");

                }
                else if (txtBnum.Text == "")
                {
                    txtBnum.Focus();
                    MessageBox.Show("Enter Badge Number ");
                }
                else
                {
                    if (checkAndTriggerIfWrongPnum(txtMaterial.Text))
                    {
                        lbl_qtyPerReel.Text = "Quantity / Reel : " + getMaterialQuantityPerReel(txtMaterial.Text.ToString());
                        Local_Ws_secondSoapClient client = new Local_Ws_secondSoapClient();
                        DataTable MatLoc = client.GetMaterialFromWH(txtMaterial.Text);

                        DataRow[] sapDataRow2602 = MatLoc.Select("StorageLocation=2602");
                        DataRow[] sapDataRow2006 = MatLoc.Select("StorageLocation=2006");
                        DataRow[] sapDataRow2001 = MatLoc.Select("StorageLocation=2001");
                        if (MatLoc.Rows.Count <= 0)
                        {
                            MessageBox.Show("No items in PASMY");
                        }
                        else
                        {

                            if (sapDataRow2602.Length > 0 && sapDataRow2602[0].ItemArray[2].ToString() != "")
                            {
                                lblLocation.Text = "Location : " + sapDataRow2602[0].ItemArray[2].ToString();
                                gLocation = sapDataRow2602[0].ItemArray[1].ToString();
                            }

                            if (sapDataRow2001.Length > 0 && sapDataRow2001[0].ItemArray[2].ToString() != "")
                            {
                                lblLocation.Text = "Location : " + sapDataRow2001[0].ItemArray[2].ToString();
                                gLocation = sapDataRow2001[0].ItemArray[2].ToString();
                            }

                            if (sapDataRow2006.Length > 0 && sapDataRow2006[0].ItemArray[2].ToString() != "")
                            {
                                lblLocation.Text = "Location : " + sapDataRow2006[0].ItemArray[2].ToString();
                                gLocation = sapDataRow2006[0].ItemArray[2].ToString();
                            }

                            if (sapDataRow2006.Length == 0 && sapDataRow2602.Length == 0 && sapDataRow2001.Length == 0 || gLocation == "")
                            {
                                DataTable dt = client.GET_BIN_FROM_006(txtMaterial.Text);
                                gLocation = dt.Rows[0][2].ToString();
                                lblLocation.Text = "Location : " + gLocation;
                            }
                        }
                        gMaterial = txtMaterial.Text;
                        txtQty.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Wrong PN ");
                        txtMaterial.Text = "";
                        txtMaterial.Focus();
                    }

                    


                }


            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMaterial.Text == "")
                {
                    MessageBox.Show("Enter PART NUMBER");
                }
                else if (txtQty.Text == "")
                {
                    MessageBox.Show("Enter reel qty");
                }
                else if (txtBnum.Text == "")
                {
                    MessageBox.Show("Enter Badge Number ");
                }
                else
                {
                    decimal qtyPerReel = (decimal)getQuantityPerReel(txtMaterial.Text);
                    decimal reqQty = 0m;
                    try
                    {
                        reqQty = decimal.Parse(txtQty.Text);
                    }
                    catch
                    {
                        reqQty = 1;
                    }
                    decimal ReelQty = 0;

                    try
                    {
                        ReelQty = reqQty / qtyPerReel;
                    }
                    catch
                    {

                    }



                    ReelQty = Math.Ceiling(ReelQty);
                    gReelQty = (int)ReelQty;
                    decimal total = gReelQty * qtyPerReel;
                    lblReelNum.Text = "Reel Quantity : " + ReelQty.ToString() + " = " + total.ToString() + " PC"; ;

                }

              

            }
        }

        private List<string> getListOfMaterialForSuggestion()
        {
            List<string> materials = new List<string>();

            SqlCommand cmd = new SqlCommand("SELECT DISTINCT [MATERIAL] FROM [IBusinessTest].[dbo].[SMT2006TRIGERRING]", cnn);

            try
            {
                cnn.Open();
                using (cmd)
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string resultMaterial = reader.GetString(0);
                            materials.Add(resultMaterial);
                        }
                    }
                }
            }
            catch
            {

            }
            finally
            {
                cnn.Close();
            }


            return materials;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            cnn = new SqlConnection(@"Data Source=172.16.206.20;Initial Catalog=IBusinessTest;User ID=Data_writer;Password=Pasmy@2791381230");


            AutoCompleteStringCollection autoCompleteItems = new AutoCompleteStringCollection();
            autoCompleteItems.AddRange(getListOfMaterialForSuggestion().ToArray());
            txtMaterial.AutoCompleteCustomSource = autoCompleteItems;
            txtMaterial.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtMaterial.AutoCompleteSource = AutoCompleteSource.CustomSource;


            if (txtBnum.Text == "")
            {
                BnumEntry bnument = new BnumEntry();
                DialogResult result = bnument.ShowDialog();
                if(result == DialogResult.OK)
                {
                    txtMaterial.Focus();
                    regenerateDG(bnument.BadgeNum);
                    txtBnum.Text = bnument.BadgeNum.ToString();
                }
                else
                {
                    this.Close();

                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveData();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            LBLMESSAGE.Visible = false;
            lblLocation.Text = "Location : ";
            lblMaterial.Text = "Material : ";
            txtMaterial.Text = "";
            txtQty.Text = "";
            lblReelNum.Text = "Reel Number : ";
            gLocation = "";
            gMaterial = "";
            gReelQty = 0;
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            foreach(char c in txtQty.Text)
            {
                if (char.IsLetter(c))
                {
                    txtQty.Text = "";
                }
            }
        }

        private void generatePullList_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGeneratePullList_Click(object sender, EventArgs e)
        {
            try
            {
                GnerateSMTPullList gp = new GnerateSMTPullList();
                gp.SMTPullList(txtBnum.Text);
                regenerateDG(txtBnum.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void datagridReqData_SelectionChanged(object sender, EventArgs e)
        {
            if (datagridReqData.SelectedRows.Count > 0)
            {
                /*
                if (btnDeleteSelected.Enabled)
                {
                    btnDeleteSelected.Enabled = false;
                }
                else
                {

                }
                */
                btnDeleteSelected.Enabled = true;
            }
            else
            {
                btnDeleteSelected.Enabled = false;
            }
           

        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            // Loop through the selected rows
            foreach (DataGridViewRow row in datagridReqData.SelectedRows)
            {
                // Get the data from each cell in the row
                string cell1Value = row.Cells[0].Value.ToString();
                deleteFromSQL(cell1Value);

            }

            regenerateDG(txtBnum.Text);
            btnDeleteSelected.Enabled = false;
        }



        private void txtMaterial_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBnum_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtBnum_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtMaterial.Focus();
            }
        }

      

        private int getQuantityPerReel(string material)
        {

            SqlCommand cmd = new SqlCommand("SELECT [REEL] FROM [IBusinessTest].[dbo].[SMT2006TRIGERRING] where [MATERIAL] = @mat", cnn);
            SqlParameter param = new SqlParameter();
            param.SqlDbType = SqlDbType.NVarChar;
            param.ParameterName = "@mat";
            param.Value = material;
            cmd.Parameters.Add(param);
            int qty = 0;
            try
            {
                cnn.Open();
                qty = (int)cmd.ExecuteScalar();

                return qty;
            }
            catch (Exception ex)
            {
                LBLMESSAGE.Visible = true;
                LBLMESSAGE.Text = "WARNING : Theres no reel quantity \n data in SMT Trigerring";
                return 0;

            }
            finally
            {
                cnn.Close();

            }


        }

        private void regenerateDG(string badgeNum)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT [PART_NUMBER],[SHORTAGE_QTY],[RECEIVED_QTY],[REF_LOC],[PRINTED],[REF_NUM_REEL] FROM [IBusinessTest].[dbo].[SMT_PULLLIST] WHERE [PRINTED] = '0' and [BADGE] = @bad ", cnn);
            SqlParameter p = new SqlParameter();
            p.ParameterName = "@bad";
            p.Value = badgeNum;
            p.SqlDbType = SqlDbType.NVarChar;

            da.SelectCommand.Parameters.Add(p);

            try
            {
                cnn.Open();
                da.Fill(dt);
            }
            catch
            {

            }
            finally
            {
                cnn.Close();
            }

            datagridReqData.DataSource = dt;

        }
        private void deleteFromSQL(string material)
        {

            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[SMT_PULLLIST] WHERE [PART_NUMBER] = @mat", cnn);

            SqlParameter Matparam = new SqlParameter();
            Matparam.SqlDbType = SqlDbType.NVarChar;
            Matparam.ParameterName = "@mat";
            Matparam.Value = material;
            cmd.Parameters.Add(Matparam);
            try
            {
                cnn.Open();

                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                cnn.Close();
            }
        }

        public int getMaterialQuantityPerReel(string mat)
        {
            if(cnn == null)
            {
                cnn = new SqlConnection(@"Data Source=172.16.206.20;Initial Catalog=IBusinessTest;User ID=Data_writer;Password=Pasmy@2791381230");
            }
            SqlCommand cmd = new SqlCommand("SELECT [MATERIAL],[REEL] FROM [IBusinessTest].[dbo].[SMT2006TRIGERRING] WHERE [MATERIAL] = @material", cnn);
            SqlParameter matPara = new SqlParameter();
            matPara.ParameterName = "@material";
            matPara.Value = mat;
            matPara.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(matPara);
            int resultQtyPerReel = 0;
            try
            {
                cnn.Open();
                using (cmd)
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string resultMaterial = reader.GetString(0);
                            Int32 resultQty = reader.GetInt32(1);
                            resultQtyPerReel = resultQty;
                        }
                    }
                }
            }
            catch
            {

            }
            finally
            {
                cnn.Close();
            }
            return resultQtyPerReel;
        }

        private bool checkAndTriggerIfWrongPnum(string Pnum)
        {
            List<string> list = getListOfMaterialForSuggestion();
            var result = list.Where(n => n == Pnum).ToList();

            if (result.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void saveData()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[SMT_PULLLIST] ([PART_NUMBER],[SHORTAGE_QTY],[RECEIVED_QTY] ,[REF_LOC],[PRINTED],[REF_NUM_REEL],[BADGE],[DATE_TIME]) VALUES (@mat,@qty,0,@loc,0,@numReel,@bnum,GETDATE())", cnn);
            SqlParameter Matparam = new SqlParameter();
            Matparam.SqlDbType = SqlDbType.NVarChar;
            Matparam.ParameterName = "@mat";
            Matparam.Value = gMaterial;
            cmd.Parameters.Add(Matparam);
            int reqQty = 0;


            try
            {
                reqQty = int.Parse(txtQty.Text);
            }
            catch
            {
                reqQty = 0;
            }

            SqlParameter qtyParam = new SqlParameter();
            qtyParam.SqlDbType = SqlDbType.Int;
            qtyParam.ParameterName = "@qty";
            qtyParam.Value = reqQty;
            cmd.Parameters.Add(qtyParam);

            SqlParameter ReelqtyParam = new SqlParameter();
            ReelqtyParam.SqlDbType = SqlDbType.Int;
            ReelqtyParam.ParameterName = "@numReel";
            ReelqtyParam.Value = gReelQty;
            cmd.Parameters.Add(ReelqtyParam);

            SqlParameter LocParam = new SqlParameter();
            LocParam.SqlDbType = SqlDbType.NVarChar;
            LocParam.ParameterName = "@loc";
            LocParam.Value = gLocation;
            cmd.Parameters.Add(LocParam);

            SqlParameter badgeParam = new SqlParameter();
            badgeParam.SqlDbType = SqlDbType.NVarChar;
            badgeParam.ParameterName = "@bnum";
            badgeParam.Value = txtBnum.Text;
            cmd.Parameters.Add(badgeParam);


            if (gMaterial == "")
            {
                MessageBox.Show("Click and Press Enter in the [Material :] Box");
            }
            else if (txtQty.Text == "")
            {
                MessageBox.Show("Click,Input quantity and Press Enter in the [Quantity :] Box");
            }
            else if (txtBnum.Text == "")
            {
                MessageBox.Show("Enter Badge Number ");
            }
            else
            {
                try
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    cnn.Close();
                    regenerateDG(txtBnum.Text);
                    LBLMESSAGE.Visible = false;
                    lblLocation.Text = "Location : ";
                    lblMaterial.Text = "Material : ";
                    lbl_qtyPerReel.Text = "Quantity / Reel : ";
                    txtMaterial.Text = "";
                    txtQty.Text = "";
                    lblReelNum.Text = "Reel Number : ";
                    gLocation = "";
                    gMaterial = "";
                    gReelQty = 0;
                }
            }
        }
    }
}
