using Microsoft.AspNetCore.Identity;
using TicketingApp.Data;
using TicketingApp.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connValue = builder.Configuration.GetValue<string>("ConnectionStrings:Azure");
builder.Services.AddTransient<SqlRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Start apis here




//GetAllTickets
app.MapGet("/tickets", (SqlRepository repo) =>
    repo.GetAllTickets(connValue));

//GetAllTicketsPending
app.MapGet("/tickets/Pending", (SqlRepository repo) =>
    repo.GetAllTicketsPending(connValue));

//GetAllTicketsFromUser
app.MapGet("/tickets/{id}", (int id, SqlRepository repo) => 
    repo.GetAllTicketsFromUser(connValue, id));

//GetAllUsers
app.MapGet("/Users", (SqlRepository repo) =>
    repo.GetAllUsers(connValue));

//GetUser
app.MapGet("/Users/{id}", (int id, SqlRepository repo) =>
    repo.GetUser(connValue, id));

//Login
app.MapPost("/Users/Login", (User user, SqlRepository repo) =>
{
    user = repo.Login(connValue, user.Email, user.Password);
    return Results.Created($"/Users/{user.id}", user);
});


//Register
app.MapPost("/Users/Register", (User user, SqlRepository repo) =>
{
    user = repo.Register(connValue, user.Email, user.Password);
    return Results.Created($"/Users/{user.id}", user);
});


//End apis here



app.Run();

