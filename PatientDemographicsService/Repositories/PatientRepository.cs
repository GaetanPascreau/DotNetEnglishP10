using Microsoft.EntityFrameworkCore;
using PatientDemographicsService.Contracts;
using PatientDemographicsService.Models;
using System.Reflection.Metadata;

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

        public async Task<bool> UpdatePatient(Patient patient)
        {
            var patientToUpdate = await _context.Patients.FirstOrDefaultAsync(app => app.Id == patient.Id);

            if (patientToUpdate is null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            patientToUpdate.FirstName = patient.FirstName;
            patientToUpdate.LastName = patient.LastName;
            patientToUpdate.DateOfBirth = patient.DateOfBirth;
            patientToUpdate.Sex = patient.Sex;
            patientToUpdate.HomeAdress = patient.HomeAdress;
            patientToUpdate.PhoneNumber = patient.PhoneNumber;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task CreatePatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            await _context.Patients.AddAsync(patient);

            await _context.SaveChangesAsync();
        }
    }
}
