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
            // Object Initialization Syntax - Or you can leave it property by property.
            Student testStu = new Student
            {
                FirstName = "Britney",
                LastName = "Utterback",
                ProgramOfChoice = "Art"
            };

            Student testStu2 = new Student("Aaron", "Utterback");

            Validator.IsPresent(new TextBox());
        }
    }
}
