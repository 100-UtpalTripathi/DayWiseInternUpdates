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
            message = "Doctor Already Registered!";
        }
        public DuplicateAppointmentStoreException(int id)
        {
            message = $"Doctor with id {id} is already Registered!";
        }
        public override string Message => message;
    }
}
