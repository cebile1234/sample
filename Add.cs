using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace project
{
    public partial class Add : Form
    {
        public Add()
        //public Balance();
        {
            InitializeComponent();
            Balance();
        }
        string gender;
        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=projectDB1.accdb");
            
            try
            {
                con.Open();
                string fee = "insert into feesTable([deposit], [balance], [currentDate]) values('" + textDeposit.Text + "', '" + textBalance.Text + "', '" + textdate.Text + "')";
                OleDbDataAdapter da = new OleDbDataAdapter(fee, con);
                da.SelectCommand.ExecuteNonQuery();
                
                String query = "insert into studentTable ([names],[surname],[grade],[ID_number],[gender],[address])  values('" + textname.Text + "','" + textsurname.Text + "','" + textGrade.Text + "','" + textID.Text + "','" + gender + "','" + textAddress.Text + "')";
             
                 da = new OleDbDataAdapter(query, con);
                da.SelectCommand.ExecuteNonQuery();
                string parent= "insert into parentTable ([title],[surname],[cell_number],[relationship])values('" + textTitle.Text + "','" + textSur.Text + "','" + textCell.Text + "','" + textRel.Text + "') ";
                 da = new OleDbDataAdapter(parent, con);
                da.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("added successfully");
                printDocument1.Print();


                // Add();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("PLEASE FILL IN ALL THE FIELDS", "Error!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            textname.Clear();
            textAddress.Clear();
            textBalance.Clear();
            textCell.Clear();
            textDeposit.Clear();
            textGrade.Text = "";
            textSur.Clear();
            textTitle.Text = "";
            textsurname.Clear();
            textRel.Clear();
            textID.Clear();
            textDeposit.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void textDeposit_TextChanged(object sender, EventArgs e)
        {
            Balance();
        }
        private void Balance()
        {
            if (textDeposit.Text != "")
            {
                decimal bal = 300 - Convert.ToInt32(textDeposit.Text);
                textBalance.Text = bal.ToString();
            }
            else
                textBalance.Text = "0";
        }

        private void textBalance_TextChanged(object sender, EventArgs e)
        {
            Balance();
        }

        
       
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = Properties.Resources.Screenshot__63_;
            //Bitmap mp=Properties.Resources.
            Image newImage = bmp;
            e.Graphics.DrawImage(newImage, 25, 25,newImage.Width,newImage.Height);
            e.Graphics.DrawString("PAYMENT RECIEPT", new Font("Ariel", 18,FontStyle.Bold), Brushes.Black, new Point(180, 130));
            e.Graphics.DrawString(label15.Text, new Font("Ariel", 10), Brushes.Black, new Point(25, 150));
            e.Graphics.DrawString("Name :" + textname.Text , new Font("Ariel", 10), Brushes.Black, new Point(25, 180));
            e.Graphics.DrawString("Surname :"+textsurname.Text, new Font("Ariel", 10), Brushes.Black, new Point(25, 200));
            e.Graphics.DrawString("Grade :" + textGrade.Text, new Font(" Ariel", 10), Brushes.Black, new Point(25, 220));
            e.Graphics.DrawString("Payment Date :" + DateTime.Now, new Font("Ariel", 10), Brushes.Black, new Point(200, 180));
            e.Graphics.DrawString("Amount Paid :" +"R"+textDeposit.Text, new Font("Ariel", 10), Brushes.Black, new Point(200, 200));
            e.Graphics.DrawString("Remaining Amount :"+"R"+textBalance.Text, new Font("Ariel", 10), Brushes.Black, new Point(200, 220));
            e.Graphics.DrawString("Signature :"+" "+label16.Text, new Font("Ariel", 10), Brushes.Black, new Point(200, 270));
            //e.Graphics.DrawString(label15.Text ,new Font("Ariel", 10), Brushes.Black, new Point(25, 290));
            //e.Graphics.DrawString(l.Text, new Font("Ariel", 12), Brushes.Black, new Point(25, 280));
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }
    }  
}
