using AutoMapper;
using CityInfo.Api.Dto.Requests;
using CityInfo.Api.Infrastructure;
using CityInfo.Domain.Entities;
using CityInfo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace CityInfo.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;
        public UserController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("registr")]
        public async Task<IActionResult> Registr([FromBody] UserRegisterRequest userInfo)
        {
            try
            {
                var user = _mapper.Map<User>(userInfo);
                await _userService.Registration(user);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userInfo)
        {
            try
            {
                var user = await _userService.Login(userInfo.Login, userInfo.Password);
                var token = JwtHealper.CreateToken(user);
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }   
}
