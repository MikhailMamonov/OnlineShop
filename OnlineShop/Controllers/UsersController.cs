using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> AddUser([FromForm] UserDTO userDTO)
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
                Email = userDTO.Email,
                PasswordHash = userDTO.Password
            };

            //var userEntity = _mapper
            if ((await _usersService.AddUserAsync(user)))
                return Ok(userDTO);
            else
                return StatusCode(StatusCodes.Status500InternalServerError,"User creating is Failed");
        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var users = await _usersService.GetUsersAsync();
            var usersDTO = _mapper.Map<List<UserDTO>>(users);
            return Ok(usersDTO);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            var result = await _usersService.UpdateUserAsync(id, user);
            if (!result)
                return BadRequest("User not updated");
            else
                return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var users = await _usersService.GetUsersAsync();
            if (!users.Any(user => user.Id == id))
            {
                return BadRequest("User id not found");
            }
            var result = await _usersService.DeleteUser(id);
            if (!result)
                return BadRequest("User not deleted");
            else
                return Ok(string.Format("user with id -> {0} succes deleted",id));
        }
    }
}
