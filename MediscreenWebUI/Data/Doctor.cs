using Microsoft.AspNetCore.Identity;

namespace MediscreenWebUI.Data
{
    public class Doctor : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }
    }
}
