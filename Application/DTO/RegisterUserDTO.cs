﻿namespace AuthUser.Application.DTO;

public class RegisterUserDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    
    public List<Guid>? Roles { get; set; }
}