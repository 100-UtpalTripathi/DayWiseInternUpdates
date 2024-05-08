using AppointmentManagementDALLibrary.Model;
using System.Collections.Generic;
using System.Linq;

namespace AppointmentManagementDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        private readonly DoctorPatientContext _dbContext;

        public AppointmentRepository(DoctorPatientContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Appointment Add(Appointment item)
        {
            _dbContext.Appointments.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public Appointment Delete(int key)
        {
            var appointment = _dbContext.Appointments.Find(key);
            if (appointment != null)
            {
                _dbContext.Appointments.Remove(appointment);
                _dbContext.SaveChanges();
            }
            return appointment;
        }

        public Appointment Get(int key)
        {
            return _dbContext.Appointments.Find(key);
        }

        public List<Appointment> GetAll()
        {
            return _dbContext.Appointments.ToList();
        }

        public Appointment Update(Appointment item)
        {
            _dbContext.Appointments.Update(item);
            _dbContext.SaveChanges();
            return item;
        }
    }
}
