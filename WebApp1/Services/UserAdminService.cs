﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models.Identity;

namespace WebApp1.Services;

public class UserAdminService
{
    private readonly UserManager<AppUser> _userManager;

    public UserAdminService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        var users = new List<User>();
        foreach(var user in await _userManager.Users.ToListAsync())
        {
            var _user = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,

            };

            foreach (var role in await _userManager.GetRolesAsync(user))
            {
                _user.RoleNames.Add(role);
            }

            users.Add(_user);
        }

        return users;
    }
}

public class User
{
    public string? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public List<string> RoleNames { get; set; } = new List<string>();   
}
