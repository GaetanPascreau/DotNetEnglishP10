using System.ComponentModel.DataAnnotations;

namespace MediscreenUI.Models
{
    public class PatientViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public char Sex { get; set; }

        public string HomeAdress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
