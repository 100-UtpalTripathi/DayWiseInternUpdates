
using System.Collections.Generic;
using System.Linq;
using AppointmentManagementDALLibrary.Model;

namespace AppointmentManagementDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        private readonly DoctorPatientContext _dbContext;

        public PatientRepository(DoctorPatientContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Patient Add(Patient item)
        {
            _dbContext.Patients.Add(item);
            _dbContext.SaveChanges(); // Save changes to the database
            return item;
        }

        public Patient DeleteByID(int key)
        {
            var patient = _dbContext.Patients.Find(key);
            if (patient != null)
            {
                _dbContext.Patients.Remove(patient);
                _dbContext.SaveChanges();
            }
            return patient;
        }

        public Patient GetByID(int key)
        {
            return _dbContext.Patients.Find(key);
        }

        public List<Patient> GetAll()
        {
            return _dbContext.Patients.ToList();
        }

        public Patient Update(Patient item)
        {
            _dbContext.Patients.Update(item);
            _dbContext.SaveChanges(); 
            return item;
        }
    }
}
