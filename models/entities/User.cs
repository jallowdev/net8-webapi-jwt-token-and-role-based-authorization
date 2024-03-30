using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using net8_webapi_jwt_token.models.enums;

namespace net8_webapi_jwt_token.models.entities;

public class User
{

    public Guid Id { get; set; } = Guid.NewGuid();
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    
    public Role? Role { get; set; }
}