using DoctorNotesService.Contracts;

namespace DoctorNotesService.Models
{
    public class NoteStoreDatabaseSettings : INoteStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string CollectionName { get; set; } = string.Empty;
    }
}
