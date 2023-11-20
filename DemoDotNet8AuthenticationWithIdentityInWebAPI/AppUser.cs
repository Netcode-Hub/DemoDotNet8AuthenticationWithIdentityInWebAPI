using Microsoft.AspNetCore.Identity;
namespace DemoDotNet8AuthenticationWithIdentityInWebAPI
{
    public class AppUser : IdentityUser
    {
        public string? Fullname { get; set; }
        public int Contact { get; set; }
        public string? Address { get; set; }
    }
}
