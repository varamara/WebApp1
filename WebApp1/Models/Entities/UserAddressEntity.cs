﻿using Microsoft.EntityFrameworkCore;
using WebApp1.Models.Identity;

namespace WebApp1.Models.Entities
{

    [PrimaryKey(nameof(UserId), nameof(AddressId))]
    public class UserAddressEntity
    {
        public string UserId { get; set; } = null!;
        public AppUser User { get; set; } = null!;
        public int AddressId { get; set; }
        public AddressEntity Address { get; set; } = null!;

    }
}
