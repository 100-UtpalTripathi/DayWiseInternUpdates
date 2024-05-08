using System;
using System.Collections.Generic;

namespace AppointmentManagementApp.Model
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
