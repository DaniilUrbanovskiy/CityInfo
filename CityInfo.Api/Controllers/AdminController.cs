using AutoMapper;
using CityInfo.Domain.Models;
using CityInfo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CityInfo.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = nameof(Role.Admin))]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(AdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        [HttpPost("country/{name}")]
        public async Task<IActionResult> AddCountry([FromRoute] string name, IFormFile flag) 
        {
            try
            {
                var image = new Image();
                image.Name = flag.FileName;
                image.ContentType = flag.ContentType;
                image.Body = flag.OpenReadStream();

                await _adminService.AddCountry(name, image);
                return Ok("Country was successfully added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("country/{name}")]
        public async Task<IActionResult> RemoveCountry([FromRoute] string name)
        {
            try
            {
                await _adminService.RemoveCountry(name);
                return Ok("Country was successfully removed");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("city/{name}")]
        public async Task<IActionResult> AddCity([FromRoute] string name, string info)
        {                      
            try
            {
                await _adminService.AddCity(name, info);
                return Ok("City was successfully added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("city/{name}")]
        public async Task<IActionResult> RemoveCity([FromRoute] string name)
        {
            try
            {
                await _adminService.RemoveCity(name);
                return Ok("Country was successfully removed");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}