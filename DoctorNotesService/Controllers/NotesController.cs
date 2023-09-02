using DoctorNotesService.Models;
using DoctorNotesService.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorNotesService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        // GET: api/Notes
        [HttpGet]
        public async Task<List<Note>> GetAsync()
        {
            return await _noteService.GetAsync();
        }

        // GET api/Notes/note/64e861db375fbf7753cbbb7e
        [HttpGet("note/{id}")]
        public async Task<ActionResult<Note>> GetByIdAsync(string id)
        {
            var note = await _noteService.GetByIdAsync(id);

            if (note == null)
            {
                return NotFound($"Note with id = {id} not found.");
            }

            return note;
        }

        // GET api/Notes/doctor/5/notes
        [HttpGet("doctor/{doctorId}/notes")]
        public async Task<ActionResult<List<Note>>> GetByDoctorIdAsync(int doctorId)
        {
            var notes = await _noteService.GetByDoctorIdAsync(doctorId);

            if (notes == null)
            {
                return NotFound($"Notes with DoctorId = {doctorId} not found.");
            }

            return notes;
        }

        // GET api/Notes/patient/5/notes
        [HttpGet("patient/{patientId}/notes")]
        [ActionName(nameof(GetByPatientIdAsync))]
        public async Task<ActionResult<List<Note>>> GetByPatientIdAsync(int patientId)
        {
            var notes = await _noteService.GetByPatientIdAsync(patientId);

            if (notes == null)
            {
                return NotFound($"Notes with PatientId = {patientId} not found.");
            }

            return notes;
        }

        // POST api/Notes
        [HttpPost]
        public async Task<ActionResult<Note>> PostAsync([FromBody] Note note)
        {
            await _noteService.CreateAsync(note);
            //return CreatedAtAction(nameof(GetAsync), new { id = note.Id }, note);
            return CreatedAtAction(nameof(GetByPatientIdAsync), new { patientId = note.PatientId, id = note.Id }, note);
        }

        // PUT api/Notes/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(string id, [FromBody] Note note)
        {
            var existingNote = await _noteService.GetByIdAsync(id);

            if (existingNote == null)
            {
                return NotFound($"Note with id = {id} not found.");
            }

            await _noteService.UpdateAsync(id, note);
            return NoContent();
        }

        // DELETE api/Notes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            var note = await _noteService.GetByIdAsync(id);

            if (note == null)
            {
                return NotFound($"Note with id = {id} not found.");
            }

            await _noteService.RemoveAsync(note.Id);
            return Ok($"Note with id = {id} was deleted.");
        }
    }
}
