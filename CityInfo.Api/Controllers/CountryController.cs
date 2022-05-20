using CityInfo.DataAccess;
using CityInfo.Domain.Entities;
using CityInfo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;
        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("select/{country}")]
        public IActionResult Select([FromRoute]string country) 
        {
            var cityList = _countryService.GetCities(country);

            return Ok(cityList);
        }


    }
}