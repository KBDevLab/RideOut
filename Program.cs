using Microsoft.EntityFrameworkCore;
using RideOut.Application.Interface;
using RideOut.Application.Services;
using RideOut.Infrastructure.Data.Interface;
using RideOut.Infrastructure.Repositories;
using RideOut.Infrastructure.Data.Config;

var builder = WebApplication.CreateBuilder(args);

// Get connection string from configuration
var connectionString = builder.Configuration.GetConnectionString("RideOutDb");

// Inject ILogger to log the connection string
var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();
logger.LogInformation($"Connection String: {connectionString}");

builder.Services.AddDbContext<RideOutDbContext>(options =>
    options.UseNpgsql(connectionString)
           .LogTo(Console.WriteLine, LogLevel.Information));  

// Add services to the container
builder.Services.AddControllers();

// Register application services
builder.Services.AddScoped<IParticipantsService, ParticipantsService>();
builder.Services.AddScoped<IUsersService, UsersService>();

// Register repositories
builder.Services.AddScoped<IParticipantsRepository, ParticipantsRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

// Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure logging during the builder phase
builder.Logging.AddConsole();  

var app = builder.Build();

// Configure the HTTP request pipeline for development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll"); 
app.UseAuthorization();

app.MapControllers();

app.Run();