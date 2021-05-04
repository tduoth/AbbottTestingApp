using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ProjectEstimator.Api.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UsersController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [Authorize]
        [HttpGet("current")]
        public async Task<IActionResult> GetSingleCurrent()
        {
            var user = await _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            
            return Ok(new UserDetailsDto { Email = user.Email });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (result.Succeeded)
                {
                    // User credentials were verified so generate JWT token.
                    var tokenHandler = new JwtSecurityTokenHandler();
                    
                    // Put the user's claims together
                    var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, user.Id) };
                    var userRoles = await _userManager.GetRolesAsync(user);
                    claims.AddRange(userRoles.Select(r => new Claim(ClaimTypes.Role, r)));

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        SigningCredentials = new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"])),
                            SecurityAlgorithms.HmacSha256Signature
                        ),
                        Issuer = _configuration["Jwt:Issuer"],
                        Subject = new ClaimsIdentity(claims)
                    };

                    return Ok(new TokenDto
                    {
                        Token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor))
                    });
                }
            }

            return BadRequest(new {error = "Invalid login attempt."});
        }
    }
}