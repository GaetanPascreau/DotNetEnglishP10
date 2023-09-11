using System.ComponentModel.DataAnnotations;

namespace RiskReportService.Models
{
    public class PatientViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public char Sex { get; set; }
    }
}
