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
        public Task<List<User>> GetUsers();
        public Task<bool> AddUserAsync(User user);
        public void UpdateUser(int id, User user);
        public void DeleteUser(string id);
    }
}
