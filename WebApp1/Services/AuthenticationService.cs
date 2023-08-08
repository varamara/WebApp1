﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp1.Models.Identity;
using WebApp1.ViewModels;

namespace WebApp1.Services
{
    public class AuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AddressService _addressService;

        public AuthenticationService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AddressService addressService, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _addressService = addressService;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<bool> UserAlreadyExistsAsync(Expression<Func<AppUser, bool>> expression)
        {
           return await _userManager.Users.AnyAsync(expression);
        }

        public async Task<bool> RegisterUserAsync(RegisterViewModel viewModel)
        {
            var appUser = new AppUser
            {
                UserName = viewModel.Email,
                Email = viewModel.Email,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName
            };

            var roleName = "user";

            if (!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
                await _roleManager.CreateAsync(new IdentityRole("user"));
            }

            if (!await _userManager.Users.AnyAsync())
            {
                roleName = "admin";
            }

            var result = await _userManager.CreateAsync(appUser, viewModel.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, roleName);

                var addressEntity = await _addressService.GetOrCreateAsync(viewModel);
                if (addressEntity != null)
                {
                    await _addressService.AddAddressAsync(appUser, addressEntity);
                    return true;
                } 
            }

            return false;
        }

        public async Task<bool> LoginAsync(LoginViewModel viewModel)
        {
            var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == viewModel.Email);
            if (appUser != null)
            {
                var result = await _signInManager.PasswordSignInAsync(appUser, viewModel.Password, viewModel.RememberMe, false);
                return result.Succeeded;
            }

            return false;
        }
    }
}
