using Microsoft.AspNetCore.Identity;
using net8_webapi_jwt_token.models.dtos;
using net8_webapi_jwt_token.models.entities;

namespace net8_webapi_jwt_token.models.enums;

public interface IUserService
{
    public List<User> GetUsers();
    public User AddUser(UserRegistrationRequest request);
    public User Authenticate(string username, string password);
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
        return _users.SingleOrDefault(x => x.UserName == userName);
    }
    public User Authenticate(string username, string password)
    {
        var user = _users.SingleOrDefault(x => x.UserName == username);
        if (user is null ||  !BCrypt.Net.BCrypt.Verify(password, user.Password))
            throw new Exception("User is not Authorize ");
        return user;
    }
}