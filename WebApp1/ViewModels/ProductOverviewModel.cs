using WebApp1.Models.Entities;

namespace WebApp1.ViewModels
{
	public class ProductOverviewModel
	{
		public string ProductName { get; set; } = null!;
		public string? ProductDescription { get; set; }
		public decimal ProductPrice { get; set; }
		public string? ProductImage { get; set; }
		public string? ProductCategory { get; set; }

		public static ProductOverviewModel FromProductEntity(ProductEntity productEntity)
		{
			return new ProductOverviewModel
			{
				ProductName = productEntity.ProductName,
				ProductDescription = productEntity.ProductDescription,
				ProductPrice = productEntity.ProductPrice,
				ProductImage = productEntity.ProductImage,
				ProductCategory = productEntity.ProductCategory?.CategoryName // Använd navigationsproperty för att hämta kategorinamnet
			};
		}
	}
}
