using AutoMapper;
using CityInfo.Api.Dto.Requests;
using CityInfo.Domain.Entities;
using CityInfo.Domain.Models;
using CityInfo.Services;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("country")]
        public async Task<IActionResult> AddCountry([FromBody] AddCountryRequest countryInfo) 
        {
            try
            {
                var country = _mapper.Map<Country>(countryInfo);
                await _adminService.AddCountry(country);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        } 
        

    }
}