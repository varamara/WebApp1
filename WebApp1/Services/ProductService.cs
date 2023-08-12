using Microsoft.EntityFrameworkCore;
using WebApp1.Contexts;
using WebApp1.Models;
using WebApp1.Models.Entities;
using WebApp1.ViewModels;

namespace WebApp1.Services;

public class ProductService
{
    private readonly IdentityContext _context;
    public ProductService(IdentityContext context)
    {
        _context = context;
    }

  
    public async Task<bool> RegisterProductAsync(ProductEntity productEntity)
    {
        _context.Products.Add(productEntity);
        int result = await _context.SaveChangesAsync();
        return result > 0;
    }


    //Get Product
    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        var productEntity = new List<ProductEntity>();
        var items = await _context.Products.ToListAsync();

        foreach (var item in items)
        {
            ProductEntity productModel = item;
            productEntity.Add(productModel);
        }
        return productEntity;
    }

    internal static object GetProductById(int id)
    {
        throw new NotImplementedException();
    }
}
