using Microsoft.EntityFrameworkCore;
using ResturantAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var connectionString = builder.Configuration["ConnectionStrings:Rest"];

builder.Services.AddDbContext<RestContext>(opts =>
    opts.UseSqlServer(connectionString)
);

var ResturantAPI = "_ResturantAPI";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: ResturantAPI,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials();
        });
});

builder.Services.AddMvc().AddControllersAsServices();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors(ResturantAPI);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
