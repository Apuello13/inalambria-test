using Microsoft.AspNetCore.Mvc;
using domino_api.Dto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using domino_api.Models;
using domino_api.Utilities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace domino_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            List<User> users = new UsersLog().getUsers();
            User user = users
                .Find(x => x.Username == loginDto.Username && x.Password == loginDto.Password);
            if (user == null) return BadRequest(MessageError.NOT_FOUND_USER);
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(JwtUtils.Key));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                    issuer: JwtUtils.Issuer,
                    audience: JwtUtils.Audience,
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signinCredentials
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            user.Token = tokenString;
            return Ok(user);
        }
    }
}
