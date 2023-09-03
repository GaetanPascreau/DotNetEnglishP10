using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> PutAsync(int id, [FromBody] Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest("The 'id' in the url doesn't match the 'id' in the submitted patient object.");
            }

            //First check if the patient to update exists in the db
            var patientToUpdate = await _patientRepository.GetPatientById(id);

            if (patientToUpdate == null)
            {
                return NotFound();
            }

            var result = await _patientRepository.UpdatePatient(patient);

            if (result)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }   
        }

        // POST /patients
        [HttpPost]
        public async Task<IActionResult> PostAsync(Patient patient)
        {
            await _patientRepository.CreatePatient(patient);

            return NoContent();
        }

        // DELETE /patients/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _patientRepository.DeletePatient(id);
            return Ok($"Patient with id = {id} was deleted.");
        }
    }
}
