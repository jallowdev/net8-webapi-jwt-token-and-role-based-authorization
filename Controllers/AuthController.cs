using Microsoft.AspNetCore.Mvc;
using net8_webapi_jwt_token.models.dtos;
using net8_webapi_jwt_token.models.enums;
using net8_webapi_jwt_token.services;

namespace net8_webapi_jwt_token;

[ApiController]
[Route("api/[controller]")]
public class AuthController:ControllerBase
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IUserService userService,ITokenService tokenService, ILogger<AuthController> logger)
    {
        _userService = userService;
        _tokenService = tokenService;
        _logger = logger;
    }

    [Route("login")]
    [HttpPost]
    public IActionResult Login([FromBody] AuthRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest("Invalid client request");
        }
        var user = _userService.Authenticate(request.UserName, request.Password);
        return Ok(_tokenService.GenerateAccessToken(user));
    }
}