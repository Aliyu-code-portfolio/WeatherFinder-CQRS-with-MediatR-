using FluentValidation.AspNetCore;
using MediatR;
using WeatherFinder.Shared.DTOs.Request;
using WeatherFinder.Shared.Validators;
using WeatherFinder.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureRepositories();
builder.Services.AddMediatR(typeof(WeatherFinder.Application.AssemblyReference).Assembly);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddFluentValidation(validate =>
{
    validate.RegisterValidatorsFromAssemblyContaining<UserRequestValidator>();
    validate.RegisterValidatorsFromAssemblyContaining<ActivityRequestValidator>();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
