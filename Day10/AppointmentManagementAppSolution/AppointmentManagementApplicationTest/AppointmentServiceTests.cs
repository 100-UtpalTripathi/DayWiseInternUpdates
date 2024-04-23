using AppointmentManagementBLLibrary;
using AppointmentManagementDALLibrary;
using AppointmentManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagementApplicationTest
{
    public class AppointmentServiceTests
    {
        private IAppointmentService _appointmentService;
        private IRepository<int, Appointment> _appointmentRepository;

        [SetUp]
        public void Setup()
        {
            _appointmentRepository = new AppointmentRepository();
            _appointmentService = new AppointmentService(_appointmentRepository);
        }

        [Test]
        public void ScheduleAppointment_Pass()
        {
            // Arrange
            var doctorId = 1;
            var patientId = 1;
            var appointmentDateTime = DateTime.Now.AddDays(1);

            // Act
            var result = _appointmentService.ScheduleAppointment(doctorId, patientId, appointmentDateTime);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ScheduleAppointment_Fail()
        {
            // Arrange
            var doctorId = 1;
            var patientId = 1;
            var appointmentDateTime = DateTime.Now.AddDays(1);

            // Add an appointment to intentionally fail
            _appointmentService.ScheduleAppointment(doctorId, patientId, appointmentDateTime);

            // Act & Assert
            var exception = Assert.Throws<DuplicateAppointmentStoreException>(() => _appointmentService.ScheduleAppointment(doctorId, patientId, appointmentDateTime));
            Assert.AreEqual("Appointment with ID 2 already exists.", exception.Message);
        }

        [Test]
        public void ScheduleAppointment_Exception()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => _appointmentService.ScheduleAppointment(0, 0, default));
        }

        [Test]
        public void RescheduleAppointment_Pass()
        {
            // Arrange
            var appointmentId = 1;
            var newAppointmentDateTime = DateTime.Now.AddDays(2);

            // Add an appointment
            _appointmentService.ScheduleAppointment(1, 1, DateTime.Now.AddDays(1));

            // Act
            var result = _appointmentService.RescheduleAppointment(appointmentId, newAppointmentDateTime);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RescheduleAppointment_Fail()
        {
            // Arrange
            var appointmentId = 1;
            var newAppointmentDateTime = DateTime.Now.AddDays(2);

            // Act & Assert
            var exception = Assert.Throws<AppointmentNotFoundException>(() => _appointmentService.RescheduleAppointment(appointmentId, newAppointmentDateTime));
            Assert.AreEqual("Appointment with ID 1 not found.", exception.Message);
        }

        [Test]
        public void RescheduleAppointment_Exception()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => _appointmentService.RescheduleAppointment(0, default));
        }


    }
}
