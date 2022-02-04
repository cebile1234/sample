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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
           // add();
        }
        Bitmap bmp;
        public void add()
        {
            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=projectDB1.accdb");
                OleDbDataAdapter da = new OleDbDataAdapter(@"SELECT [s.studentID], [names],[surname],[balance] FROM studentTable s ,feesTable f where f.studentID=s.studentID AND grade='"+comboBox1.Text+"' ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = dr[1].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = dr[2].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = dr[3].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = dr[4].ToString();
                    //dataGridView1.Rows[n].Cells[4].Value = dr[5].ToString();
                    //dataGridView1.Rows[n].Cells[5].Value = dr[6].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bmp, 50,70);
            e.Graphics.DrawString(" Student'Fees List of grade"+" " + comboBox1.Text, new Font("verdana", 18, FontStyle.Bold), Brushes.Black, new Point(70, 30));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=projectDB1.accdb");
                OleDbDataAdapter da = new OleDbDataAdapter(@"SELECT [s.studentID], [names],[surname],[balance] FROM studentTable s ,feesTable f where f.studentID=s.studentID AND grade='" + comboBox1.Text + "' ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = dr[1].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = dr[2].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = dr[3].ToString();
                    //dataGridView1.Rows[n].Cells[3].Value = dr[4].ToString();
                    //dataGridView1.Rows[n].Cells[4].Value = dr[5].ToString();
                    //dataGridView1.Rows[n].Cells[5].Value = dr[6].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
