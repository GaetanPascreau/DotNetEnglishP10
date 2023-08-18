namespace PatientDemographicsService.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string LastName { get; set; }

        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char Sex { get; set; }
        public string? HomeAdress { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
