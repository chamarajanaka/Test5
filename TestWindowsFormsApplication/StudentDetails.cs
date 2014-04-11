using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentClassLibrary.Model;
using StudentClassLibrary.Repository;

namespace TestWindowsFormsApplication
{
    public partial class StudentDetails : Form
    {
        StudentRegistration reg;
       
        public StudentDetails()
        {
            InitializeComponent();
          
        }

              

        private void btnAddNew_Click(object sender, EventArgs e)
        {

            if (reg != null)
            {
                if (reg.IsDisposed)
                {
                    reg = new StudentRegistration(this);
                    //reg.MdiParent = MdiParent;
                    reg.Show();
                }
                else
                {
                    reg.Close();
                    reg = new StudentRegistration(this);
                    //reg.MdiParent = MdiParent;
                    reg.Show();
                    reg.Focus();
                }
            }
            else
            {
                reg = new StudentRegistration(this);
                //reg.MdiParent = MdiParent;

                reg.Show();
            }
        }

        private void StudentDetails_Load(object sender, EventArgs e)
        {

            dgStudent.Columns.Add("StudentName", "Student Name");
            dgStudent.Columns.Add("DOB", "DBO");
            dgStudent.Columns.Add("GPA", "GPA");
            dgStudent.Columns.Add("Active", "Active");
            dgStudent.Columns.Add("Status", "Status");
           
            BindGrid();
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<Registration> LReg = new List<Registration>();
                foreach (DataGridViewRow item in dgStudent.Rows)
                {
                    if (item.Cells["DOB"].Value != null && item.Cells["GPA"].Value != null && item.Cells["Status"].Value.ToString() == "UnSaved")
                    {
                        Registration model = new Registration();
                        model.Name = item.Cells["StudentName"].Value.ToString();
                        model.DOB = Convert.ToDateTime(item.Cells["DOB"].Value.ToString());
                        model.Active = item.Cells["Active"].Value.ToString() == "Active" ? true : false;
                        model.GPA = Convert.ToDouble(item.Cells["GPA"].Value.ToString());
                        LReg.Add(model);
                    }

                }

                if (LReg.Count > 0)
                {
                    RegistrationRepository rep = new RegistrationRepository();
                    rep.Create(LReg);
                    BindGrid();
                    MessageBox.Show("Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void BindGrid()
        {
            try
            {
                RegistrationRepository rep = new RegistrationRepository();
                DataTable dt = rep.ReadDataSet().Tables["tblData"];
                int rowCount = dgStudent.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    dgStudent.Rows.Clear();
                 
                }
                foreach (DataRow item in dt.Rows)
                {
                    string active = item["Active"].ToString() == "True" ? "Active" : "Deactive";
                    string date = Convert.ToDateTime(item["DOB"].ToString()).ToShortDateString();

                    dgStudent.Rows.Add(item["Name"], date, item["GPA"], active, "Saved");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
