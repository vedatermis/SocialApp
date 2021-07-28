using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Dto;
using ServerApp.Models;
using System.Threading.Tasks;

namespace ServerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto model)
        {
            var user = new User();
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Name = model.Name;
            user.Gender = model.Gender;
            user.Created = System.DateTime.Now;
            user.LastActive = System.DateTime.Now;

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return StatusCode(201);
            }

            return BadRequest(result.Errors);
        }
    }
}
