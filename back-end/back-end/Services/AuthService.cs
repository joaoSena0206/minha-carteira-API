using System.Security.Claims;
using System.Text;
using back_end.Configurations;
using back_end.Data;
using back_end.DTOs;
using back_end.Exceptions;
using back_end.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace back_end.Services;

public class AuthService
{
    private readonly UserRepository  _userRepository;
    private readonly PasswordHasher<User> _passwordHasher = new();
    private readonly JwtSettings _jwtSettings;

    public AuthService(UserRepository userRepository, IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
        _userRepository = userRepository;
    }

    public async Task RegisterUser(RegisterUserDto userDto)
    {
        bool isUserTaken = await _userRepository.UserExists(userDto.Username);

        if (isUserTaken)
        {
            throw new UserAlreadyExistsException(userDto.Username);
        }
        
        var user = new User
        {
            Username = userDto.Username
        };
        user.Password = _passwordHasher.HashPassword(user, userDto.Password);
        
        await _userRepository.Add(user);
    }

    public async Task<string> LoginUser(LoginUserDto userDto)
    {
        User? user = await _userRepository.GetUser(userDto.Username);

        if (user == null)
        {
            throw new InvalidUserException();
        }
        
        var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, userDto.Password);

        if (passwordVerificationResult == PasswordVerificationResult.Failed)
        {
            throw new InvalidUserException();
        }

        return GenerateToken(userDto.Username);
    }
    
    private string GenerateToken(string username)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("sub", username),
            new Claim("jti", Guid.NewGuid().ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = credentials,
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience
        };

        var tokenHandler = new JsonWebTokenHandler();
        
        return tokenHandler.CreateToken(tokenDescriptor);
    }
}