using System;
using System.ComponentModel.DataAnnotations;

namespace CityInfo.Api.Dto.Requests
{
    public class UserRegisterRequest
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
    }
}
