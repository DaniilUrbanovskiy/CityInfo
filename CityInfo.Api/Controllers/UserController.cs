using AutoMapper;
using CityInfo.Api.Dto.Requests;
using CityInfo.Api.Dto.Responses;
using CityInfo.Api.Infrastructure;
using CityInfo.Domain.Entities;
using CityInfo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CityInfo.Api.Controllers
{
    [ApiController]
    [Authorize]
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

        [AllowAnonymous]
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

        [AllowAnonymous]
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

        [HttpGet("favourites/get")]
        public IActionResult GetFavourites() 
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var result =  _userService.GetFavourites(int.Parse(userId));
            var cities = _mapper.Map<List<CityResponse>>(result);

            return Ok(cities);
        }

        [HttpPost("favourites/set/{cityName}")]
        public IActionResult SetFavourites([FromRoute]string cityName)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            try
            {
                _userService.SetFavourites(int.Parse(userId), cityName);
                return Ok($"{cityName} was added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }          
        }

        [HttpDelete("favourites/remove/{cityName}")]
        public IActionResult RemoveFavourites([FromRoute] string cityName)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            try
            {
                _userService.RemoveFavourites(int.Parse(userId), cityName);
                return Ok($"{cityName} was removed successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }   
}
