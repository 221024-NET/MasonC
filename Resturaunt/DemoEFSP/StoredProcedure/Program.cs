using Microsoft.EntityFrameworkCore;
using ResturantAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
builder.Services.AddScoped(provider => provider.GetService<DBContext>());
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.

var connectionString = builder.Configuration["ConnectionStrings:db"];

builder.Services.AddDbContext<DBContext>(opts =>
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
