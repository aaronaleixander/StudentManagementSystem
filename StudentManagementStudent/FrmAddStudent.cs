using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementStudent
{
    public partial class FrmAddStudent : Form
    {
        public FrmAddStudent()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            // Object initialization syntax
            // could go property by property ex.. stu.Program = txtProgram.Text;
            // Assume all data is valid
            Student stu = new Student()
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                ProgramOfChoice = txtProgram.Text,
                DOB = dtpDateOfBirth.Value,
            };
            try
            {
                StudentDB.Add(stu);
                MessageBox.Show("Student Added!");
                Close();
            }
            catch(SqlException) // Didnt give variable name becasue it wasn't used.
            {
                MessageBox.Show("There was a DB Problem, Try again later.");
            }
        }
    }
}
