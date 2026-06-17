using Authentication.Configurations;
using Authentication.Data;
using Authentication.Domain.Services;
using Authentication.Repo;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore; // <-- add this

var builder = WebApplication.CreateBuilder(args);

var defaultConnString = builder.Configuration.GetConnectionString("SqlDbConnection");

builder.Services.AddDbContext<HealthCareContext>(options =>
    options.UseSqlServer(defaultConnString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<SecretService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddAutoMapper(typeof(Program));

//Add Controllers
builder.Services.AddControllers();

// OpenAPI generation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi(); // generates OpenAPI spec for Scalar

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("AllowOrigins");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Enable Scalar UI

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "Authentication API";
        options.OpenApiRoutePattern = "/openapi/v1.json"; // default OpenAPI spec route
    });
}

app.Run();
