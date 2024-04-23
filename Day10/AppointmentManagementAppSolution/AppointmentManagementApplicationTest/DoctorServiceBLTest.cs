using AppointmentManagementBLLibrary;
using AppointmentManagementModelLibrary;
using AppointmentManagementDALLibrary;
namespace AppointmentManagementApplicationTest
{
    public class Tests
    {
        IDoctorService _doctorService;
        IRepository<int, Doctor> doctorRepository;

        [SetUp]
        public void Setup()
        {
            doctorRepository = new DoctorRepository();
            _doctorService = new DoctorService(doctorRepository);
        }

        [Test]
        public void RegisterDoctor_Pass()
        {
            // Arrange
            var doctor = new Doctor(1, "Somu Op", "Pediatrician", "1234567890", "somu.op@gmail.com");

            // Act
            var registeredDoctor = _doctorService.RegisterDoctor(doctor);

            // Assert
            Assert.IsNotNull(registeredDoctor);
            Assert.AreEqual(doctor, registeredDoctor);
        }

        [Test]
        public void RegisterDoctor_Fail()
        {
            // Arrange
            var doctor = new Doctor(1, "Somu Op", "Pediatrician", "1234567890", "somu.op@gmail.com");

            // Add the same doctor twice to intentionally fail
            _doctorService.RegisterDoctor(doctor);

            // Act & Assert
            var exception = Assert.Throws<DuplicateDoctorStoreException>(() => _doctorService.RegisterDoctor(doctor));
            Assert.AreEqual("Doctor with name Somu Op is already Registered!", exception.Message);
        }

        [Test]
        public void RegisterDoctor_Exception()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => _doctorService.RegisterDoctor(null));
        }
        [Test]
        public void SearchDoctorsBySpecialization_Pass()
        {
            // Arrange
            var doctor1 = new Doctor(1, "Somu Op", "Pediatrician", "1234567890", "somu.op@gmail.com");
            var doctor2 = new Doctor(2, "Ramu Op", "Cardiologist", "9876543210", "ramu.op@gmail.com");
            _doctorService.RegisterDoctor(doctor1);
            _doctorService.RegisterDoctor(doctor2);

            // Act
            var searchResult = _doctorService.SearchDoctorsBySpecialization("cardiologist");

            // Assert
            Assert.IsNotNull(searchResult);
            Assert.AreEqual(1, searchResult.Count);
            //Assert.AreEqual(doctor2, searchResult[0]);
        }

        [Test]
        public void SearchDoctorsBySpecialization_Fail()
        {
            // Arrange
            var doctor1 = new Doctor(1, "Somu Op", "Pediatrician", "1234567890", "Somu.op@gmail.com");
            var doctor2 = new Doctor(2, "Ramu Op", "Cardiologist", "9876543210", "Ramu.op@gmail.com");
            _doctorService.RegisterDoctor(doctor1);
            _doctorService.RegisterDoctor(doctor2);

            // Act
            var searchResult = _doctorService.SearchDoctorsBySpecialization("orthopedic");

            // Assert
            Assert.IsNotNull(searchResult);
            Assert.AreEqual(0, searchResult.Count);
        }

        [Test]
        public void SearchDoctorsBySpecialization_Exception()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => _doctorService.SearchDoctorsBySpecialization(null));
        }

        [Test]
        public void UpdateDoctorInformation_Pass()
        {
            // Arrange
            var doctor = new Doctor(1, "Somu Op", "Pediatrician", "1234567890", "somu.op@gmail.com");
            _doctorService.RegisterDoctor(doctor);
            var updatedDoctor = new Doctor(1, "Somu Op Updated", "Cardiologist", "1234567890", "somu.op@gmail.com");

            // Act
            var result = _doctorService.UpdateDoctorInformation(updatedDoctor);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedDoctor, result);
        }

        [Test]
        public void UpdateDoctorInformation_Fail()
        {
            // Arrange
            var doctor = new Doctor(1, "Somu Op", "Pediatrician", "1234567890", "somu.op@gmail.com");
            _doctorService.RegisterDoctor(doctor);
            var updatedDoctor = new Doctor(2, "Somu Op Updated", "Cardiologist", "1234567890", "somu.op@gmail.com");

            // Act & Assert
            var exception = Assert.Throws<DoctorNotFoundException>(() => _doctorService.UpdateDoctorInformation(updatedDoctor));
            Assert.AreEqual("Doctor with ID 2 not found.", exception.Message);
        }

        [Test]
        public void UpdateDoctorInformation_Exception()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => _doctorService.UpdateDoctorInformation(null));
        }

        [Test]
        public void GetDoctorById_Pass()
        {
            // Arrange
            var doctor = new Doctor(1, "Somu Op", "Pediatrician", "1234567890", "somu.op@gmail.com");
            _doctorService.RegisterDoctor(doctor);

            // Act
            var result = _doctorService.GetDoctorById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(doctor, result);
        }

        [Test]
        public void GetDoctorById_Fail()
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<DoctorNotFoundException>(() => _doctorService.GetDoctorById(1));
            Assert.AreEqual("Doctor with ID 1 not found.", exception.Message);
        }

        [Test]

        public void GetDoctorById_Exception()
        {
            // Arrange
            var doctor = new Doctor(1, "Somu Op", "Pediatrician", "1234567890", "somu.op@gmail.com");
            _doctorService.RegisterDoctor(doctor);

            // Act & Assert
            var exception = Assert.Throws<DoctorNotFoundException>(() => _doctorService.GetDoctorById(2));
            Assert.AreEqual("Doctor with ID 2 not found.", exception.Message);
        }

        [Test]
        public void DeleteDoctor_Pass()
        {
            // Arrange
            var doctor = new Doctor(1, "Somu Op", "Pediatrician", "1234567890", "somu.op@gmail.com");
            _doctorService.RegisterDoctor(doctor);

            // Act
            var result = _doctorService.DeleteDoctor(1);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteDoctor_Fail()
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<DoctorNotFoundException>(() => _doctorService.DeleteDoctor(1));
            Assert.AreEqual("Doctor with ID 1 not found.", exception.Message);
        }

        [Test]
        public void DeleteDoctor_Exception()
        {
            // Arrange
            var doctor = new Doctor(1, "Somu Op", "Pediatrician", "1234567890", "somu.op@gmail.com");
            _doctorService.RegisterDoctor(doctor);

            // Act & Assert
            var exception = Assert.Throws<DoctorNotFoundException>(() => _doctorService.DeleteDoctor(2));
            Assert.AreEqual("Doctor with ID 2 not found.", exception.Message);
        }



    }
}