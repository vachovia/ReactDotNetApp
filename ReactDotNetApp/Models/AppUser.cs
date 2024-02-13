using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactDotNetApp.Models
{
    public class AppUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(256)")]
        public string Name { get; set; }
    }
}
