using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookClub.Domain;
using BookClub.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace BookClub.Application.Services
{
    public class JwtService : IJwtService
    {
        public string GenerateToken(User user)
        {
            if (user == null)
                throw new NullReferenceException($"That {nameof(user)} is null");
            
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthOptions.SecretKey));
            var credentails = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.Email, user.Email),
                new (JwtRegisteredClaimNames.Sub, user.Id)
            };
            
            var token = new JwtSecurityToken(AuthOptions.Issuer,
                AuthOptions.Audience,
                claims, 
                expires: DateTime.Now.AddMinutes(AuthOptions.TokenLifetimeInMinutes),
                signingCredentials: credentails);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}