using net8_webapi_jwt_token.models.dtos.response;
using net8_webapi_jwt_token.models.entities;
using net8_webapi_jwt_token.models.enums;

public class ConverterUtils
{
    public static UserResponse ConvertUserToUserResponse(User user)
    {
        return new UserResponse()
        {   Id=user.Id.ToString(),
            Username = user.UserName,
            Role = user.Role.ToString() ,
            Email = user.Email,
        };
    }
    
    public static List<UserResponse> ConvertUsersToUserResponses(List<User> users)
    {
        List<UserResponse> list = new List<UserResponse>();
        users.ForEach(u =>
        {
            list.Add(ConvertUserToUserResponse(u));
        });
        return list;
    }
}