using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagementBLLibrary
{
    public class DoctorNotFoundException : Exception
    {
        string message;
        public DoctorNotFoundException()
        {
            message = "No Doctor with such name";
        }
        public DoctorNotFoundException(string name)
        {
            message = "No Doctor with name {name}";
        }
        public override string Message => message;
    }
}
