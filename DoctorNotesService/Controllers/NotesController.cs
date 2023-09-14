using DoctorNotesService.Contracts;
using DoctorNotesService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorNotesService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NotesController(INoteRepository noteService)
        {
            _noteRepository = noteService;
        }

        // GET : api/Notes
        /// <summary>
        /// Method to get all notes for all patients.
        /// Could be used for statistics  purpose.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Note>> GetAsync()
        {
            return await _noteRepository.GetAsync();
        }

        // GET : api/Notes/note/64e861db375fbf7753cbbb7e
        /// <summary>
        /// Method to get a single note, by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("note/{id}")]
        public async Task<ActionResult<Note>> GetByIdAsync(string id)
        {
            var note = await _noteRepository.GetByIdAsync(id);

            if (note == null)
            {
                return NotFound($"Note with id = {id} not found.");
            }

            return note;
        }

        // GET : api/Notes/doctor/5/notes
        /// <summary>
        /// Method to get all notes from a given doctor.
        /// Not currently used. Could be usefull if we add several doctors to the database.
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        [HttpGet("doctor/{doctorId}/notes")]
        public async Task<ActionResult<List<Note>>> GetByDoctorIdAsync(int doctorId)
        {
            var notes = await _noteRepository.GetByDoctorIdAsync(doctorId);

            if (notes == null)
            {
                return NotFound($"Notes with DoctorId = {doctorId} not found.");
            }

            return notes;
        }

        // GET : api/Notes/patient/5/notes
        /// <summary>
        /// Method to get all notes for a given patient.
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [HttpGet("patient/{patientId}/notes")]
        [ActionName(nameof(GetByPatientIdAsync))]
        public async Task<ActionResult<List<Note>>> GetByPatientIdAsync(int patientId)
        {
            var notes = await _noteRepository.GetByPatientIdAsync(patientId);

            if (notes == null)
            {
                return NotFound($"Notes with PatientId = {patientId} not found.");
            }

            return notes;
        }

        // POST : api/Notes
        /// <summary>
        /// Method to create a new note.
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Note>> PostAsync([FromBody] Note note)
        {
            await _noteRepository.CreateAsync(note);
            return CreatedAtAction(nameof(GetByPatientIdAsync), new { patientId = note.PatientId, id = note.Id }, note);
        }

        // PUT : api/Notes/5
        /// <summary>
        /// Method to update an existing note with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(string id, [FromBody] Note note)
        {
            var existingNote = await _noteRepository.GetByIdAsync(id);

            if (existingNote == null)
            {
                return NotFound($"Note with id = {id} not found.");
            }

            await _noteRepository.UpdateAsync(id, note);
            return NoContent();
        }

        // DELETE : api/Notes/5
        /// <summary>
        /// Method to Delete a note with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            var note = await _noteRepository.GetByIdAsync(id);

            if (note == null)
            {
                return NotFound($"Note with id = {id} not found.");
            }

            await _noteRepository.RemoveAsync(note.Id);
            return Ok($"Note with id = {id} was deleted.");
        }
    }
}
