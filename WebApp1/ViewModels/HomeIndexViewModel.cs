namespace WebApp1.ViewModels
{
    public class HomeIndexViewModel
    {
        public string Title { get; set; } = "Home";
        public GridCollectionViewModel BestCollection { get; set; } = null!;
        public PromotionViewModel Promotion { get; set; } = null!;

    }
}
