using WebApp1.Models;

namespace WebApp1.Services;

public class DiscoverService
{

    private readonly List<DiscoverModel> _discovers = new() {

        new DiscoverModel()
        {
            Title = "UP TO SELL",
            DiscountPercent = "50% OFF",
            Ingress = "Get the Best Price",
            Text = "Get the best daily offer et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren no sea taki",
            Button = new LinkButtonModel
            {
                Content = "Discover More",
                Url = "/products",
            }
        }
    };

    public DiscoverModel GetDiscovers()
    {
        return _discovers.LastOrDefault()!;
    }
}