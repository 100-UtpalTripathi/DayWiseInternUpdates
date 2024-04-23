﻿using AppointmentManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
