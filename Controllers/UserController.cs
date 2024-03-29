using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net8_webapi_jwt_token.models.dtos;
using net8_webapi_jwt_token.models.enums;

namespace net8_webapi_jwt_token;
    
[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;
    public UserController(ILogger<UserController> logger,IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [Route("users")]
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(_userService.GetUsers());
    }
    
    [Route("users")]
    [HttpPost]
    public IActionResult AddUsers([FromForm] UserRegistrationRequest request)
    {
        if (!ModelState.IsValid)
            BadRequest("Filds validation error");
        _userService.AddUser(request);
        return Ok();
    }
    

   
}
