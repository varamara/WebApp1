using Microsoft.EntityFrameworkCore;
using WebApp1.Contexts;
using WebApp1.Models;
using WebApp1.Models.Dtos;
using WebApp1.Models.Entities;
using WebApp1.Models.Schemas;
using WebApp1.Repositories;
using WebApp1.ViewModels;

namespace WebApp1.Services;
public class ProductService
{
    private readonly ProductRepository _productRepo;
    private readonly ProductCategoryService _productCategoryService;
    private readonly TagService _tagService;
    private readonly ProductTagRepository _productTagRepo;

    public ProductService(ProductRepository productRepo, ProductCategoryService productCategoryService, TagService tagService, ProductTagRepository productTagRepo)
    {
        _productRepo = productRepo;
        _productCategoryService = productCategoryService;
        _tagService = tagService;
        _productTagRepo = productTagRepo;
    }

    public async Task<Product> CreateProductAsync(ProductSchema schema)
    {
        ProductEntity entity = schema;

        if (await _productCategoryService.GetProductCategoryAsync(entity.ProductCategoryId) != null)
        {
            entity = await _productRepo.AddAsync(entity);

            if (entity != null)
            {
                foreach (var tagName in schema.Tags)
                {
                    var tag = await _tagService.GetTagAsync(tagName);
                    tag ??= await _tagService.CreateTagAsync(tagName);

                    await _productTagRepo.AddAsync(new ProductTagEntity
                    {
                        ArticleNumber = entity.ArticleNumber,
                        TagId = tag.Id,
                    });
                }

                return await GetProductAsync(entity.ArticleNumber);
            }
        }

        return null!;
    }


    public async Task<Product> GetProductAsync(string articleNumber)
    {
        var entity = await _productRepo.GetAsync(x => x.ArticleNumber == articleNumber);
        if (entity != null)
        {
            Product product = entity;

            if (entity.ProductTags.Count > 0)
            {
                var tagList = new List<Tag>();

                foreach (var productTag in entity.ProductTags)
                    tagList.Add(new Tag { Id = productTag.Tag.Id, TagName = productTag.Tag.TagName });

                product.Tags = tagList;
            }

            return product;
        }

        return null!;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        var result = await _productRepo.GetAllAsync();
        var list = new List<Product>();
        foreach (var entity in result)
        {
            Product product = entity;

            if (entity.ProductTags.Count > 0)
            {
                var tagList = new List<Tag>();

                foreach (var productTag in entity.ProductTags)
                    tagList.Add(new Tag { Id = productTag.Tag.Id, TagName = productTag.Tag.TagName });

                product.Tags = tagList;
            }

            list.Add(product);
        }


        return list;
    }
}
