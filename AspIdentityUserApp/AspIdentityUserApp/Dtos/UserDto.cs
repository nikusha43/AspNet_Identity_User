using static AspIdentityUserApp.Models.User;

namespace AspIdentityUserApp.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderType Gender { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
