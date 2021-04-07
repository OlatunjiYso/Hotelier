using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hotelier.Data;
using hotelier.Models;
using hotelier.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using hotelier.Helpers;
using hotelier.DTOs;

namespace hotelier.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly HotelierContext _context;
        private IUserService _userService;
        private IMapper _mapper;

        public UserController(HotelierContext context, IUserService userService, IMapper mapper)
        {
            _context = context;
            _userService = userService;
            _mapper = mapper;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        // GET: api/User/signup
        [AllowAnonymous]
        [HttpPost("signup")]
        public IActionResult Signup([FromBody] RegisterReq model)
        {
            try
            {
                // create user
                _userService.Create(model);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // // GET: api/User
        // [HttpGet()]
        // public IActionResult GetUsers()
        // {
        //    var users =  _userService.GetAll();
        //    return Ok(users);
        // }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody]UserUpdateReq model)
        {
            model.Id = id;
            try
            {
                _userService.Update(model);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
