using System;
using System.ComponentModel.DataAnnotations;

namespace ServerApp.Dto
{
    public class UserForRegisterDto
    {
        [Required(ErrorMessage = "Name Gereklidir.")]
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
    }
}
