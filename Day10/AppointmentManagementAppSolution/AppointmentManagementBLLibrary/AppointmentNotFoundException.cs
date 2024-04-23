using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagementBLLibrary
{
    public class AppointmentNotFoundException : Exception
    {
        string message;
        public AppointmentNotFoundException()
        {
            message = "No Appointment with this ID!";
        }
        public AppointmentNotFoundException(string name)
        {
            message = name;
        }
        public override string Message => message;
    }
}
