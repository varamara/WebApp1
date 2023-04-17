namespace WebApp1.ViewModels
{
    public class ProductDetailsViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal price { get; set; }
    }
}
