
using TicketingApp.Data;

var configuration = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>(true)
    .Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connValue = builder.Configuration.GetValue<string>("ConnectionString:DB");
builder.Services.AddTransient<SqlRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// GetUser - GetAllUsers - Login - Register - GetAllTicketsFromUser - GetAllTicketsPending - GetAllTickets

app.MapGet("/customers", (SqlRepository repo) =>
    repo.GetAllUsers().ToString());

app.MapGet("/customers/{id}", (string e, SqlRepository repo) =>
    repo.GetUser(e));




app.Run();
