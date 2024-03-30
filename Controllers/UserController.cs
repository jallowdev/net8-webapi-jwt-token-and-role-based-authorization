using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net8_webapi_jwt_token.models.dtos;
using net8_webapi_jwt_token.models.entities;
using net8_webapi_jwt_token.models.enums;

namespace net8_webapi_jwt_token;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [Route("users")]
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(ConverterUtils.ConvertUsersToUserResponses(_userService.GetUsers()));
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] UserRegistrationRequest user)
    {
        if (!ModelState.IsValid)
            BadRequest("Filds validation error");
        return Ok(ConverterUtils.ConvertUserToUserResponse( _userService.AddUser(user)));
    }
    
}