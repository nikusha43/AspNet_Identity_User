using Microsoft.AspNetCore.Identity;

namespace AspIdentityUserApp.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public enum GenderType {Male,Female,Other};
        public GenderType Gender { get; set; }
    }
}
