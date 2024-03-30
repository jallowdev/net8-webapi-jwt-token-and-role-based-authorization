using Microsoft.AspNetCore.Identity;
using net8_webapi_jwt_token.models.dtos;
using net8_webapi_jwt_token.models.entities;

namespace net8_webapi_jwt_token.models.enums;

public interface IUserService
{
    public List<User> GetUsers();
    public User AddUser(UserRegistrationRequest request);
}

public class UserService:IUserService
{
    private static List<User> _users = new List<User>()
    {
        new User()
        {
            Id = Guid.NewGuid(),
            UserName = "admin@test.com",
            Password = "$2a$12$1FSpCHvnkLjd0dA7kZSmp.l45R6tCsVMYP5sURjQcpQ9RMPrOO86e", //Passer@123
            Email = "admin@test.com",
            Role = Role.Admin,
        }
    };

    public List<User> GetUsers()
    {
        return _users.ToList();
    }
    
    public User AddUser(UserRegistrationRequest request)
    {
        User user = new User()
        {
            UserName = request.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Email = request.Email,
            Role = Enum.Parse<Role>(request.Role!, true),
        };
        _users.Add(user);
        return FindByUserName(request.Username!);
    }

    public User FindByUserName(string userName)
    {
        //var user = await _users.FirstOrDefaultAsync(u => u.Username == loginModel.Username);
        return _users.SingleOrDefault(x => x.UserName == userName);
    }
}