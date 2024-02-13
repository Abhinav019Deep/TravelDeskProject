using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TravelDeskProject.IRepo;
using TravelDeskProject.Models;
using TravelDeskProject.ViewModel;

namespace TravelDeskProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        ILoginRepo _loginRepo;
        IConfiguration _config;

        public LoginController(ILoginRepo loginRepo,IConfiguration config)
        {
            _loginRepo = loginRepo;
            _config = config;
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel loginuser)
        {
            IActionResult response = Unauthorized();
            if (_loginRepo.Login(loginuser))
            {
                var tokenString = GenerateJSONWebToken(loginuser);
                return Ok(new { token = tokenString });
            }
            return BadRequest();
        }

        private string GenerateJSONWebToken(LoginViewModel loginuser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
