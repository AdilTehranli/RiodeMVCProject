using System.ComponentModel.DataAnnotations;

namespace RiodeMVCProject.Models
{
    public class Product:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
       
        public string Category { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public byte Raiting { get; set; }
        
        public string ProductImage { get; set;}
    }
}
