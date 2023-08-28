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

        // GET: api/<NotesController>
        [HttpGet]
        public async Task<List<Note>> GetAsync()
        {
            return await _noteService.GetAsync();
        }

        // GET api/<NotesController>/64e861db375fbf7753cbbb7e
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

        // GET api/<NotesController>/5
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

        // GET api/<NotesController>/5
        [HttpGet("patient/{patientId}/notes")]
        public async Task<ActionResult<List<Note>>> GetByPatientIdAsync(int patientId)
        {
            var notes = await _noteService.GetByPatientIdAsync(patientId);

            if (notes == null)
            {
                return NotFound($"Notes with PatientId = {patientId} not found.");
            }

            return notes;
        }

        // POST api/<NotesController>
        [HttpPost]
        public async Task<ActionResult<Note>> PostAsync([FromBody] Note note)
        {
            await _noteService.CreateAsync(note);
            return CreatedAtAction(nameof(GetAsync), new { id = note.Id }, note);
        }

        // PUT api/<NotesController>/5
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

        // DELETE api/<NotesController>/5
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
