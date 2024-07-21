using CleanDesign.Application.ViewModels;
using CleanDesign.Domain.Entities;
using CleanDesign.SharedKernel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanDesign.Infrastructure.AuthHelpers
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AuthSettings _authSettings;

        public AuthHelper(IConfiguration configuration, UserManager<ApplicationUser> userManager, IOptions<AppSettings> appSettingOptions)
        {
            _configuration = configuration;
            _userManager = userManager;
            _authSettings = appSettingOptions.Value.AuthSettings;
        }

        public async Task<TokenViewModel> GenerateAuthTokens(ApplicationUser user)
        {
            var claims = GetUserClaims(user);
            int expiresIn = 2;

            var token = new JwtSecurityToken(

                issuer: _authSettings.Issuer,
                audience: _authSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiresIn),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.SecretKey)),
                SecurityAlgorithms.HmacSha256)
                );
            var bearerToken = new JwtSecurityTokenHandler().WriteToken(token);
            string refreshToken = await _userManager.GenerateUserTokenAsync(user, TokenOptions.DefaultProvider, _authSettings.RefreshTokenName);
            return new()
            {
                RefreshToken = refreshToken,
                BearerToken = bearerToken,
                ExpiresIn = expiresIn
            };
        }

        private static List<Claim> GetUserClaims(ApplicationUser user)
        {
#pragma warning disable CS8604 // Possible null reference argument.

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

#pragma warning restore CS8604 // Possible null reference argument.

            return claims;
        }
    }
}
