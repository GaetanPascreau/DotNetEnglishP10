namespace MediscreenUI.Models
{
    public class NoteViewModel
    {  
            public string Id { get; set; } = string.Empty;

            public int PatientId { get; set; }

            public int DoctorId { get; set; }

            public string NoteContent { get; set; } = string.Empty;
    }
}
