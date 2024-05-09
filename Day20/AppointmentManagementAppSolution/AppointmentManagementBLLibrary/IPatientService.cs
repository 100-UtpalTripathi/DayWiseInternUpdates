
using System;
using System.Collections.Generic;
using AppointmentManagementDALLibrary.Model;

namespace AppointmentManagementBLLibrary
{
    public interface IPatientService
    {
        Patient RegisterPatient(Patient patient);
        List<Patient> SearchPatients(string searchCriteria);
        Patient UpdatePatientInformation(Patient patient);
        bool ScheduleAppointment(int patientId, int doctorId, DateTime appointmentDateTime);
        Patient GetPatientById(int id);
        bool DeletePatient(int id);
        Patient GeneratePatientReport(int patientId);
    }
}
