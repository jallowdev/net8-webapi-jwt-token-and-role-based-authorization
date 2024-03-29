using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace net8_webapi_jwt_token.services;

public class ServiceDi
{
    public static SwaggerGenOptions SwaggerSetup(SwaggerGenOptions option)
    {
        option.SwaggerDoc("v1", new OpenApiInfo() { Title = ".NET8 WEBAPI JWT TOKEN GENERATE AND ROLE BASED AUTHORIZATION", Version = "v1" });
        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[]{}
            }
        });
        return option;
    }
}