﻿using WebApp1.Models.Dtos;

namespace WebApp1.Models.Entities;

public class ProductCategoryEntity
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;

    public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();


    public static implicit operator ProductCategory(ProductCategoryEntity entity)
    {
        if (entity != null)
        {
            return new ProductCategory
            {
                Id = entity.Id,
                CategoryName = entity.CategoryName
            };
        }

        return null!;
    }

}
