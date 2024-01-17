using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReactDotNetApp.DTO
{
    public class MenuItemDto: BaseDto
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string SpecialTag { get; set; }
        
        public string Category { get; set; }
        
        public double Price { get; set; }
       
        public string Image { get; set; }
    }
}
