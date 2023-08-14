using System.ComponentModel.DataAnnotations;

namespace RiodeMVCProject.ViewModels.ProductVMs
{
    public record UpdateProductVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public byte Raiting { get; set; }
        [Required]
        public IFormFile ProductImage { get; set; }
    }
}
