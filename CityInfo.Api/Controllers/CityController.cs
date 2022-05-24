using AutoMapper;
using CityInfo.Api.Dto.Responses;
using CityInfo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityInfo.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;
        private readonly IMapper _mapper;

        public CityController(CityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet("select/{country}")]
        public async Task<IActionResult> Select([FromRoute] string country)
        {
            var result = await _cityService.GetCities(country);

            var cities = _mapper.Map<List<CityResponse>>(result);

            return Ok(cities);
        }
    }
}