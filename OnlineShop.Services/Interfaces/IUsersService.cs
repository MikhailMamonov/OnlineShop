using OnlieShop.Domain.Models.DTO;

using OnlineShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Interfaces
{
    public interface IUsersService
    {
        public Task<List<User>> GetUsersAsync();
        public Task<string> AddUserAsync(User user);
        public Task<bool> UpdateUserAsync(int id, User user);
        public Task<bool> DeleteUser(string id);
    }
}
