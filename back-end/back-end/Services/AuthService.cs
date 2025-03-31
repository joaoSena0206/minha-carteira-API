using back_end.Data;
using back_end.DTOs;
using back_end.Models;
using Microsoft.AspNetCore.Identity;

namespace back_end.Services;

public class AuthService
{
    private readonly UserRepository  _userRepository;
    private readonly PasswordHasher<User> _passwordHasher = new();

    public AuthService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task RegisterUser(RegisterUserDto userDto)
    {
        var user = new User
        {
            Username = userDto.Username
        };
        user.Password = _passwordHasher.HashPassword(user, userDto.Password);
        
        await _userRepository.Add(user);
    }
}