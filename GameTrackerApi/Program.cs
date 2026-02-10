using GameTracker.Api.Controllers;
using GameTracker.Application.Abstractions;
using GameTracker.Application.Commands;
using GameTracker.Application.DTOs;
using GameTracker.Application.UseCases.CreateGame;
using GameTracker.Application.UseCases.GetGame;
using GameTracker.Application.UseCases.UpdateGame;
using GameTracker.Domain.ValueObjects;
using GameTracker.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<CreateGameUseCase>();
builder.Services.AddScoped<DeleteGameUseCase>();
builder.Services.AddScoped<UpdateGameUseCase>();
builder.Services.AddScoped<GetGameByIdUseCase>();
builder.Services.AddScoped<GetGameByTitleUseCase>();

builder.Services.AddDbContext<GameTracker.Infrastructure.Persistence.GameContext>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("Frontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
