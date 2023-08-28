namespace DoctorNotesService.Models
{
    public interface INoteStoreDatabaseSettings
    {
        string ConnectionString { get; set;  }
        string DatabaseName { get; set; }
        string CollectionName { get; set; }
    }
}