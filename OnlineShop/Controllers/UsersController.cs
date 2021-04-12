using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using OnlieShop.Domain.Models.DTO;
using OnlieShop.Domain.Models.Entities;

using OnlineShop.Models.Entities;
using OnlineShop.Services;
using OnlineShop.Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;

        IUsersService _usersService;
        public UsersController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;

        }

        [HttpPost]
        public IActionResult AddUser([FromForm] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("User Object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            var user = new User
            {
                DisplayName = userDTO.DisplayName,
                Email = userDTO.Email
            };

            //var userEntity = _mapper
             _usersService.AddUserAsync(user);
            return Ok();
        }

        [HttpGet]
        public IActionResult Users()
        {
            var users = _usersService.GetUsers();
            var usersDTO = _mapper.Map<List<UserDTO>>(users);
            return Ok(usersDTO);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            _usersService.UpdateUser(id, user);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            if (!_usersService.GetUsers().Any(user => user.Id == id))
            {
                return BadRequest("User id not found");
            }
            _usersService.DeleteUser(id);
            return Ok(id);
        }
    }
}
