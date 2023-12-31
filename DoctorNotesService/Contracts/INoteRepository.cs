﻿using DoctorNotesService.Models;

namespace DoctorNotesService.Contracts
{
    public interface INoteRepository
    {
        Task<List<Note>> GetAsync();
        Task<Note> GetByIdAsync(string id);
        Task<List<Note>> GetByDoctorIdAsync(int id);
        Task<List<Note>> GetByPatientIdAsync(int id);
        Task<Note> CreateAsync(Note note);
        Task UpdateAsync(string id, Note note);
        Task RemoveAsync(string id);
    }
}
