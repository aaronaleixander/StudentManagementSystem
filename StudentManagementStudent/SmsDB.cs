using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementStudent
{
    class SmsDB
    {
        //public so that it is accessible to other classes

        /// <summary>
        /// Gets a connection to the student management system database
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=localhost;Initial Catalog=SMS;Integrated Security=True");
        }
    }
}
