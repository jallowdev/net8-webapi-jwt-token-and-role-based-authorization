namespace net8_webapi_jwt_token.models.dtos;

public class AuthRequest
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}