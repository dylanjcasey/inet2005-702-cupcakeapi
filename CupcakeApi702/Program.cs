using CupcakeApi702.Database;
using CupcakeApi702.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

// This is a request to [host]/cupcaks
app.MapGet("/cupcakes", (IConfiguration _configuration) =>
{
    String? connectionString = _configuration.GetConnectionString("DatabaseConnection");

    // Create cupcake list
    List<Cupcake> cupcakes = new List<Cupcake>();

    if(connectionString != null)
    {
        DbContext dbContext = new DbContext(connectionString);
        cupcakes = dbContext.GetCupcakes();
    }

    return cupcakes;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();