
using System;
using System.Collections.Generic;
using AppointmentManagementDALLibrary.Model;

namespace AppointmentManagementBLLibrary
{
    public interface IDoctorService
    {
        Doctor RegisterDoctor(Doctor doctor);
        List<Doctor> SearchDoctors(string searchCriteria);
        Doctor UpdateDoctorInformation(Doctor doctor);
        bool ScheduleAppointment(int doctorId, int patientId, DateTime appointmentDateTime);
        Doctor GetDoctorById(int id);
        bool DeleteDoctor(int id);
        Doctor GenerateDoctorReport(int doctorId);
    }
}
