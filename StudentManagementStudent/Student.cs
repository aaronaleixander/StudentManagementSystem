using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementStudent
{
    /// <summary>
    /// Represents an individual Clover Park Student.
    /// </summary>
    class Student
    {
        // Default no arg constructor
        // Compiler will create a no arg if no constructor is found.
        // Doesnt hurt to have this.
        // But comppiler will make the constructor for you.
        public Student()
        {

        }

        /// <summary>
        /// Create student with a given first and last name
        /// </summary>
        /// <param name="fName">The legal First Name</param>
        /// <param name="lName">The legal Last Name</param>
        public Student(string fName, string lName)
        {
            FirstName = fName;
            LastName = lName;
        }
        // Fully implemented property.
        // Property with private backing field.

        //private string _firstName;

        //public string FirstName
        //{
        //    get
        //    {
        //        return _firstName;
        //    }
        //    set
        //    {
        //        _firstName = value;
        //    }
        //}

       

        // Auto Implemented Properties.
        public string FirstName { get; set; }         // Student First Name
        public string LastName { get; set; }          // Student Last Name
        public int StudentID { get; set; }            // Student Id
        public DateTime DOB { get; set; }             // Student Date of Birth
        public string ProgramOfChoice { get; set; }   // Student Program  

        /// <summary>
        /// A read only property that returns the students full legal name.
        /// full legal name(first + last)
        /// </summary>
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        /// <summary>
        /// Returns all student data split by separator.
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        public string GetDisplayText(string separator)
        {
            return $"{LastName},{FirstName}{separator}" +
                   $"{DOB.ToShortDateString()}{separator}";
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
