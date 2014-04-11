using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsFormsApplication
{
    public partial class MDIParent : Form
    {
        private int childFormNumber = 0;
        StudentDetails studentdetails;

        public MDIParent()
        {
            InitializeComponent();
        }

        //private void ShowNewForm(object sender, EventArgs e)
        //{
        //    Form childForm = new Form();
        //    childForm.MdiParent = this;
        //    childForm.Text = "Window " + childFormNumber++;
        //    childForm.Show();
        //}

       
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to Exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void newRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (studentdetails != null)
            {
                if (studentdetails.IsDisposed)
                {
                    studentdetails = new StudentDetails();
                    studentdetails.MdiParent = this;
                    studentdetails.Show();
                }
                else
                {
                    studentdetails.Close();
                    studentdetails = new StudentDetails();
                    studentdetails.MdiParent = this;
                    studentdetails.Show();
                    studentdetails.Focus();
                }
            }
            else
            {
                studentdetails = new StudentDetails();
                studentdetails.MdiParent = this;
                
                studentdetails.Show();
            }
        }
    }
}
