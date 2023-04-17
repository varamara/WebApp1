using WebApp1.Models;

namespace WebApp1.Services;

public class ShowcaseService
{
   
    private readonly List<ShowcaseModel> _showcases = new() { 

        new ShowcaseModel()
        {
            Ingress = "WELCOME TO BMERKETO SHOP",
            Title = "Title",
            ImageUrl = "images/placeholders/625x647.svg",
            Button = new LinkButtonModel
            {
                Content = "SHOP NOW",
                Url = "/products",
            }
        },

        new ShowcaseModel()
        {
            Ingress = "BMERKET SHOP",
            Title = "It's a shop",
            ImageUrl = "images/placeholders/625x647.svg",
            Button = new LinkButtonModel
            {
                Content = "SHOP NOW",
                Url = "/products",
            }
        }
    };
    

    public ShowcaseModel GetLatest()
    {
        return _showcases.LastOrDefault()!;
    }
}
