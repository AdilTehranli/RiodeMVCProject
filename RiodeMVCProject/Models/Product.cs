using System.ComponentModel.DataAnnotations;

namespace RiodeMVCProject.Models
{
    public class Product:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public byte Raiting { get; set; }
        public bool IsDeleted { get; set; }

        public string ProductImage { get; set;}
        public ICollection<ProductImage>? productImages { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }

    }
}
