using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{
    /// <summary>
    /// User defined exception class
    /// </summary>
    public class NegNumException : Exception
    {
        public NegNumException() : base("Cannot use a negative number")
        {

        }
    }
}
