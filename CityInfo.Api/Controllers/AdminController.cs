using AutoMapper;
using CityInfo.Api.Dto.Requests;
using CityInfo.Domain.Entities;
using CityInfo.Domain.Models;
using CityInfo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CityInfo.Api.Controllers
{
    [ApiController]
    //[Authorize(Roles = nameof(Role.Admin))]
    [AllowAnonymous]
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
    }
}