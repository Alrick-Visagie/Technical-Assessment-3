using Application.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService
    {
        public async Task<string> Login(LoginModel model)
        {

            if (model.Username != "Admin" && model.Password != "123@QWERTY@123")
            {
                throw new Exception("Invalid credentials");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key"));

            var claims = new List<Claim>();

            var token = new JwtSecurityToken(
                    issuer: "issuer",
                    audience: "audience",
                    expires: DateTime.Now.AddHours(1),
                    claims: claims,
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
