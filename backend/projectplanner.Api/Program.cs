using Microsoft.EntityFrameworkCore;

//Creates application builder, configures services and dependencies
var builder = WebApplication.CreateBuilder(args);

//creates a connection to the database
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Allows minimal APIs to be discovered by Swagger/OpenAPI.
builder.Services.AddEndpointsApiExplorer();
//Generates a "Swagger" UI, allows viewing/testing endpoints in the browser
builder.Services.AddSwaggerGen();

//Builds the application with all the configured services
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //Generates the OpenAPI JSON for your endpoints.
    app.UseSwagger();
    //Serves the Swagger HTML interface at "/swagger"
    app.UseSwaggerUI();
}

//Redirects HTTP requests to HTTPS if someone hits your API insecurely
app.UseHttpsRedirection();

//TEST DATA FOR EXAMPLE WEATHER FORECAST
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

//Registers a HTTP GET endpoint at "/weatherforecast"
app.MapGet("/weatherforecast", () =>
    {
        var forecast =  Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();
        return forecast;
    }).WithName("GetWeatherForecast").WithOpenApi();

//Starts the application, begins listening for HTTP requests
app.Run();


record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
