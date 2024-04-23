using AppointmentManagementDALLibrary;
using AppointmentManagementModelLibrary;
using System;
using System.Collections.Generic;

namespace AppointmentManagementBLLibrary
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<int, Doctor> _doctorRepository;

        public DoctorService(IRepository<int, Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public Doctor RegisterDoctor(Doctor doctor)
        {
            if (doctor == null)
                throw new ArgumentNullException(nameof(doctor), "Doctor object cannot be null.");

            var result = _doctorRepository.Add(doctor);

            if (result != null)
            {
                return result;
            }
            throw new DuplicateDoctorStoreException(doctor.Name);
        }

        public List<Doctor> SearchDoctorsBySpecialization(string searchCriteria)
        {
            if (string.IsNullOrWhiteSpace(searchCriteria))
                throw new ArgumentException("Search criteria cannot be null or empty.");

            var doctors = _doctorRepository.GetAll();
            return doctors.Where(d => d.Specialization.ToLower().Contains(searchCriteria.ToLower())).ToList();
        }

        public Doctor UpdateDoctorInformation(Doctor doctor)
        {
            if (doctor == null)
                throw new ArgumentNullException(nameof(doctor), "Doctor object cannot be null.");

            var existingDoctor = _doctorRepository.Get(doctor.Id);
            if (existingDoctor == null)
                throw new DoctorNotFoundException($"Doctor with ID {doctor.Id} not found.");

            // Update doctor information in the repository
            var updatedDoctor = _doctorRepository.Update(doctor);

            return updatedDoctor;
        }

        public Doctor GetDoctorById(int id)
        {
            var doctor = _doctorRepository.Get(id);
            if (doctor == null)
                throw new DoctorNotFoundException($"Doctor with ID {id} not found.");

            return doctor;
        }

        public bool DeleteDoctor(int id)
        {
            var deletedDoctor = _doctorRepository.Delete(id);
            if (deletedDoctor == null)
                throw new DoctorNotFoundException($"Doctor with ID {id} not found.");

            return true;
        }



    }

    
}
