using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Fees : Form
    {
        public Fees()
        {
            InitializeComponent();
        }

      

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox.Text=="ENTER ID NUMBER")
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void textBox1_leave(object sender, EventArgs e)
        {
           
        }

        private void textBox_LEAVE(object sender, EventArgs e)
        {
            if (textBox.Text == "")
            {
                textBox.Text = "ENTER ID NUMBER";
                textBox.ForeColor = Color.Silver;
            }
        }
    }
}
