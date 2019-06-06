using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementStudent
{
    static class StudentDB
    {
        public static List<Student> GetAllStudents()
        {
            //Get a connection to the DB
            SqlConnection con = SmsDB.GetConnection();

            //Set up query
            string query = "SELECT SID, FirstName, LastName, DOB, Program " +
                            "FROM Students ";
            SqlCommand selCmd = new SqlCommand
            {
                Connection = con,
                CommandText = query
            };

            //Open a connection to the DB
            con.Open();

            //Execute query
            SqlDataReader rdr = selCmd.ExecuteReader(); //returns a sql data reader object

            //Do something with results
            List<Student> stuList = new List<Student>();
            while (rdr.Read()) //similar to hasNext() (goes through each row)
            {
                Student tempStu = new Student
                {
                    StudentID = Convert.ToInt32(rdr["SID"]),
                    FirstName = Convert.ToString(rdr["FirstName"]),
                    LastName = Convert.ToString(rdr["LastName"]),
                    DOB = Convert.ToDateTime(rdr["DOB"]),
                    ProgramOfChoice = Convert.ToString(rdr["Program"])
                };
                stuList.Add(tempStu);
            }

            //Close connection
            con.Close();
            return stuList;
        }
    
    
    /// <summary>
    /// Adds a student to the database
    /// </summary>
    /// 
    /// <param name="s">The student to be added</param>
    /// <exception cref="SqlException"></exception>
    public static void Add(Student s)
        {
            SqlConnection con = SmsDB.GetConnection();

            SqlCommand addCmd = new SqlCommand();
            addCmd.Connection = con;
            // ALWAYS USE PARAMETERIZED QUERIES!!
            addCmd.CommandText = "INSERT INTO Students(FirstName, LastName, DOB, Program)" +
                                 "VALUES (@fName, @lName, @dob, @program)";
            //Add Values into parameters
            addCmd.Parameters.AddWithValue("@fName", s.FirstName);
            addCmd.Parameters.AddWithValue("@lName", s.LastName);
            addCmd.Parameters.AddWithValue("@dob", s.DOB);
            addCmd.Parameters.AddWithValue("@program", s.ProgramOfChoice);
            

            try
            {
                con.Open();
                int rows = addCmd.ExecuteNonQuery();
                // this will insert correctly OR throw a SQLException
            }
            finally
            {
                //con.Close();
                con.Dispose();  // dispose calls close internally
            }
        }

        /// <summary>
        /// Update existing student.
        /// </summary>
        /// <param name="s">New student data</param>
        /// <exception cref="SqlException"></exception>
        public static void Update(Student s)
        {
            SqlConnection con = SmsDB.GetConnection();
            SqlCommand updateCmd = new SqlCommand();
            updateCmd.Connection = con;
            updateCmd.CommandText = "UPDATE Students SET FirstName = @fName, LastName = @lName, DOB = @dob, Program = @program " +
                                                    "WHERE SID = @sid";
            updateCmd.Parameters.AddWithValue("@fName", s.FirstName);
            updateCmd.Parameters.AddWithValue("@lName", s.LastName);
            updateCmd.Parameters.AddWithValue("@dob", s.DOB);
            updateCmd.Parameters.AddWithValue("@program", s.ProgramOfChoice);
            updateCmd.Parameters.AddWithValue("@sid", s.StudentID);

            try
            {
                con.Open();
                int rowsAffected = updateCmd.ExecuteNonQuery();
            }
            finally
            {
                con.Dispose();
            }

        }

        /// <summary>
        /// Deletes existing student
        /// </summary>
        /// <param name="id">ID of the existing student.</param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            SqlConnection con = SmsDB.GetConnection();
            SqlCommand delCmd = new SqlCommand();
            delCmd.Connection = con;
            delCmd.CommandText = "DELETE FROM Students WHERE SID = @id";
            delCmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                int rowsAffected = delCmd.ExecuteNonQuery();
                //if (rowsAffected == 1)
                //    return true;
                //else
                //    return false;

                // Same as above with a conditional operator.
                return (rowsAffected == 1) ? true : false;
            }
            finally
            {
                con.Dispose();
            }
        }

        //public static double DoubleNum(int a)
        //{
        //    return a * 2;
        //}

        // C# Expression-bodied method using Lamda expressions. Syntactic sugar feats.
        public static double DoubleNum(int a) => a * 2;
    }
}
