﻿//using Microsoft.EntityFrameworkCore;
//using System.Linq.Expressions;
//using WebApp1.Contexts;
//using WebApp1.Models.Entities;
//using WebApp1.Models.Identity;

//namespace WebApp1.Services;

//public class UserService
//{
//    private readonly DataContext _context;

//    public UserService(DataContext context)
//    {
//        _context = context;
//    }

//    public async Task<UserEntity> GetAsync(Expression<Func<UserEntity, bool>> predicate)
//    {

//        var userEntity = await _context.Users.FirstOrDefaultAsync(predicate);

//        if (userEntity == null)
//        {
//            return null;
//        }
//        return userEntity;
//    }
//}
