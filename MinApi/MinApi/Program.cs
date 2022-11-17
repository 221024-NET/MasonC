
using MinApi;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connValue = builder.Configuration.GetValue<string>("ConnectionString:NorthwindDB");
builder.Services.AddTransient<CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/customers", (CustomerRepository repo) =>
    repo.GetAll(connValue));

app.MapGet("/customers/{id}", (int id, CustomerRepository repo) =>
    repo.Get(connValue, id));

app.MapPost("/customers", (Customer customer, CustomerRepository repo) =>
{
    customer = repo.Create(connValue, customer);
    return Results.Created($"/customers/{customer.CustomerId}", customer);
});

app.MapPut("/customers/{id}", (int id, Customer customer, CustomerRepository repo) =>
{
    repo.Update(connValue, id, customer);
    return Results.NoContent();
});

app.MapDelete("/customers/{id}", (int id, CustomerRepository repo) =>
{
    repo.Delete(connValue, id);
    return Results.Ok(id);
});

app.Run();
