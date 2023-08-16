using RiodeMVCProject.Models;
using System.ComponentModel.DataAnnotations;

namespace RiodeMVCProject.ViewModels.ProductVMs
{
	public record UpdateProductGETVM
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

		public string ProductImage { get; set; }
		public ICollection<ProductImage> ProductImages { get; set; }

		public IFormFile ProductImageFile { get; set; }
		public ICollection<IFormFile> ProductImagesFiles { get; set; }
	}
}
