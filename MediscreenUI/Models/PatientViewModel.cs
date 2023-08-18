using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace MediscreenUI.Models
{
    public class PatientViewModel
    {
        public int Id { get; set; }

        //[Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        //[Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //[Required]
        [Display(Name = "Date of birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        //[Required]
        [Display(Name = "Sex")]
        public char Sex { get; set; }

        [Display(Name = "Home address")]
        [StringLength(100)]
        public string? HomeAdress { get; set; }

        [StringLength(12)]
        [Display(Name = "Phone number")]
        public string? PhoneNumber { get; set; }
    }

    public class PatientValidator : AbstractValidator<PatientViewModel>
    {
        public PatientValidator() 
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("First Name is required.");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Last Name is required.");
            RuleFor(p => p.DateOfBirth).NotEmpty().WithMessage("Date of birth is required.");
            RuleFor(p => p.Sex).NotEmpty().WithMessage("Sex is required.");
        }
    }
}
