﻿using WebApp1.Models.Dtos;

namespace WebApp1.Models.Entities;


public class TagEntity
{
    public int Id { get; set; }
    public string TagName { get; set; } = null!;

    public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();

    public static implicit operator Tag(TagEntity entity)
    {
        return new Tag
        {
            Id = entity.Id,
            TagName = entity.TagName,
        };
    }
}
 