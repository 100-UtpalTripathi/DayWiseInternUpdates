
using System.Collections.Generic;
using System.Linq;
using AppointmentManagementDALLibrary.Model;

namespace AppointmentManagementDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly DoctorPatientContext _dbContext;

        public DoctorRepository(DoctorPatientContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Doctor Add(Doctor item)
        {
            _dbContext.Doctors.Add(item);
            _dbContext.SaveChanges(); // Save changes to the database
            return item;
        }

        public Doctor Delete(int key)
        {
            var doctor = _dbContext.Doctors.Find(key);
            if (doctor != null)
            {
                _dbContext.Doctors.Remove(doctor);
                _dbContext.SaveChanges(); // Save changes to the database
            }
            return doctor;
        }

        public Doctor Get(int key)
        {
            return _dbContext.Doctors.Find(key);
        }

        public List<Doctor> GetAll()
        {
            return _dbContext.Doctors.ToList();
        }

        public Doctor Update(Doctor item)
        {
            _dbContext.Doctors.Update(item);
            _dbContext.SaveChanges(); // Save changes to the database
            return item;
        }
    }
}
