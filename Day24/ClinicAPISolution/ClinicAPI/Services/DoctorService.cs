using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using ClinicAPI.Exceptions;


namespace ClinicAPI.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<int, Doctor> _repository;

        public DoctorService(IRepository<int, Doctor> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = await _repository.GetAll();  //getting all doctors

            if (doctors == null || !doctors.Any())  //if no doctors found
                throw new NoDoctorsFoundException();

            return doctors;
        }

        public async Task<Doctor> UpdateDoctorExperience(int id, int years)  //updating doctor experience by taking id and years as input
        {
            var doctor = await _repository.GetByKey(id); //getting doctor by id

            if (doctor == null)
                throw new NoSuchDoctorException();

            doctor.ExperienceInYears = years;  // updating experience
            await _repository.Update(doctor);  //updating doctor

            return doctor;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsBySpecialization(string specialization)
        {
            var doctors = await _repository.GetAll();   // getting all doctors

            if (doctors == null || !doctors.Any())  //if no doctors found
                throw new NoDoctorsFoundException();

            var doctorsBySpecialization = doctors.Where(d => d.Specialization == specialization);

            if (!doctorsBySpecialization.Any())
                throw new NoDoctorsFoundException($"No doctors found with specialization: {specialization}");

            return doctorsBySpecialization;
        }
    }
}
