﻿using PatientDemographicsService.Models;

namespace PatientDemographicsService.Contracts
{
    public interface IPatientRepository
    {
        Task<Patient> GetPatientById(int? id);
        Task<List<Patient>> GetAllPatients();
        Task<bool> UpdatePatient(Patient patient);
        Task CreatePatient(Patient patient);
        Task DeletePatient(int? id);
    }
}
