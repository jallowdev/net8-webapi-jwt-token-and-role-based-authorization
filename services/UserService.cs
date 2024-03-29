using net8_webapi_jwt_token.models.dtos;
using net8_webapi_jwt_token.models.entities;

namespace net8_webapi_jwt_token.models.enums;

public interface IUserService
{
    public List<User> GetUsers();
    public void AddUser(UserRegistrationRequest request);
}

public class UserService:IUserService
{
    private static List<User> _users=new List<User>();

    public List<User> GetUsers()
    {
        return _users.ToList();
    }
    
    public void AddUser(UserRegistrationRequest request)
    {
        User user = new User()
        {
            UserName = request.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Email = request.Email,
        };
        _users.Add(user);
    }
}