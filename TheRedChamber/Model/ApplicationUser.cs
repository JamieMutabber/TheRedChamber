using Microsoft.AspNetCore.Identity;

namespace TheRedChamber.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } 
    }
}
