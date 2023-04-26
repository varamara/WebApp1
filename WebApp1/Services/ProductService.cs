using Microsoft.EntityFrameworkCore;
using WebApp1.Contexts;
using WebApp1.Models;
using WebApp1.Models.Entities;
using WebApp1.ViewModels;

namespace WebApp1.Services;

public class ProductService
{
    private readonly DataContext _context;
    public ProductService(DataContext context)
    {
        _context = context;
    }


    //Create Product
    public async Task<bool> CreateAsync(ProductRegistrationViewModel productRegistrationViewModel)
    {
        try
        {
           ProductEntity productEntity = productRegistrationViewModel;

            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();
            return true;
        } 
        catch
        {
            return false;
        }
    }

    //Get Product
    public async Task<IEnumerable<ProductModel>> GetAllAsync()
    {
        var products = new List<ProductModel>();
        var items = await _context.Products.ToListAsync();

        foreach (var item in items)
        {
            ProductModel productModel = item;
            products.Add(productModel);
        }
        return products;       
    }



    internal static object GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    
}
