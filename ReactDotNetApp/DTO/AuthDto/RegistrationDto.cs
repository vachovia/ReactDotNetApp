using System.ComponentModel.DataAnnotations;

namespace ReactDotNetApp.DTO.AuthDto
{
    public class RegistrationDto : LoginRequestDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
