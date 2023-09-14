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

        // GET : /patients
        /// <summary>
        /// Method to get the list with all patients
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> Index()
        {
            var patients = await _patientRepository.GetAllPatients();
            return Ok(patients);
        }

        // GET : /patients/1
        /// <summary>
        /// Method to get a single patient specified by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        // PUT : /patients/{id}
        /// <summary>
        /// Method to update a patient specified by its id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patient"></param>
        /// <returns></returns>
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

        // POST : /patients
        /// <summary>
        /// Method to Create a new patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync(Patient patient)
        {
            await _patientRepository.CreatePatient(patient);

            return NoContent();
        }

        // DELETE : /patients/{id}
        /// <summary>
        /// Method to Delete a patient specified by its id
        /// This method was created and tested, but not yet implemented in the UI.
        /// A "Delete"button could be quickly added if needed.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
