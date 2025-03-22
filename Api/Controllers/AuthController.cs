using Microsoft.AspNetCore.Mvc;
using AuthService.Domain.Entities;
using AuthService.Services;
using AuthUser.Application.DTO;
using Tenant.Infrastructure;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;

    public AuthController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUserDTO)
    {

        UserDTO userCreated = await _userService.Registrar(registerUserDTO);

        if (userCreated == null)
        {
            return BadRequest(new {message = "Erro ao registrar usuario"});
        }
        return Ok(new { message = "Usuário registrado com sucesso!" });
    }

}