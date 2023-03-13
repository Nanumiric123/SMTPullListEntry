using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Drawing;
using ZXing;
using ZXing.QrCode;
using static System.Collections.Specialized.BitVector32;
using Font = MigraDoc.DocumentObjectModel.Font;
using Section = MigraDoc.DocumentObjectModel.Section;

namespace SMTPullListEntry
{
    public class PULLLISTINFO
    {
        public string pullListNo { get; set; }
        public DateTime datetime { get; set; }
        public string badgeNum { get; set; }
    }

    internal class GnerateSMTPullList
    {

        private DataTable getdata(string badgeNum)
        {
            Form1 f1 = new Form1();

            DataTable table = new DataTable();

            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT [ID],[PART_NUMBER],[SHORTAGE_QTY],[RECEIVED_QTY],[REF_LOC],[PRINTED],[REF_NUM_REEL],[BADGE] FROM [IBusinessTest].[dbo].[SMT_PULLLIST] where [PRINTED]= '0' and [BADGE] = @bad ORDER BY [REF_LOC]", cnn);
            SqlParameter p = new SqlParameter();
            p.ParameterName = "@bad";
            p.Value = badgeNum;
            p.SqlDbType = SqlDbType.NVarChar;

            da.SelectCommand.Parameters.Add(p);

            try
            {
                cnn.Open();
                da.Fill(table);
                table.Columns.Add("StandardQty",typeof(int));
                for(int i =0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];
                    int ReelQty;
                    bool success = int.TryParse(row["REF_NUM_REEL"].ToString(), out ReelQty);
                    if (success)
                    {
                        row["StandardQty"] = ReelQty * f1.getMaterialQuantityPerReel(row["PART_NUMBER"].ToString());
                    }
                    else{
                        row["StandardQty"] = 0;
                    }

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cnn.Close();
            }


            return table;
        }

        private void updatePullList(string newValue,string badgeNum)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string sqlQry = "INSERT INTO [dbo].[SMT_PULL_LIST_NUMBER_TRACKING] ([PULL_LIST_NO],[DATEANDTIME],[BADGE_NUM]) " +
                "VALUES (@newpullListNum,@newdatetime,@newbNum)";
            SqlCommand cmd = new SqlCommand(sqlQry, cnn);
            SqlParameter PpullListNumb = new SqlParameter();
            PpullListNumb.ParameterName = "@newpullListNum";
            PpullListNumb.Value = newValue;
            PpullListNumb.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(PpullListNumb);

            SqlParameter PparadateFrom = new SqlParameter();
            PparadateFrom.ParameterName = "@newdatetime";
            PparadateFrom.Value = DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss");
            PparadateFrom.SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.Add(PparadateFrom);

