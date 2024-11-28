using demo.back.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using static demo.back.Domain.Interfaces.UserInterfaces;
using System.Security.Claims;
using System.Text;
using demo.back.Application.Utils;
using demo.back.API.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace demo.back.Application.Services
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IUserRepository _userRepository;

        public AuthService(IConfiguration configuration, IPasswordHasher<User> passwordHasher, IUserRepository userRepository)
        {
            _configuration = configuration;
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        public async Task<ApiResponse<AuthUserDTO?>> AuthenticateAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user == null)
                return new ApiResponse<AuthUserDTO?>(null, EResponseCodes.Unauthorized, "Usuario no registrado");

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);

            if (result != PasswordVerificationResult.Success)
                return new ApiResponse<AuthUserDTO?>(null, EResponseCodes.Unauthorized, "Clave de seguridad incorrecta");

            string token = this.GenerateJwtToken(user);

            return new ApiResponse<AuthUserDTO?>(new AuthUserDTO(user, token), EResponseCodes.Success);
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
