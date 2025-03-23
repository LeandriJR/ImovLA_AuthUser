using AuthService.Domain.Entities;
using AuthUser.Application.DTO;

namespace Tenant.Infrastructure.Repository;

public class RolesRepository
{
    private readonly AppDbContext _context;

    public RolesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<RoleEntity>> Addasync(List<RoleEntity> roles)
    {
        _context.Roles.AddRangeAsync(roles);
        await _context.SaveChangesAsync();
        return roles;
    }
}