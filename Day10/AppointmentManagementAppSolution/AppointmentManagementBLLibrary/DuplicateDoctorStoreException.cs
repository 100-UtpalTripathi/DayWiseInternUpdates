using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagementBLLibrary
{
    public class DuplicateDoctorStoreException : Exception
    {
        string message;
        public DuplicateDoctorStoreException()
        {
            message = "Doctor Already Registered!";
        }
        public DuplicateDoctorStoreException(string name)
        {
            message = $"Doctor with name {name} is already Registered!";
        }
        public override string Message => message;
    }
}
