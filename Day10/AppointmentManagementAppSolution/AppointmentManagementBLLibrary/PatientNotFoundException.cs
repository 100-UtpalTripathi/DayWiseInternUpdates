using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagementBLLibrary
{
    public class PatientNotFoundException : Exception
    {
        string message;
        public PatientNotFoundException()
        {
            message = "No Patient with such name";
        }
        public PatientNotFoundException(string name)
        {
            message = name;
        }
        public override string Message => message;
    }
}
