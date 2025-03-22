using AuthUser.Application.DTO;

namespace AuthUser.Application.interfaces;

public interface IUserRepository
{
    Task<UserDTO> GetAllUsers();
}