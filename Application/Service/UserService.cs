using AuthService.Domain.Entities;
using AuthUser.Application.DTO;
using Tenant.Infrastructure;

namespace AuthService.Services;

public class UserService
{
    private readonly AppDbContext _context;
    private readonly PasswordService _passwordService;

    public UserService(AppDbContext context, PasswordService passwordService)
    {
        _context = context;
        _passwordService = passwordService;
    }
    async public Task<UserDTO> Registrar(RegisterUserDTO registerUserDTO)
    {   
        string hashedPassword = _passwordService.HashPassword(registerUserDTO.Password);
        
        Console.WriteLine(hashedPassword);

        return null;
        var user = new UserEntity
        {
            UserName = registerUserDTO.UserName,
            Email = registerUserDTO.Email,
            Password = hashedPassword,
            
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return null;
    }
}