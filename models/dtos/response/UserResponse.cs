﻿using net8_webapi_jwt_token.models.enums;

namespace net8_webapi_jwt_token.models.dtos.response;

public class UserResponse
{
    public string? Email { get; set; }
    public string? Username { get; set; }
    public Role? Role { get; set; }
}