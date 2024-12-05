using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rideout.Application.Interface;
using Rideout.Application.Services;
using Rideout.Infrastructure.Data;
using Rideout.Infrastructure.Data.Interface;
using Rideout.Infrastructure.Data.Config;
using Rideout.Infrastructure.Repositories;
using Rideout.Infrastructure.Data.Repositories;


public class Program
{
    public static void Main(string[] args)
    {
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
        builder.Services.AddScoped<IRideoutService, RideoutService>();

        // Register repositories
        builder.Services.AddScoped<IParticipantsRepository, ParticipantsRepository>();
        builder.Services.AddScoped<IUsersRepository, UsersRepository>();
        builder.Services.AddScoped<IRideoutRepository, RideoutRepository>();

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
    }
}