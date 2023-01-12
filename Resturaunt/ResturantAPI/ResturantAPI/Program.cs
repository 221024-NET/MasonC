using Microsoft.EntityFrameworkCore;
using ResturantAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["ConnectionStrings:db"];

builder.Services.AddScoped(provider => provider.GetService<RestContext>());

builder.Services.AddDbContext<RestContext>(opts =>
    opts.UseSqlServer(connectionString)
);

builder.Services.AddMvc().AddControllersAsServices();
builder.Services.AddControllers();

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
