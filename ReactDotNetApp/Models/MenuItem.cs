using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactDotNetApp.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string SpecialTag { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Category { get; set; }

        [Range(1, int.MaxValue)]
        public double Price { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Image { get; set; }
    }
}
