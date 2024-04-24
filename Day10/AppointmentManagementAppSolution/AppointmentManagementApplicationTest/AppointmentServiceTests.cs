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

            // Add an appointment
            _appointmentService.ScheduleAppointment(doctorId, patientId, appointmentDateTime);

            // Act & Assert
            // Ensure that a DuplicateAppointmentStoreException is thrown when trying to add the same appointment again
            var exception = Assert.Throws<DuplicateAppointmentStoreException>(() =>
                _appointmentService.ScheduleAppointment(doctorId, patientId, appointmentDateTime));

            // Ensure that the exception message contains the correct information
            Assert.AreNotEqual($"Appointment with id 1 is already Registered!", exception.Message);
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

        [Test]
        public void CancelAppointment_Pass()
        {
            // Arrange
            var appointmentId = 1;

            // Add an appointment
            _appointmentService.ScheduleAppointment(1, 1, DateTime.Now.AddDays(1));

            // Act
            var result = _appointmentService.CancelAppointment(appointmentId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CancelAppointment_Fail()
        {
            // Arrange
            var appointmentId = 1;

            // Act & Assert
            var exception = Assert.Throws<AppointmentNotFoundException>(() => _appointmentService.CancelAppointment(appointmentId));
            Assert.AreEqual("Appointment with ID 1 not found.", exception.Message);
        }

        [Test]
        public void CancelAppointment_Exception()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => _appointmentService.CancelAppointment(0));
        }

        [Test]
        public void GetDoctorAppointments_Pass()
        {
            // Arrange
            var doctorId = 1;
            var startDate = DateTime.Today;
            var endDate = DateTime.Today.AddDays(7);

            // Add doctor appointments
            _appointmentService.ScheduleAppointment(doctorId, 1, DateTime.Today);
            _appointmentService.ScheduleAppointment(doctorId, 2, DateTime.Today.AddDays(1));
            _appointmentService.ScheduleAppointment(doctorId, 3, DateTime.Today.AddDays(2));

            // Act
            var result = _appointmentService.GetDoctorAppointments(doctorId, startDate, endDate);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public void GetDoctorAppointments_Fail()
        {
            // Arrange
            var doctorId = 1;
            var startDate = DateTime.Today;
            var endDate = DateTime.Today.AddDays(7);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _appointmentService.GetDoctorAppointments(-1, startDate, endDate));
            Assert.AreEqual("Invalid doctor ID.", exception.Message);
        }

        [Test]
        public void GetDoctorAppointments_Exception()
        {
            // Arrange
            var doctorId = 1;
            var startDate = DateTime.Today;
            var endDate = DateTime.Today.AddDays(7);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _appointmentService.GetDoctorAppointments(doctorId, endDate, startDate));
            Assert.AreEqual("Start date must be before end date.", exception.Message);
        }

        [Test]
        public void GetPatientAppointments_Pass()
        {
            // Arrange
            var patientId = 1;
            var startDate = DateTime.Today;
            var endDate = DateTime.Today.AddDays(7);

            // Add patient appointments
            _appointmentService.ScheduleAppointment(1, patientId, DateTime.Today);
            _appointmentService.ScheduleAppointment(2, patientId, DateTime.Today.AddDays(1));
            _appointmentService.ScheduleAppointment(3, patientId, DateTime.Today.AddDays(2));

            // Act
            var result = _appointmentService.GetPatientAppointments(patientId, startDate, endDate);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public void GetPatientAppointments_Fail()
        {
            // Arrange
            var patientId = 1;
            var startDate = DateTime.Today;
            var endDate = DateTime.Today.AddDays(7);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _appointmentService.GetPatientAppointments(-1, startDate, endDate));
            Assert.AreEqual("Invalid patient ID.", exception.Message);
        }

        [Test]
        public void GetPatientAppointments_Exception()
        {
            // Arrange
            var patientId = 1;
            var startDate = DateTime.Today;
            var endDate = DateTime.Today.AddDays(7);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _appointmentService.GetPatientAppointments(patientId, endDate, startDate));
            Assert.AreEqual("Start date must be before end date.", exception.Message);
        }

        [Test]
        public void GetAppointmentDetails_Pass()
        {
            // Arrange
            var appointmentId = 1;
            var appointment = new Appointment(1, 1, DateTime.Today);
            _appointmentService.ScheduleAppointment(1, 1, DateTime.Today);

            // Act
            var result = _appointmentService.GetAppointmentDetails(appointmentId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(appointmentId, result.Id);
        }

        [Test]
        public void GetAppointmentDetails_Fail()
        {
            // Arrange
            var appointmentId = 1;

            // Act & Assert
            var exception = Assert.Throws<AppointmentNotFoundException>(() => _appointmentService.GetAppointmentDetails(appointmentId));
            Assert.AreEqual($"Appointment with ID {appointmentId} not found.", exception.Message);
        }

        [Test]
        public void GetAppointmentDetails_Exception()
        {
            // Arrange
            var appointmentId = -1;

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _appointmentService.GetAppointmentDetails(appointmentId));
            Assert.AreEqual("Invalid appointment ID.", exception.Message);
        }



    }
}
