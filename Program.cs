using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using net8_webapi_jwt_token.models.enums;
using net8_webapi_jwt_token.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => ServiceDi.SwaggerSetup(options));
// Add stup services for auth .
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => ServiceDi.JwtBearerOptionsSetup(options,builder.Configuration["JWT:SecretKey"]!));
builder.Services.AddAuthorization();

// DI services .
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
