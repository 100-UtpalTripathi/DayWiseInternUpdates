using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagementBLLibrary
{
    public class DuplicateAppointmentStoreException : Exception
    {
        string message;
        public DuplicateAppointmentStoreException()
        {
            message = "Appointment Already Registered!";
        }
        public DuplicateAppointmentStoreException(int id)
        {
            message = $"Appointment with id {id} is already Registered!";
        }
        public override string Message => message;
    }
}
