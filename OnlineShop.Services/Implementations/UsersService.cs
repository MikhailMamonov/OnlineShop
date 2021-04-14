using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using OnlineShop.Models;
using OnlineShop.Models.Entities;
using OnlineShop.Services.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;
        public UsersService(ApplicationDbContext context, UserManager<User> userManager)
        {
            this._db = context;
            this._userManager = userManager;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<bool> AddUserAsync(User user)
        {
            var result =await _userManager.CreateAsync(user, user.PasswordHash);
            var createdRowCount =await _db.SaveChangesAsync();
            if (result.Succeeded)
            {
                var currentUser = await _userManager.FindByNameAsync(user.DisplayName);
                var roleResult = _userManager.AddToRoleAsync(currentUser, "Admin");
                return createdRowCount > 0;
            }
            else {
                return false;
            }
            
        }

        public async Task<bool> UpdateUserAsync(int id, User user)
        {
            var entity =await _db.Users.FindAsync(id);
            _db.Entry(entity).CurrentValues.SetValues(user);
            var updatedRowsCount = _db.SaveChangesAsync();
            return await updatedRowsCount > 0;
        }
        public async Task<bool> DeleteUser(string id)
        {
            var user =await _db.Users.FindAsync(id);
            _db.Users.Remove(user);
            var deletedRowsCount =await _db.SaveChangesAsync();
            return deletedRowsCount > 0;
        }
    }
}
