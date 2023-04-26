using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp1.Contexts;
using WebApp1.Models.Entities;
using WebApp1.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApp1.Services;

public class UserService
{

    private readonly DataContext _context;

    public UserService(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> UserExists(Expression<Func<UserEntity, bool>> predicate)
    {
        if (await _context.Users.AnyAsync(predicate))
            return true;

        return false;
    }
    public async Task<UserEntity> GetAsync(Expression<Func<UserEntity, bool>> predicate)
    {
       var userEntity = await _context.Users.FirstOrDefaultAsync(predicate);
        return userEntity;
    }
    public async Task<bool> RegisterAsync(RegisterViewModel registerViewModel)
    {
        try
        {
            // convert to userEntity and profile Entity from registrationform
            UserEntity userEntity = registerViewModel;
            ProfileEntity profileEntity = registerViewModel;

            // create user
            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();

            // create user profile
            profileEntity.UserId = userEntity.Id;
            _context.Profiles.Add(profileEntity);
            await _context.SaveChangesAsync();


            return true;
        }
        catch
        {
            return false;
        }
    }
    public async Task<bool> LoginAsync(LoginViewModel loginViewModel)
    {
        var userEntity = await GetAsync(x => x.Email == loginViewModel.Email);
        if (userEntity != null)
            return userEntity.VerifySecurePassword(loginViewModel.Password);

        return false;
    }
}
