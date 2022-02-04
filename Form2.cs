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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Add addForm = new Add();
        Fees form = new Fees();
        ViewAll view = new ViewAll();
        Report report = new Report();
        refund fund = new refund();
        private void button1_Click(object sender, EventArgs e)
        {
            addForm = new Add { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            addForm.FormBorderStyle  = FormBorderStyle.None;
            //panel2.Visible = false;

            this.panel211.Controls.Add(addForm);
            addForm.BringToFront();
            panel2.Hide();
            addForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Fees form = new Fees() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            form.FormBorderStyle = FormBorderStyle.None;
            //panel2.Visible = false;
            //addForm.Visible = false;

            this.panel211.Controls.Add(form);
            form.BringToFront();
            panel2.Hide();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewAll view = new ViewAll() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            view.FormBorderStyle = FormBorderStyle.None;
            panel2.Visible = false;
            this.panel211.Controls.Add(view);
            view.BringToFront();
            panel2.Hide();
            view.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Report report = new Report() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            report.FormBorderStyle = FormBorderStyle.None;
            panel2.Visible = false;
             this.panel211.Controls.Add(report);
            report.BringToFront();
            report.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            refund fund = new refund() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            fund.FormBorderStyle = FormBorderStyle.None;
            panel2.Visible = false;
            this.panel211.Controls.Add(fund);
            fund.BringToFront();
            fund.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //form{ Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //form.FormBorderStyle = FormBorderStyle.None;
            form.Visible=false;
            //view.Visible=false;
            report.Visible=false;
            fund.Visible=false;
            //panel2.Visible = true;
           // panel211.Visible = false;
            this.panel211.Controls.Remove(view);
            panel2.BringToFront();
            panel2.Show();
            addForm.Hide();
            form.Hide();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