            SqlParameter paraBnum = new SqlParameter();
            paraBnum.SqlDbType = SqlDbType.NVarChar;
            paraBnum.Value = badgeNum;
            paraBnum.ParameterName = "@newbNum";
            cmd.Parameters.Add(paraBnum);

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
            }
        }

        private string pullListNo(string badgeNum)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string sqlQry = "SELECT [PULL_LIST_NO],[DATEANDTIME],[BADGE_NUM] FROM [IBusinessTest].[dbo].[SMT_PULL_LIST_NUMBER_TRACKING] " +
                "WHERE [DATEANDTIME] BETWEEN @dateFrom AND @dateTo AND [BADGE_NUM] = @bNum ORDER BY [DATEANDTIME] DESC";
            SqlCommand cmd = new SqlCommand(sqlQry, cnn);
            SqlParameter paraDateTo = new SqlParameter();
            SqlParameter paradateFrom = new SqlParameter();
            SqlParameter paraBnum = new SqlParameter();
            paraBnum.SqlDbType = SqlDbType.NVarChar;
            paraBnum.Value = badgeNum;
            paraBnum.ParameterName = "@bNum";

            paraDateTo.SqlDbType = SqlDbType.DateTime;
            paraDateTo.Value = DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59";
            paraDateTo.ParameterName = "@dateTo";

            paradateFrom.SqlDbType = SqlDbType.DateTime;
            paradateFrom.Value = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00";
            paradateFrom.ParameterName = "@dateFrom";

            cmd.Parameters.Add(paraBnum);
            cmd.Parameters.Add(paraDateTo);
            cmd.Parameters.Add(paradateFrom);
            string pulllistNo = "";
            List<PULLLISTINFO> PLINFO = new List<PULLLISTINFO>();

            try
            {
                cnn.Open();
                using (cmd)
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PULLLISTINFO PLI = new PULLLISTINFO();
                            PLI.pullListNo = reader.GetString(0);
                            PLI.badgeNum = reader.GetString(2);
                            PLI.datetime = reader.GetDateTime(1);
                            PLINFO.Add(PLI);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cnn.Close();
            }

            //'2023-03-10 00:00:01'
            if (PLINFO.Count > 0)
            {
                return PLINFO[0].pullListNo;
            }
            else
            {
                return "P000000";
            }

        }

        public void SMTPullList(string bNum)
        {
            DataTable data = getdata(bNum);
            string PullListNum = pullListNo(bNum);
            string[] numandchar = PullListNum.Split('P');
            int res = 0;

            if(int.TryParse(numandchar[1], out res))
            {

            }
            else
            {
                res = 0;
            }

            string f_pulllistNo = "";

            if (data.Rows.Count > 0)
            {
                res++;

            }
            else
            {
                res = 0;
            }

            if (res < 10)
            {
                f_pulllistNo = "P00000" + res.ToString();
            }
            else if (res < 100)
            {
                f_pulllistNo = "P0000" + res.ToString();
            }
            else if (res < 1000)
            {
                f_pulllistNo = "P000" + res.ToString();
            }
            else if (res < 10000)
            {
                f_pulllistNo = "P00" + res.ToString();
            }
            else if (res < 100000)
            {
                f_pulllistNo = "P0" + res.ToString();
            }
            else if (res < 1000000)
            {
                f_pulllistNo = "P" + res.ToString();
            }
            else
            {
                f_pulllistNo = "P" + res.ToString();
            }

            if (data.Rows.Count > 0) { updatePullList(f_pulllistNo, bNum); }

            Document doc = new Document();
            MigraDoc.DocumentObjectModel.Section sec = doc.AddSection();

            TextFrame titleTF = sec.AddTextFrame();
            titleTF.WrapFormat.DistanceLeft = Unit.FromMillimeter(55);
            titleTF.WrapFormat.DistanceTop = Unit.FromMillimeter(-20);
            titleTF.Width = "7.5cm";
            titleTF.Height = "1.5cm";
            //titleTF.LineFormat.Color = Colors.Black;

            Paragraph titlePara = titleTF.AddParagraph();
            Font titleFont = new Font();
            titleFont.Size = 16;
            titleFont.Name = "Times New Roman";
            titlePara.AddFormattedText("SMTMaterialPullList " + DateTime.Now.ToString("yyyy"),titleFont);

            TextFrame dateTF = sec.AddTextFrame();
            dateTF.WrapFormat.DistanceLeft = Unit.FromMillimeter(125);
            dateTF.WrapFormat.DistanceTop = Unit.FromMillimeter(-10);
            dateTF.Width = "10cm";
            dateTF.Height = "2cm";
            //dateTF.LineFormat.Color = Colors.Black;

            Paragraph datePara = dateTF.AddParagraph();
            Font dateFont = new Font();
            dateFont.Size = 12;
            dateFont.Name = "Times New Roman";
            datePara.AddFormattedText("Date : \t" + DateTime.Now.ToString("dd/MM/yyyy"), dateFont);

            TextFrame shiftBTF = sec.AddTextFrame();
            shiftBTF.WrapFormat.DistanceLeft = Unit.FromMillimeter(82);
            shiftBTF.WrapFormat.DistanceTop = Unit.FromMillimeter(-15);
            shiftBTF.Width = "4cm";
            shiftBTF.Height = "2cm";
            //shiftBTF.LineFormat.Color = Colors.Black;

            Paragraph shiftBPara = shiftBTF.AddParagraph();
            Font shiftBFont = new Font();
            shiftBFont.Size = 12;
            shiftBFont.Name = "Times New Roman";
            shiftBPara.AddFormattedText(bNum, shiftBFont);

            TextFrame PullListNoTF = sec.AddTextFrame();
            PullListNoTF.WrapFormat.DistanceLeft = Unit.FromMillimeter(125);
            PullListNoTF.WrapFormat.DistanceTop = Unit.FromMillimeter(-20);
            PullListNoTF.Width = Unit.FromMillimeter(125);
            //PullListNoTF.LineFormat.Color = Colors.Black;

            Paragraph PullListNoPara = PullListNoTF.AddParagraph();
            Font PullListNoFont = new Font();
            PullListNoFont.Size = 12;
            PullListNoFont.Name = "Times New Roman";
            PullListNoPara.AddFormattedText("Pull List No : \t" + f_pulllistNo, PullListNoFont);

            TextFrame SMTTF = sec.AddTextFrame();
            SMTTF.WrapFormat.DistanceLeft = Unit.FromMillimeter(82);
            SMTTF.WrapFormat.DistanceTop = Unit.FromMillimeter(-20);
            SMTTF.Width = Unit.FromMillimeter(125);
            SMTTF.Height = Unit.FromMillimeter(10);
            //SMTTF.LineFormat.Color = Colors.Black;

            Paragraph SMTPara = SMTTF.AddParagraph();
            Font SMTFont = new Font();
            SMTFont.Size = 12;
            SMTFont.Name = "Times New Roman";
            SMTPara.AddFormattedText("SMT 6", SMTFont);

            TextFrame TimeRequestTF = sec.AddTextFrame();
            TimeRequestTF.WrapFormat.DistanceLeft = Unit.FromMillimeter(125);
            TimeRequestTF.WrapFormat.DistanceTop = Unit.FromMillimeter(-10);
            TimeRequestTF.Width = Unit.FromMillimeter(125);
            TimeRequestTF.Height = Unit.FromMillimeter(10);
            //TimeRequestTF.LineFormat.Color = Colors.Black;

            Paragraph TimeRequestPara = TimeRequestTF.AddParagraph();
            Font TimeRequestFont = new Font();
            TimeRequestFont.Size = 12;
            TimeRequestFont.Name = "Times New Roman";
            TimeRequestPara.AddFormattedText("TIME REQUEST : \t" + DateTime.Now.ToString("HH:mm:ss"), TimeRequestFont);

            TextFrame TimeRecieveTF = sec.AddTextFrame();
            TimeRecieveTF.WrapFormat.DistanceLeft = Unit.FromMillimeter(125);
            TimeRecieveTF.WrapFormat.DistanceTop = Unit.FromMillimeter(-5);
            TimeRecieveTF.Width = Unit.FromMillimeter(125);
            TimeRecieveTF.Height = Unit.FromMillimeter(5);

            Paragraph TimeRecievePara = TimeRecieveTF.AddParagraph();
            Font TimeRecieveFont = new Font();
            TimeRecieveFont.Size = 12;
            TimeRecieveFont.Name = "Times New Roman";
            TimeRecievePara.AddFormattedText("TIME RECEIVE", TimeRecieveFont);

            Table mainTab = new Table();//TabFrame.AddTable();
            mainTab.Borders.Width = 1;
            mainTab.Style = "Table";
            mainTab.Rows.Alignment = RowAlignment.Center;

            Column noCol = mainTab.AddColumn();
            noCol.Width = Unit.FromMillimeter(9.5);
            noCol.Format.Alignment = ParagraphAlignment.Center;

            Column PartNumberCol = mainTab.AddColumn();
            PartNumberCol.Width = Unit.FromMillimeter(35);
            PartNumberCol.Format.Alignment = ParagraphAlignment.Center;

            Column ShtgeQtyCol = mainTab.AddColumn();
            ShtgeQtyCol.Width = Unit.FromMillimeter(21);
            ShtgeQtyCol.Format.Alignment = ParagraphAlignment.Center;

            Column RecvQtyCol = mainTab.AddColumn();
            RecvQtyCol.Width = Unit.FromMillimeter(20.5);
            RecvQtyCol.Format.Alignment = ParagraphAlignment.Center;

            Column RefLocCol = mainTab.AddColumn();
            RefLocCol.Width = Unit.FromMillimeter(19.1);
            RefLocCol.Format.Alignment = ParagraphAlignment.Center;

            Column RefNumReelCol = mainTab.AddColumn();
            RefNumReelCol.Width = Unit.FromMillimeter(26);
            RefNumReelCol.Format.Alignment = ParagraphAlignment.Center;

            Column StdQtylCol = mainTab.AddColumn();
            StdQtylCol.Width = Unit.FromMillimeter(20);
            StdQtylCol.Format.Alignment = ParagraphAlignment.Center;

            Column BcodeCol = mainTab.AddColumn();
            BcodeCol.Width = Unit.FromMillimeter(50);
            BcodeCol.Format.Alignment = ParagraphAlignment.Center;

            Row rNo = mainTab.AddRow();
            rNo.VerticalAlignment = VerticalAlignment.Center;
            rNo.Height = Unit.FromMillimeter(5);
            rNo.HeadingFormat = true;
            rNo.Format.Font.Color = Colors.White;

            rNo.Cells[0].AddParagraph("No.");
            rNo.Cells[0].Shading.Color = MigraDoc.DocumentObjectModel.Color.FromRgb(31, 73, 125);
            rNo.Cells[1].AddParagraph("Part Number");
            rNo.Cells[1].Shading.Color = MigraDoc.DocumentObjectModel.Color.FromRgb(31, 73, 125);
            rNo.Cells[2].AddParagraph("ShortageQty");
            rNo.Cells[2].Shading.Color = MigraDoc.DocumentObjectModel.Color.FromRgb(31, 73, 125);
            rNo.Cells[3].AddParagraph("ReceivedQty");
            rNo.Cells[3].Shading.Color = MigraDoc.DocumentObjectModel.Color.FromRgb(31, 73, 125);
            rNo.Cells[4].AddParagraph("Ref. Location");
            rNo.Cells[4].Shading.Color = MigraDoc.DocumentObjectModel.Color.FromRgb(204, 51, 0);
            rNo.Cells[5].AddParagraph("Ref.NumofReel");
            rNo.Cells[5].Shading.Color = MigraDoc.DocumentObjectModel.Color.FromRgb(204, 51, 0);
            rNo.Cells[6].AddParagraph("Std. Qty");
            rNo.Cells[6].Shading.Color = MigraDoc.DocumentObjectModel.Color.FromRgb(204, 51, 0);
            rNo.Cells[7].AddParagraph("BARCODE");
            rNo.Cells[7].Shading.Color = MigraDoc.DocumentObjectModel.Color.FromRgb(204, 51, 0);
            int i = 0;
            foreach(DataRow dr in data.Rows)
            {
                i++;
                Row nrows = mainTab.AddRow();
                nrows.VerticalAlignment = VerticalAlignment.Center;
                nrows.Height = Unit.FromMillimeter(10);
                nrows.Cells[0].AddParagraph(i.ToString());
                nrows.Cells[1].AddParagraph(dr["PART_NUMBER"].ToString());
                nrows.Cells[2].AddParagraph(dr["SHORTAGE_QTY"].ToString());
                nrows.Cells[3].AddParagraph(dr["RECEIVED_QTY"].ToString());
                nrows.Cells[4].AddParagraph(dr["REF_LOC"].ToString());
                nrows.Cells[5].AddParagraph(dr["REF_NUM_REEL"].ToString());
                nrows.Cells[6].AddParagraph(dr["StandardQty"].ToString());

                QrCodeEncodingOptions options = new QrCodeEncodingOptions();
                options = new QrCodeEncodingOptions
                {
                    DisableECI = true,
                    CharacterSet = "UTF-8",
                    Width = 50,
                    Height = 35,
                    Margin = 0,
                };
                var qr = new ZXing.BarcodeWriter();
                qr.Options = options;
                qr.Format = ZXing.BarcodeFormat.CODE_128;
                qr.Options.PureBarcode = false;
                qr.Options.Margin = 5;
                var result = new Bitmap(qr.Write(dr["PART_NUMBER"].ToString()));
                string fileNamePnum = MigraDocFilenameFromByteArray(ImageToByteArray(result));

                nrows.Cells[7].AddImage(fileNamePnum);
            }
            



            mainTab = mainTab.Clone();

            sec.Add(mainTab);

            sec.PageSetup.BottomMargin = Unit.FromCentimeter(1);

            addSignature(sec, Unit.FromCentimeter(-1));

            ConvertPrintedFlag(data);
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = doc;
            pdfRenderer.RenderDocument();
            string pdfPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "PULL_LIST");
            string filename = pdfPath + "\\SMTPullList_" + bNum + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".pdf";
            pdfRenderer.PdfDocument.Save(filename);
            Process.Start(filename);


        }

        private void addSignature(Section sec,float lpPos)
        {
            TextFrame lastTF = sec.AddTextFrame();
            lastTF.WrapFormat.DistanceTop = lpPos;
            lastTF.WrapFormat.DistanceLeft = Unit.FromCentimeter(-1);
            lastTF.RelativeVertical = RelativeVertical.Page;
            lastTF.Top = ShapePosition.Bottom;
            lastTF.Height = Unit.FromCentimeter(3.5);

            Table lastTab = lastTF.AddTable();
            lastTab.Format.Alignment = ParagraphAlignment.Center;
            lastTab.Borders.Width = 0.5;
            lastTab.Borders.Color = Colors.Black;
            lastTab.AddColumn(Unit.FromCentimeter(6));
            lastTab.AddColumn(Unit.FromCentimeter(6));
            lastTab.AddColumn(Unit.FromCentimeter(6));



            Row sigRows = lastTab.AddRow();
            sigRows.Height = Unit.FromMillimeter(30);
            sigRows.Cells[0].AddParagraph("PIC REQUEST : \n\n\n\n\n\n_________________________");
            sigRows.Cells[1].AddParagraph("PIC ISSUE : \n\n\n\n\n\n_________________________");
            sigRows.Cells[2].AddParagraph("CONFIRM BY PIC RECEIVED : \n\n\n\n\n\n_________________________");
        }

        private void ConvertPrintedFlag(DataTable dt)
        {
            foreach(DataRow dr in dt.Rows)
            {
                string sqlCmd = "UPDATE [dbo].[SMT_PULLLIST] SET [PRINTED] = '1' WHERE [PART_NUMBER] = @mat";
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand(sqlCmd, cnn);
                SqlParameter matParam = new SqlParameter();
                matParam.ParameterName = "@mat";
                matParam.Value = dr["PART_NUMBER"].ToString();
                matParam.SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters.Add(matParam);
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
            return;
        }

        static string MigraDocFilenameFromByteArray(byte[] image)
        {
            return "base64:" + Convert.ToBase64String(image);
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

    }
}
