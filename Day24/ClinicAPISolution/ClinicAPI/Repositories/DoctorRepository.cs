using ClinicAPI.Contexts;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using ClinicAPI.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Repositories
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly ClinicAppContext _context;
        public DoctorRepository(ClinicAppContext context)
        {
            _context = context;
        }
        public async Task<Doctor> Add(Doctor item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Doctor> DeleteByKey(int key)
        {
            var Doctor = await GetByKey(key);
            if (Doctor != null)
            {
                _context.Remove(Doctor);
                _context.SaveChangesAsync(true);
                return Doctor;
            }
            throw new NoSuchDoctorException();
        }

        public Task<Doctor> GetByKey(int key)
        {
            var Doctor = _context.Doctors.FirstOrDefaultAsync(e => e.Id == key);
            return Doctor;
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            var Doctors = await _context.Doctors.ToListAsync();
            return Doctors;

        }

        public async Task<Doctor> Update(Doctor item)
        {
            var Doctor = await GetByKey(item.Id);
            if (Doctor != null)
            {
                _context.Update(item);
                _context.SaveChangesAsync(true);
                return Doctor;
            }
            throw new NoSuchDoctorException();
        }
    }
}
