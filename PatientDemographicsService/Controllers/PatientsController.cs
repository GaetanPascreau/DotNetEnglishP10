using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientDemographicsService.Contracts;
using PatientDemographicsService.Models;

namespace PatientDemographicsService.Controllers
{
    [ApiController]
    [Route("Patients")]
    public class PatientsController : Controller
    {
        private readonly IPatientRepository _patientRepository;

        public PatientsController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        // GET /patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAsync()
        {
            var patients = await _patientRepository.GetAllPatients();
            return Ok(patients);
        }

        // GET /patients/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetByIdAsync(int id)
        {
            var patient = await _patientRepository.GetPatientById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }
    }
}
