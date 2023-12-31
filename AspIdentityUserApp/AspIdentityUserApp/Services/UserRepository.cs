﻿using AspIdentityUserApp.DB;
using AspIdentityUserApp.Dtos;
using AspIdentityUserApp.Models;
using AspIdentityUserApp.Services.Abstraction;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AspIdentityUserApp.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager = default;
        private readonly SignInManager<User> _signInManager = default;
        private readonly ApplicationDbContext _db;
        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        public async Task<bool> DeleteUserAsync(string id)
        {
             var user = await _userManager.FindByIdAsync(id);
             var result = await _userManager.DeleteAsync(user);

            return result.Succeeded;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var userList = users.Select(user => new UserDto
            { 
                UserName = user.UserName,
                Email = user.Email
               
            }).ToList();

            return userList;
        }

        public async Task<bool> LoginUserAsync(string email, string password, bool RemmemberMe)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var result = await _signInManager.PasswordSignInAsync(user, password,RemmemberMe,false);
            return result.Succeeded;
        }

        public async Task<bool> RegisterUserAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user,password);
            
             return result.Succeeded;
            
        }
    }
}
