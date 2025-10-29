using Attendance.DTOS;
using Attendance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Attendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = new ApplicationUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.phoneNumber
            };
            var result = await _userManager.CreateAsync(user ,registerDto.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }
        }
        [HttpPost("login")]
        public ActionResult login(LoginDto loginDto)
        {
            ApplicationUser user =  _userManager.FindByNameAsync( loginDto.UserName).Result;
            if (user != null)
            {
               if (_userManager.CheckPasswordAsync(user, loginDto.Password).Result)
                {
                    return Ok();
                }
               else
                    {
                    ModelState.AddModelError(string.Empty, "Invalid password");
                }

            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok();
        }
    }
}
