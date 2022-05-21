using System.ComponentModel.DataAnnotations;

namespace CityInfo.Api.Dto.Requests
{
    public class AddCountryRequest
    {
        [Required]
        public string Name { get; set; }
        public string Info { get; set; }
        public string Flag { get; set; }
    }
}
