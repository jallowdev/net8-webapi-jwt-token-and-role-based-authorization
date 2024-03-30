using System.ComponentModel.DataAnnotations;
using net8_webapi_jwt_token.models.enums;

namespace net8_webapi_jwt_token.models.dtos;

public class UserRegistrationRequest
{
    //[Required]
    public string? Email { get; set; }
    
    //[Required]
    public string? Username { get; set; }
    
    //[Required]
    public string? Password { get; set; }
    
    public string? Role { get; set; }
}