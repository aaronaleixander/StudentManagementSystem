using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementStudent
{
    static class StudentDB
    {
        public static List<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public static void Add(Student s)
        {
            throw new NotImplementedException();
        }
        public static void Update(Student s)
        {
            throw new NotImplementedException();
        }
        public static void Delete(int id)
        {
            throw new NotImplementedException();
        }

        //public static double DoubleNum(int a)
        //{
        //    return a * 2;
        //}

        // C# Expression-bodied method using Lamda expressions. Syntactic sugar feats.
        public static double DoubleNum(int a) => a * 2;
    }
}
