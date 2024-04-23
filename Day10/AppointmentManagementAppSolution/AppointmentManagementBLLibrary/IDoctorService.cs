using AppointmentManagementModelLibrary;

namespace AppointmentManagementBLLibrary
{
    public interface IDoctorService
    {
        Doctor RegisterDoctor(Doctor doctor);
        List<Doctor> SearchDoctorsBySpecialization(string criteria);
        Doctor UpdateDoctorInformation(Doctor doctor);
        
        Doctor GetDoctorById(int id);
        bool DeleteDoctor(int id);
        
    }
}
