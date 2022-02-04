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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=projectDB1.accdb";
                OleDbConnection dbconn = new OleDbConnection(path);
                dbconn.Open();

                string sql = "SELECT Count(*) FROM Login where  username='" + txtUser.Text + "'and password='" + txtPass.Text + "'  ";
                OleDbDataAdapter dbDA = new OleDbDataAdapter(sql, dbconn);
                DataTable dt = new DataTable();
                dbDA.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {


                    Form2 form = new Form2();
                    form.Visible = true;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(" Incorrect Username or password...");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
