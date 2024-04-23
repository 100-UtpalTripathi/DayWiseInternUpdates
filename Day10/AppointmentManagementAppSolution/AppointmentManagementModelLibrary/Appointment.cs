using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagementModelLibrary
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDateTime { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

       

        public Appointment(int id, int doctorId, int patientId, DateTime appointmentDateTime)
        {
            Id = id;
            DoctorId = doctorId;
            PatientId = patientId;
            AppointmentDateTime = appointmentDateTime;
        }

        public Appointment(int doctorId, int patientId, DateTime appointmentDateTime)
        {
            DoctorId = doctorId;
            PatientId = patientId;
            AppointmentDateTime = appointmentDateTime;
        }
    }
}
