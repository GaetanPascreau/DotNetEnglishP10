using Microsoft.EntityFrameworkCore;
using PatientDemographicsService.Contracts;
using PatientDemographicsService.Models;

namespace PatientDemographicsService.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly MediscreenDbContext _context;

        public PatientRepository(MediscreenDbContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetAllPatients()
        {  
                return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatientById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await _context.Patients.FindAsync(id);
        }
    }
}
