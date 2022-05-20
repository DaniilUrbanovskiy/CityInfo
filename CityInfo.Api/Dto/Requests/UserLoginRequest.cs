using System.ComponentModel.DataAnnotations;

namespace CityInfo.Api.Dto.Requests
{
    public class UserLoginRequest
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
