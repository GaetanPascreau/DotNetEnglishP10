using PatientDemographicsService.Models;

namespace PatientDemographicsService.Contracts
{
    public interface IPatientRepository
    {
        Task<Patient> GetPatientById(int? id);
        Task<List<Patient>> GetAllPatients();
    }
}
