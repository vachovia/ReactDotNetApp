using Microsoft.AspNetCore.Identity;

namespace ReactDotNetApp.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
