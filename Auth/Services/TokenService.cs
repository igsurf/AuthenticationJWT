using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Auth;
using Auth.Models;
using Microsoft.IdentityModel.Tokens;

namespace Auth.Services
{
    public static class TokenService
    {
        public static Token GenerateToken(User user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenDirty = tokenHandler.CreateToken(tokenDescriptor);
            
            var token = new Token();

            token.TokenNumber = tokenHandler.WriteToken(tokenDirty);
            token.ExpiratioNTime = tokenDescriptor.Expires.ToString();

            return token;
        }
    }
}