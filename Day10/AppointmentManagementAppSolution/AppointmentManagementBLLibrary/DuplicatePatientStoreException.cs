using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagementBLLibrary
{
    public class DuplicatePatientStoreException : Exception
    {
        string message;
        public DuplicatePatientStoreException()
        {
            message = "Patient Already Registered!";
        }
        public DuplicatePatientStoreException(string name)
        {
            message = $"Patient with name {name} is already Registered!";
        }
        public override string Message => message;
    }
}
