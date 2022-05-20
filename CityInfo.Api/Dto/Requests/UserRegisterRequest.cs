using System;
using System.ComponentModel.DataAnnotations;

namespace CityInfo.Api.Dto.Requests
{
    public class UserRegisterRequest
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
