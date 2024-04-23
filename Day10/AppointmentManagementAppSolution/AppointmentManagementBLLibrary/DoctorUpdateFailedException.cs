using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagementBLLibrary
{
    public class DoctorUpdateFailedException : Exception
    {
        string message;
        public DoctorUpdateFailedException()
        {
            message = "Doctor Update Failed!";
        }
        public DoctorUpdateFailedException(string name)
        {
            message = $" Doctor with name {name} Update Failed!";
        }
        public override string Message => message;
    }
}
