using Microsoft.AspNetCore.Identity;
using net8_webapi_jwt_token.models.enums;

namespace net8_webapi_jwt_token.models;

public class UserApplication:IdentityUser
{
    public Role Role { get; set; }
}