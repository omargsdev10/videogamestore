using System.IO;
using API.Repository.Interfaces;
using API.Repository.Repository;
using API.Service.Interfaces;
using API.Service.Service;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Dependencies
builder.Services.AddScoped<IVideoGameService, VideoGameService>();
builder.Services.AddScoped<IVideoGameRepository, VideoGameRepository>();
builder.Services.AddScoped<IConsoleService, ConsoleService>();
builder.Services.AddScoped<IConsoleRepository, ConsoleRepository>();
builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();

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
