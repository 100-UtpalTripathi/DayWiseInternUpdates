using System;
using System.Collections.Generic;

namespace AppointmentManagementDALLibrary.Model
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        public DateTime? AppointmentDateTime { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
