using Microsoft.EntityFrameworkCore;
using WebApp1.Contexts;
using WebApp1.Models;
using WebApp1.Models.Entities;
using WebApp1.ViewModels;

namespace WebApp1.Services;

public class ProductService
{
    private readonly IdentityDataContext _context;
    public ProductService(IdentityDataContext context)
    {
        _context = context;
    }

    //public ProductEntity ToProductEntity(ProductRegistrationViewModel viewModel)
    //{
    //    return new ProductEntity
    //    {
    //        Title = viewModel.Title,
    //        Description = viewModel.Description,
    //        ImageUrl = viewModel.ImageUrl,
    //        Price = viewModel.Price,
    //        ProductTags = viewModel.SelectedTagIds.Select(tagId => new ProductTagEntity { TagId = tagId }).ToList()
    //    };
    //}

    public List<TagEntity> GetAvailableTags()
    {
        return _context.Tags.ToList();
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
