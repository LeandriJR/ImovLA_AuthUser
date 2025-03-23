using AuthService.Domain.Entities;
using AuthUser.Application.DTO;
using AuthUser.Application.interfaces;
using Tenant.Infrastructure;
using Tenant.Infrastructure.Repository;

namespace AuthService.Services;

public class UserService
{
    private readonly AppDbContext _context;
    private readonly PasswordService _passwordService;
    private readonly IUserRepository _userRepository;

    public UserService(AppDbContext context, PasswordService passwordService, IUserRepository userRepository)
    {
        _context = context;
        _passwordService = passwordService;
        _userRepository = userRepository;
    }
    async public Task<UserDTO> Registrar(RegisterUserDTO registerUserDTO)
    {   
        string hashedPassword = _passwordService.HashPassword(registerUserDTO.Password);
        
        var user = new UserEntity
        {
            Id = Guid.NewGuid(),
            UserName = registerUserDTO.UserName,
            Email = registerUserDTO.Email,
            Password = hashedPassword
        };

        var newUser = await _userRepository.RegisterUser(user);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return null;
    }
}