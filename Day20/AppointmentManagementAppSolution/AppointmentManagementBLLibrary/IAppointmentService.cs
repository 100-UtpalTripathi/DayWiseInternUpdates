
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagementDALLibrary.Model;

namespace AppointmentManagementBLLibrary
{
    public interface IAppointmentService
    {
        bool ScheduleAppointment(int doctorId, int patientId, DateTime appointmentDateTime);
        bool RescheduleAppointment(int appointmentId, DateTime newAppointmentDateTime);
        bool CancelAppointment(int appointmentId);
        List<Appointment> GetDoctorAppointments(int doctorId, DateTime startDate, DateTime endDate);
        List<Appointment> GetPatientAppointments(int patientId, DateTime startDate, DateTime endDate);
        Appointment GetAppointmentDetails(int appointmentId);
        Appointment GenerateAppointmentReport(int appointmentId);
    }
}
