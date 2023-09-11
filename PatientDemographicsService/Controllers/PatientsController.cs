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

        /// <summary>
        /// Method to get the list with all patients
        /// </summary>
        /// <returns></returns>
        // GET /patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> Index()
        {
            var patients = await _patientRepository.GetAllPatients();
            return Ok(patients);
        }

        /// <summary>
        /// Method to get a single patient specified by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET /patients/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> Details(int id)
        {
            var patient = await _patientRepository.GetPatientById(id);

            if (patient == null)
            {
                return NotFound($"Patient with id = {id} was not found.");
            }

            return Ok(patient);
        }

        /// <summary>
        /// Method to update a patient specified by its id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patient"></param>
        /// <returns></returns>
        // PUT /patients/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest("The 'id' in the url doesn't match the 'id' in the submitted patient object.");
            }

            // Check if the patient to update exists in the db
            var patientToUpdate = await _patientRepository.GetPatientById(id);

            if (patientToUpdate == null)
            {
                return NotFound($"Patient with id = {id} was not found.");
            }

            var result = await _patientRepository.UpdatePatient(patient);

            if (result)
            {
                return NoContent();
            }
            else
            {
                return BadRequest($"Patient with id = {id} couldn't be updated.");
            }   
        }

        /// <summary>
        /// Method to Create a new patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        // POST /patients
        [HttpPost]
        public async Task<IActionResult> PostAsync(Patient patient)
        {
            await _patientRepository.CreatePatient(patient);

            return NoContent();
        }

        /// <summary>
        /// Method to Delete a patient specified by its id
        /// This method was created and tested, but not yet implemented in the UI.
        /// A "Delete"button could be quickly added if needed.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
