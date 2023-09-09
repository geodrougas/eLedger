using App.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContext, AppDbContext>(options =>
{
    var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
        ?? "server=localhost; Port=3306; user id=e_ledger_migrations;password=e_ledger_migrations_12345#;database=ledger_migrations; SslMode=Preferred;";
    options.UseMySql(
        connectionString,
        MariaDbServerVersion.AutoDetect(connectionString)
    );
});

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
