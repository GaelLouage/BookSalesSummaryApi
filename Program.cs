using Infra.Services.Classes;
using Infra.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IBookService>(new BookService("books"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// get summary
app.MapGet("/GetSalesSummaryAsync",async Task<IResult> (IBookService bookService) =>
{
    return Results.Ok(await bookService.GetSalesSummaryAsync());
})
.WithName("GetSalesSummaryAsync")
.WithOpenApi();
//get most sold book
app.MapGet("/GetTopSellingBook", async Task<IResult> (IBookService bookService) =>
{
    return Results.Ok(await bookService.GetTopSellingBook());
})
.WithName("GetTopSellingBook")
.WithOpenApi();


//get most sold book
app.MapGet("/SortByRevenue", async Task<IResult> (IBookService bookService) =>
{
    return Results.Ok(await bookService.SortByRevenue());
})
.WithName("SortByRevenue")
.WithOpenApi();
app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
