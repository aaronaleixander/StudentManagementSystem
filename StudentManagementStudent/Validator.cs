using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementStudent
{
    /// <summary>
    /// Contains helper methods for common validation.
    /// </summary>
    static class Validator
    {
        /// <summary>
        /// Checks if textbox has any data, Whitespace is Invalid as well.
        /// </summary>
        /// <param name="box">The TextBox to Check</param>
        /// <returns>Returns true if data is present</returns>
        public static bool IsPresent(TextBox box)
        {
            // if(box.Text.Trim() == string.Empty) ||
            if(string.IsNullOrWhiteSpace(box.Text))
            {
                return false;
            }
            return true;
        }
    }
}
