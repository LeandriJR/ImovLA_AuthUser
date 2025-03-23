using AuthService.Domain.Entities;
using AuthUser.Application.DTO;

namespace AuthUser.Application.interfaces;

public interface IUserRepository
{
    Task<UserEntity> RegisterUser(UserEntity user);
}