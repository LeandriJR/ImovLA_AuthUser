using AuthUser.Application.DTO;

namespace AuthUser.Application.interfaces;

public interface IRolesRepository
{
    Task<RolesDTO> InsertRole();
}