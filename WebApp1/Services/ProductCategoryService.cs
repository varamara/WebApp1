﻿using WebApp1.Models.Dtos;
using WebApp1.Models.Entities;
using WebApp1.Models.Schemas;
using WebApp1.Repositories;

namespace WebApp1.Services;
public class ProductCategoryService
{
    private readonly ProductCategoryRepository _productCategoryRepo;

    public ProductCategoryService(ProductCategoryRepository productCategoryRepo)
    {
        _productCategoryRepo = productCategoryRepo;
    }

    public async Task<ProductCategory> CreateProductCategoryAsync(string categoryName)
    {
        var entity = new ProductCategoryEntity { CategoryName = categoryName };
        var result = await _productCategoryRepo.AddAsync(entity);
        return result;
    }


    public async Task<ProductCategory> CreateProductCategoryAsync(ProductCategorySchema schema)
    {
        var result = await _productCategoryRepo.AddAsync(schema);
        return result;
    }

    public async Task<ProductCategory> GetProductCategoryAsync(int id)
    {
        var result = await _productCategoryRepo.GetAsync(x => x.Id == id);
        return result;
    }

    public async Task<ProductCategory> GetProductCategoryAsync(string categoryName)
    {
        var result = await _productCategoryRepo.GetAsync(x => x.CategoryName == categoryName);
        return result;
    }

    public async Task<ProductCategory> GetProductCategoryAsync(ProductCategorySchema schema)
    {
        var result = await _productCategoryRepo.GetAsync(x => x.CategoryName == schema.CategoryName);
        return result;
    }

    public async Task<IEnumerable<ProductCategory>> GetProductCategoriesAsync()
    {
        var result = await _productCategoryRepo.GetAllAsync();
        var list = new List<ProductCategory>();
        foreach (var category in result)
            list.Add(category);

        return list;
    }



}