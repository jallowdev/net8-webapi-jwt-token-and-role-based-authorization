using System.ComponentModel.DataAnnotations;

namespace net8_webapi_jwt_token.models.dtos;

public class AuthRequest
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
}