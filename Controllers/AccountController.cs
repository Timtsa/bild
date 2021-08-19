using ExersiseSQLite.DTOs;
using ExersiseSQLite.Models;
using ExersiseSQLite.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExersiseSQLite.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]//Mayby chenge to "[controller]"
    public class AccountController : ControllerBase

    {
        private readonly UserManager<UserApp> _userManager;
        private readonly SignInManager<UserApp> _signInManager;       
        private readonly Tokenservice _tokenService;
        public AccountController(UserManager<UserApp> userManager, SignInManager<UserApp> signInManager,
            Tokenservice tokenService)
        {
            _userManager = userManager;
           _signInManager = signInManager;
            _tokenService = tokenService;

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized();
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password,false);

            if (result.Succeeded)
            {
                return  CreateUserOdject(user);
            }
            return Unauthorized();
        }

        [HttpPost("registry")]

        public async Task<ActionResult<UserDto>> Register(RegisterDto register)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == register.Email))
            {
                return BadRequest("Email taken");
            }

            if (await _userManager.Users.AnyAsync(x => x.UserName == register.UserName))
            {
                return BadRequest("User name taken");
            }

            var user = new UserApp
            {
                DisplayName = register.DisplayName,
                Email = register.Email,
                UserName = register.UserName
            };

            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                return CreateUserOdject(user);
            }

            return BadRequest("Problem registry user"); 
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            return CreateUserOdject(user);
        }


        private UserDto CreateUserOdject(UserApp user )
        {
            return new UserDto
            {
                DisplayName = user.DisplayName,
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };

        }
    }

}
