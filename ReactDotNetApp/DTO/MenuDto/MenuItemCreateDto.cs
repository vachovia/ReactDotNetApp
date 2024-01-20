using System.ComponentModel.DataAnnotations;

namespace ReactDotNetApp.DTO.MenuDto
{
    public class MenuItemCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(50)]
        public string SpecialTag { get; set; }

        [StringLength(100)]
        public string Category { get; set; }

        [Range(1, int.MaxValue)]
        public double Price { get; set; }

        public string Image { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }
}
