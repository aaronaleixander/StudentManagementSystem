using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementStudent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateStudentListBox();

            //// Object Initialization Syntax - Or you can leave it property by property.
            //Student testStu = new Student
            //{
            //    FirstName = "Britney",
            //    LastName = "Utterback",
            //    ProgramOfChoice = "Art"
            //};

            //Student testStu2 = new Student("Aaron", "Utterback");

            //Validator.IsPresent(new TextBox());
        }

        private void BtnAddStudent_Click(object sender, EventArgs e)
        {
            FrmAddStudent addStuForm = new FrmAddStudent();
            addStuForm.ShowDialog();
            PopulateStudentListBox();
        }

        /// <summary>
        /// retrieves all students from db and puts in listbox
        /// </summary>
        private void PopulateStudentListBox()
        {
            List<Student> students = StudentDB.GetAllStudents();
            students = students.OrderBy(stu => stu.FirstName).ToList();
            lstStudents.Items.Clear();

            

            foreach (Student s in students)
            {
                lstStudents.Items.Add(s).ToString();
                //lstStudents.Items.Add($"{s.FirstName} {s.LastName}");
            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if(lstStudents.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose a student");
                return;
            }
            Student stu = lstStudents.SelectedItem as Student;
            string msg = $"Are you sure you want to delete" +
                         $"{stu.StudentID} : {stu.FullName}";
            DialogResult answer = MessageBox.Show(msg, "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(answer == DialogResult.Yes)
            {
                StudentDB.Delete(stu.StudentID);
                PopulateStudentListBox();
                MessageBox.Show("Student Deleted Successfully.");
            }
        }
    }
}
