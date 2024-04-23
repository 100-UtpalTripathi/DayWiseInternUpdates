using NUnit.Framework;
using AppointmentManagementBLLibrary;
using AppointmentManagementModelLibrary;
using AppointmentManagementDALLibrary;
using System;

namespace AppointmentManagementApplicationTest
{
    public class PatientServiceBLTests
    {
        IPatientService _patientService;
        IRepository<int, Patient> _patientRepository;

        [SetUp]
        public void Setup()
        {
            _patientRepository = new PatientRepository();
            _patientService = new PatientService(_patientRepository);
        }

        [Test]
        public void RegisterPatient_Pass()
        {
            // Arrange
            var patient = new Patient(1, "Ramu Op", "1234567890", "ramuop@gmail.com");

            // Act
            var registeredPatient = _patientService.RegisterPatient(patient);

            // Assert
            Assert.IsNotNull(registeredPatient);
            Assert.AreEqual(patient, registeredPatient);
        }

        [Test]
        public void RegisterPatient_Fail()
        {
            // Arrange
            var patient = new Patient(1, "Ramu Op", "1234567890", "ramuop@gmail.com");

            // Add the same patient twice to intentionally fail
            _patientService.RegisterPatient(patient);

            // Act & Assert
            var exception = Assert.Throws<DuplicatePatientStoreException>(() => _patientService.RegisterPatient(patient));
            Assert.AreEqual("Patient with name Ramu Op is already Registered!", exception.Message);
        }

        [Test]
        public void RegisterPatient_Exception()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => _patientService.RegisterPatient(null));
        }

        [Test]
        public void SearchPatients_Pass()
        {
            // Arrange
            var patient1 = new Patient(1, "Ramu Op", "1234567890", "ramuop@gmail.com");
            var patient2 = new Patient(2, "Monu Op", "9876543210", "monuop@gmail.com");
            _patientService.RegisterPatient(patient1);
            _patientService.RegisterPatient(patient2);

            // Act
            var searchResult = _patientService.SearchPatients("Ramu");

            // Assert
            Assert.IsNotNull(searchResult);
            Assert.AreEqual(1, searchResult.Count);
            Assert.AreEqual(patient1, searchResult[0]);
        }

        [Test]
        public void SearchPatients_Fail()
        {
            // Arrange
            var patient1 = new Patient(1, "Ramu Op", "1234567890", "ramuop@gmail.com");
            var patient2 = new Patient(2, "Monu Op", "9876543210", "monuop@gmail.com");
            _patientService.RegisterPatient(patient1);
            _patientService.RegisterPatient(patient2);

            // Act
            var searchResult = _patientService.SearchPatients("Alice");

            // Assert
            Assert.IsNotNull(searchResult);
            Assert.AreEqual(0, searchResult.Count);
        }

        [Test]
        public void SearchPatients_Exception()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => _patientService.SearchPatients(null));
        }

        [Test]
        public void UpdatePatientInformation_Pass()
        {
            // Arrange
            var patient = new Patient(1, "Ramu Op", "1234567890", "ramuop@gmail.com");
            _patientService.RegisterPatient(patient);
            var updatedPatient = new Patient(1, "Ramu Op Updated", "9876543210", "ramuop@gmail.com");

            // Act
            var result = _patientService.UpdatePatientInformation(updatedPatient);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedPatient, result);
        }

        [Test]
        public void UpdatePatientInformation_Fail()
        {
            // Arrange
            var patient = new Patient(1, "Ramu Op", "1234567890", "ramuop@gmail.com");
            _patientService.RegisterPatient(patient);
            var updatedPatient = new Patient(2, "Ramu Op Updated", "9876543210", "ramuop@gmail.com");

            // Act & Assert
            var exception = Assert.Throws<PatientNotFoundException>(() => _patientService.UpdatePatientInformation(updatedPatient));
            Assert.AreEqual("Patient with ID 2 not found.", exception.Message);
        }

        [Test]
        public void UpdatePatientInformation_Exception()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => _patientService.UpdatePatientInformation(null));
        }

        [Test]
        public void GetPatientById_Pass()
        {
            // Arrange
            var patient = new Patient(1, "Ramu Op", "1234567890", "ramuop@gmail.com");
            _patientService.RegisterPatient(patient);

            // Act
            var result = _patientService.GetPatientById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(patient, result);
        }

        [Test]
        public void GetPatientById_Fail()
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<PatientNotFoundException>(() => _patientService.GetPatientById(1));
            Assert.AreEqual("Patient with ID 1 not found.", exception.Message);
        }

        [Test]
        public void GetPatientById_Exception()
        {
            // Arrange
            var patient = new Patient(1, "Ramu Op", "1234567890", "ramuop@gmail.com");
            _patientService.RegisterPatient(patient);

            // Act & Assert
            var exception = Assert.Throws<PatientNotFoundException>(() => _patientService.GetPatientById(2));
            Assert.AreEqual("Patient with ID 2 not found.", exception.Message);
        }

        [Test]
        public void DeletePatient_Pass()
        {
            // Arrange
            var patient = new Patient(1, "Ramu Op", "1234567890", "ramuop@gmail.com");
            _patientService.RegisterPatient(patient);

            // Act
            var result = _patientService.DeletePatient(1);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void DeletePatient_Fail()
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<PatientNotFoundException>(() => _patientService.DeletePatient(1));
            Assert.AreEqual("Patient with ID 1 not found.", exception.Message);
        }

        [Test]
        public void DeletePatient_Exception()
        {
            // Arrange
            var patient = new Patient(1, "Ramu Op", "1234567890", "ramuop@gmail.com");
            _patientService.RegisterPatient(patient);

            // Act & Assert
            var exception = Assert.Throws<PatientNotFoundException>(() => _patientService.DeletePatient(2));
            Assert.AreEqual("Patient with ID 2 not found.", exception.Message);
        }
    }
}
