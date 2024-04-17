using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagementModelLibrary
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        public Patient(int id, string name, string contactNumber, string email)
        {
            Id = id;
            Name = name;
            ContactNumber = contactNumber;
            Email = email;
        }
    }

}
