/*using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebOrdersApi.Data.Entity;
using WebOrdersApi.Service.IRepository;
using WebOrdersApi.Service.LoginService;

namespace WebOrdersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //private readonly IConfiguration _config;
        //private readonly IUnitOfWork _unit;
        private readonly ILoginJWT _token;

        public LoginController(ILoginJWT token)
        {
            //_config = config;
            //_unit = unit;
            _token = token;
        }

        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            try
            {
                var responce = _token.GetToken(login, password);

                return Ok(responce);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       /* private Client AuthenticateUser(string login,string password)
        {
            var user = (Client)_unit.Clients.GetAllAsync().Result.Where(
                u => u.Login == login && u.Password == password);

            return user;
        }

        private string GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                null,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            var user = AuthenticateUser(login,password);
            IActionResult response = Unauthorized(user);

            if (user != null)
            {
                var token = GenerateToken();
                response = Ok(new {token = token});
            }
            return response;
        }
    }
}*/
