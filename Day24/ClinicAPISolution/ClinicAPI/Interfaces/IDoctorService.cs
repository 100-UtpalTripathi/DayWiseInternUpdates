using ClinicAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicAPI.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetDoctors();
        Task UpdateDoctorExperience(int id, int years);
        Task<IEnumerable<Doctor>> GetDoctorsBySpecialization(string specialization);
    }
}
