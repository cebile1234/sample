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
    public partial class ViewAll : Form
    {
        public ViewAll()
        {
            InitializeComponent();
            view();
        }

        private void textBox4_LEAVE(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "ENTER ID NUMBER";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox4_ENTER(object sender, EventArgs e)
        {
            if (textBox1.Text == "ENTER ID NUMBER")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void view()
        {
             try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=projectDB1.accdb");
                OleDbDataAdapter da = new OleDbDataAdapter(@"SELECT [studentID], [names],[s.surname],[grade],[ID_number],[f.surname],[cell_number],[address],[relationship] FROM studentTable s ,parentTable f where s.studentID=f.parentID  ", con);
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
                    dataGridView1.Rows[n].Cells[4].Value = dr[5].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = dr[6].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = dr[7].ToString();
                    dataGridView1.Rows[n].Cells[7].Value = dr[8].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

}
    }
}
