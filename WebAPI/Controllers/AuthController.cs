using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:Controller
    {
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Succes)
            {
                return BadRequest(userToLogin.Message);
            }
            var result =_authService.CreateAccessToken(userToLogin.Data);
            if (result.Succes)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Succes)
            {
                return BadRequest(userExists.Message);
            }
            var registerResult = _authService.Register(userForRegisterDto);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Succes)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
