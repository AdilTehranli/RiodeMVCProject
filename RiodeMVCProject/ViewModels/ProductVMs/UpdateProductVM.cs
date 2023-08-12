using System.ComponentModel.DataAnnotations;

namespace RiodeMVCProject.ViewModels.ProductVMs
{
    public record UpdateProductVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public byte Raiting { get; set; }
        public int StockCount { get; set; }
        [Required]
        public string ProductImage { get; set; }
    }
}
