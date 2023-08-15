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
        public async Task<ActionResult<IEnumerable<Patient>>> Index()
        {
            var patients = await _patientRepository.GetAllPatients();
            return Ok(patients);
        }

        // GET /patients/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> Details(int id)
        {
            var patient = await _patientRepository.GetPatientById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        // PUT /patients/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Patient patient)
        {
            //First check if the patient to update exists in the db
            var patientToUpdate = await _patientRepository.GetPatientById(patient.Id);

            if (patientToUpdate == null)
            {
                return NotFound();
            }

            await _patientRepository.UpdatePatient(patient);

            return NoContent();
        }

        // POST /patients
        [HttpPost]
        public async Task<IActionResult> PostAsync(Patient patient)
        {
            await _patientRepository.CreatePatient(patient);

            return NoContent();
        }
    }
}
