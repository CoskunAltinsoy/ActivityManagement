using ActivityManagement.Application.Interfaces.UnitOfWorks;
using ActivityManagement.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace ActivityManagement.Application.Security.Jwt
{
    public class TokenGenerator:ITokenHelper
    {
        private readonly IConfiguration _configuration;
       // private readonly IUnitOfWork _unitOfWork;
        public TokenGenerator(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            //_unitOfWork = unitOfWork;
        }

        public Token CreateToken(User user)
        {
            //var userEmail = _unitOfWork.Users.GetByEmail(user.Email);
            var exp = DateTime.Now.AddMinutes(30);
            var token = new Token() {Expiration = exp};
            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
               issuer: _configuration["Jwt:Issuer"],
               audience: _configuration["Jwt:Audience"],
               expires: exp, notBefore: DateTime.Now,
               signingCredentials: credentials,
               claims: authClaims
           );
            var tokenHandler = new JwtSecurityTokenHandler();

            var accessToken = tokenHandler.WriteToken(securityToken);

            token.AccessToken = accessToken;
            token.RefreshToken = Guid.NewGuid().ToString();
            return token;
        }
    }
}
