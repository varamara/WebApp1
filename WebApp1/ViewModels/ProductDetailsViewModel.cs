using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.ViewModels
{
    public class ProductDetailsViewModel
    {
		public string Title { get; set; } = "Shop";
		public GridCollectionViewModel RelatedProducts { get; set; } = null!;
	}
}