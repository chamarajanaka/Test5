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
    public partial class StudentRegistration : Form
    {
        public static string StudentName;
        public static string DOB;
        public static string GPA;
        public static string Active;
        public static string Status;
        StudentDetails std;

        public StudentRegistration()
        {
            InitializeComponent();
        }

        public StudentRegistration(StudentDetails stDetails)
        {
            InitializeComponent();
            this.std = stDetails;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            float n;
            bool isNumeric = float.TryParse(txtGPA.Text, out n);

            if (isNumeric)
            {
                StudentName = txtName.Text;
                DOB = dateTimePickerDOB.Value.ToShortDateString();
                GPA = txtGPA.Text;
                Active = chkActive.Checked ? "Active" : "Deactive";
                Status = "UnSaved";

                std.dgStudent.Rows.Add(StudentName,DOB,GPA,Active,Status);

                this.Close();

            }
            else
            {
                MessageBox.Show("Enter a number for GPA", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
