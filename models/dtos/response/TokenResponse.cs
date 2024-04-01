namespace net8_webapi_jwt_token.models.dtos.response;

public class TokenResponse
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public int Expired { get; set; }
}