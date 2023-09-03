using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace MediscreenWebUI.Models
{
    public class NoteViewModel
    {
        public string Id { get; set; } = string.Empty;

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        [Display(Name = "Note Content")]
        public string NoteContent { get; set; } = string.Empty;
    }

    public class NoteValidator : AbstractValidator<NoteViewModel>
    {
        public NoteValidator()
        {
            RuleFor(n => n.NoteContent).NotEmpty().WithMessage("Note content is required.");
        }
    }
}
