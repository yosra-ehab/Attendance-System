using Attendance.DTOS;
using Attendance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Attendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<ApplicationUser> userManager , IConfiguration configuration)
        {
            _userManager = userManager;
            this.configuration = configuration;
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
        public async Task<ActionResult> login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return Unauthorized();
            ApplicationUser? user = await _userManager.FindByNameAsync( loginDto.UserName);
            if (user != null)
            {
               if (_userManager.CheckPasswordAsync(user, loginDto.Password).Result)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    var roles = await _userManager.GetRolesAsync(user);
                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                    var token = new JwtSecurityToken(
                        issuer: configuration["Jwt:Issuer"],
                        audience: configuration["Jwt:Audience"],
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(60),
                        signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(
                            new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                                System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"])
                                ),
                            Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256
                            )
                        );
                    var tokenString = new
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo

                    };
                    return Ok(tokenString);

                }
               else
                    {
                   return Unauthorized();
                }

            }
            else
            {
                 ModelState.AddModelError(string.Empty, "Invalid Login Attempt"); 
            }
            return BadRequest(ModelState);



        }
    }
}
