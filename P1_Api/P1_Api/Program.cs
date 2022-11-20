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

//GetAllUsers -- Implement but don't get passwords
app.MapGet("/Users", (SqlRepository repo) =>
    repo.GetAllUsers(connValue));

//GetUser - Don't implement
app.MapGet("/Users/{id}", (int id, SqlRepository repo) =>
    repo.GetUser(connValue, id));

//Login -- Done
app.MapPost("/Login", (User user, SqlRepository repo) =>
{
    user = repo.Login(connValue, user.Email, user.Password);
    return Results.Created($"/Users/{user.id}", user);
});

//Register -- Done
app.MapPost("/Register", (User user, SqlRepository repo) =>
{
    user = repo.Register(connValue, user.Email, user.Password);
    return Results.Created($"/Users/{user.id}", user);
});

// create ticket
app.MapPost("/tickets", (Ticket t, SqlRepository repo) =>
{
    Ticket tick = repo.NewTicket(connValue, t.status, t.amount, t.description, t.userId);
    return Results.Created($"/tickets/{tick.ticketId}", tick);
});

//AcceptTicket
app.MapPut("ticket/Accpet/{id}", (int id, SqlRepository repo) =>
{
    repo.AccpetTicket(connValue, id);
    return Results.NoContent();
});

//Decline Ticket
app.MapPut("ticket/Decline/{id}", (int id, SqlRepository repo) =>
{
    repo.DeclineTicket(connValue, id);
    return Results.NoContent();
});

//IncPermLevel
app.MapPut("/PermissionM/{id}", (int id, SqlRepository repo) =>
{
    repo.ChangeUserPermM(connValue, id);
    return Results.NoContent();
});

app.MapPut("/PermissionU/{id}", (int id, SqlRepository repo) =>
{
    repo.ChangeUserPermU(connValue, id);
    return Results.NoContent();
});


//End apis here



app.Run();

