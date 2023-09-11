using DoctorNotesService.Contracts;
using DoctorNotesService.Models;
using MongoDB.Driver;

namespace DoctorNotesService.Services
{
    public class NoteService : INoteService
    {
        private readonly IMongoCollection<Note> _notes;

        public NoteService(INoteStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _notes = database.GetCollection<Note>(settings.CollectionName);

        }

        public async Task<Note> CreateAsync(Note note)
        {
            await _notes.InsertOneAsync(note);
            return note;
        }

        public async Task<List<Note>> GetAsync()
        {
             return await _notes.Find(note => true).ToListAsync();
        }

        public async Task<Note> GetByIdAsync(string id)
        {
            return await _notes.Find(note => note.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Note>> GetByDoctorIdAsync(int id)
        {
            return await _notes.Find(note => note.DoctorId == id).ToListAsync();
        }

        public async Task<List<Note>> GetByPatientIdAsync(int id)
        {
            return await _notes.Find(note => note.PatientId == id).ToListAsync();
        }

        public async Task RemoveAsync(string id)
        {
            await _notes.DeleteOneAsync(note => note.Id == id);
        }

        public async Task UpdateAsync(string id, Note note)
        {
            await _notes.ReplaceOneAsync(note => note.Id == id, note);
        }
    }
}
