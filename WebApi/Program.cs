using Application.Validators;
using Domain;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(); // Adding Cors - User

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlite("Data Source=db.db");
    options.EnableSensitiveDataLogging();
    options.EnableDetailedErrors();
});

Application
    .DependencyResolver
    .DependencyResolverService
    .RegisterApplicationLayer(builder.Services);
Infrastructure
    .DependencyResolver
    .DependencyResolverService
    .RegisterInfrastructureLayer(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options =>
    {
        options.AllowAnyHeader();
        options.AllowAnyMethod();
        options.AllowAnyOrigin();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();