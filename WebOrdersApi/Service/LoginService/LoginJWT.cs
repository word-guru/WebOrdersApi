using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using WebOrdersApi.Data.Entity;
using WebOrdersApi.JwtConfig;
using WebOrdersApi.Service.IRepository;

namespace WebOrdersApi.Service.LoginService
{
    public class LoginJWT : ILoginJWT
    {
        private readonly IUnitOfWork _unit;

        public LoginJWT(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IResult> GetToken(string login, string password)
        {
            // находим пользователя 
            var person = await _unit.Clients.GetByIdAsync(p => p.Login == login && p.Password == password);
            // если пользователь не найден, отправляем статусный код 401
            if (person is null)
                return Results.Unauthorized();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Login) };
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            // формируем ответ
            var response = new
            {
                access_token = encodedJwt,
                login = person.Login
            };

            return Results.Json(response);

        }
    }
}
