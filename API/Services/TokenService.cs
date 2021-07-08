using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.entities;
using API.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.UserName) //adding our claims
            };

            var creds = new SigningCredentials(_key,SecurityAlgorithms.HmacSha512Signature);  //creating our credentials
            
            var tokenDescriptor = new SecurityTokenDescriptor   //
            {                                                  //
                Subject = new ClaimsIdentity(claims),         //   describing how the tokkens gonna look
                Expires = DateTime.Now.AddDays(7),             //
                SigningCredentials = creds                       //
            };                                                     //
            
                                                                 
            var tokenHandler = new JwtSecurityTokenHandler();    //token handler
                
            var token = tokenHandler.CreateToken(tokenDescriptor);  //creating the token

            return tokenHandler.WriteToken(token);                 //returning the written token to who ever needs it
        }
           
    }
}