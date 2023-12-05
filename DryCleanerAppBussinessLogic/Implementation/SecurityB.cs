using DryCleanerAppBussinessLogic.Interfaces;
using DryCleanerAppDataAccess.Entities;
using DryCleanerAppDataAccess.IRepository;
using DryCleanerAppDataAccess.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanerAppBussinessLogic.Implementation
{

    public class SecurityB : ISecurityB
    {
        ISecurityRepository _securityRepository;
        readonly IConfiguration _configuration;
        public SecurityB(ISecurityRepository securityRepository, IConfiguration configuration)
        {
            _securityRepository = securityRepository;
            _configuration = configuration;
        }
        public string GenerateJWTToken(string userName, int userId)
        {


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSignInKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Issuer","DryCleaner"),
                new Claim("Admin","true"),
                new Claim(JwtRegisteredClaimNames.UniqueName,userName),
                new Claim("UserId",userId.ToString()),
            };
            var token = new JwtSecurityToken("DryCleaner",
                "DryCleaner",
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> SaveRefreshToken(UserProfileModel param)
        {
            string jwtToken = GenerateJWTToken(param.Username, param.Id);
            var refreshToken = new RefreshTokenEntity()
            {
                UserId = param.Id,
                RefreshToken = jwtToken,
                Expires = DateTime.Now.AddHours(24),
                CreatedByID = param.Id.ToString(),
                IsDeleted = false,
                IsActive = true,
                CompanyId = param.CompanyId,

            };
            string result = await _securityRepository.SaveRefreshToken(refreshToken);

            if (result == GeneralDTO.SuccessMessage)
            {
                return jwtToken;
            }
            else
            {
                return GeneralDTO.FailedMessage;
            }

        }

        public string ValidateToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["JWTSignInKey"]);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidAudience = "DryCleaner",
                    ValidIssuer = "DryCleaner",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ClockSkew = TimeSpan.Zero

                }, out SecurityToken validatedToken);

                // Corrected access to the validatedToken
                var jwtToken = (JwtSecurityToken)validatedToken;
                var jku = jwtToken.Claims.First(claim => claim.Type == "UserId").Value;
                var userName = jwtToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.UniqueName).Value;

                return userName;
            }
            catch
            {
                return null;
            }
        }

    

    }
}
