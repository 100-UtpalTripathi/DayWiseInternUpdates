using AppointmentManagementDALLibrary;
using AppointmentManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppointmentManagementBLLibrary
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<int, Patient> _patientRepository;

        public PatientService(IRepository<int, Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Patient RegisterPatient(Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient), "Patient object cannot be null.");

            var result = _patientRepository.Add(patient);

            if (result != null)
            {
                return result;
            }
            throw new DuplicatePatientStoreException(patient.Name);
        }

        public List<Patient> SearchPatients(string searchCriteria)
        {
            if (string.IsNullOrWhiteSpace(searchCriteria))
                throw new ArgumentException("Search criteria cannot be null or empty.");

            var patients = _patientRepository.GetAll();
            return patients.Where(p => p.Name.ToLower().Contains(searchCriteria.ToLower())).ToList();
        }

        public Patient UpdatePatientInformation(Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient), "Patient object cannot be null.");

            var existingPatient = _patientRepository.Get(patient.Id);
            if (existingPatient == null)
                throw new PatientNotFoundException($"Patient with ID {patient.Id} not found.");

            var updatedPatient = _patientRepository.Update(patient);

            return updatedPatient;
        }

        public Patient GetPatientById(int id)
        {
            var patient = _patientRepository.Get(id);
            if (patient == null)
                throw new PatientNotFoundException($"Patient with ID {id} not found.");

            return patient;
        }

        public bool DeletePatient(int id)
        {
            var deletedPatient = _patientRepository.Delete(id);
            if (deletedPatient == null)
                throw new PatientNotFoundException($"Patient with ID {id} not found.");

            return true;
        }
    }
}
