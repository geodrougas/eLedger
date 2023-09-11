using Auth.Infrastructure;
using Auth.UserAuth.Interfaces.Tools;
using Auth.UserAuth.Models.Entities.Options;
using Auth.UserAuth.Tools;
using Common.Interfaces.Tools;
using Common.Models.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);
   
var secretsFolder = Environment.GetEnvironmentVariable("REFRESH_TOKEN_KEY_FOLDER");
if (secretsFolder != null && File.Exists(secretsFolder + "/secrets.json"))
    builder.Configuration.AddJsonFile(secretsFolder + "/secrets.json");

var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContext, AuthDbContext>(options =>
{
    var connectionString = builder.Configuration["DB_CONNECTION_STRING"];
    options.UseMySql(
        connectionString,
        MariaDbServerVersion.AutoDetect(connectionString)
    );
});

builder.Services.AddScoped<IUserManager, UserManager>();

builder.Services.AddSingleton(new JwtBearerOptions
{
    
});
builder.Services.AddSingleton(JwtTokenOptions.GenerateOptions(configuration));
builder.Services.AddSingleton(RefreshTokenOptions.GenerateOptions(configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
