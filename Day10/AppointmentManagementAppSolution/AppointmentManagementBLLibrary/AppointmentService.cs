using AppointmentManagementDALLibrary;
using AppointmentManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagementBLLibrary
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<int, Appointment> _appointmentRepository;

        public AppointmentService(IRepository<int, Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public bool ScheduleAppointment(int doctorId, int patientId, DateTime appointmentDateTime)
        {
            if (doctorId <= 0 || patientId <= 0 || appointmentDateTime == default)
                throw new ArgumentException("Invalid input parameters.");

            var appointment = new Appointment(doctorId, patientId, appointmentDateTime);
            

            var result = _appointmentRepository.Add(appointment);
            if (result == null)
                throw new DuplicateAppointmentStoreException(appointment.Id);

            return true;
        }

        public bool RescheduleAppointment(int appointmentId, DateTime newAppointmentDateTime)
        {
            if (appointmentId <= 0 || newAppointmentDateTime == default)
                throw new ArgumentException("Invalid input parameters.");

            var appointment = _appointmentRepository.Get(appointmentId);
            if (appointment == null)
                throw new AppointmentNotFoundException($"Appointment with ID {appointmentId} not found.");

            appointment.AppointmentDateTime = newAppointmentDateTime;

            var updatedAppointment = _appointmentRepository.Update(appointment);

            return true;
        }

        public bool CancelAppointment(int appointmentId)
        {
            if (appointmentId <= 0)
                throw new ArgumentException("Invalid appointment ID.");

            var appointment = _appointmentRepository.Get(appointmentId);
            if (appointment == null)
                throw new AppointmentNotFoundException($"Appointment with ID {appointmentId} not found.");

            var canceledAppointment = _appointmentRepository.Delete(appointmentId);

            return true;
        }


        public List<Appointment> GetDoctorAppointments(int doctorId, DateTime startDate, DateTime endDate)
        {
            if (doctorId <= 0)
                throw new ArgumentException("Invalid doctor ID.");

            if (startDate >= endDate)
                throw new ArgumentException("Start date must be before end date.");

            var doctorAppointments = _appointmentRepository
                .GetAll()
                .Where(a => a.DoctorId == doctorId && a.AppointmentDateTime >= startDate && a.AppointmentDateTime <= endDate)
                .ToList();

            return doctorAppointments;
        }

        public List<Appointment> GetPatientAppointments(int patientId, DateTime startDate, DateTime endDate)
        {
            if (patientId <= 0)
                throw new ArgumentException("Invalid patient ID.");

            if (startDate >= endDate)
                throw new ArgumentException("Start date must be before end date.");

            var patientAppointments = _appointmentRepository
                .GetAll()
                .Where(a => a.PatientId == patientId && a.AppointmentDateTime >= startDate && a.AppointmentDateTime <= endDate)
                .ToList();

            return patientAppointments;
        }

        public Appointment GetAppointmentDetails(int appointmentId)
        {
            if (appointmentId <= 0)
                throw new ArgumentException("Invalid appointment ID.");

            var appointment = _appointmentRepository.Get(appointmentId);

            if (appointment == null)
                throw new AppointmentNotFoundException($"Appointment with ID {appointmentId} not found.");

            return appointment;
        }
    }
}
