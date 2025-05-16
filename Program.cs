using Infra.Models;
using Infra.Services.Classes;
using Infra.Services.Interfaces;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<BookServiceOptions>(
    builder.Configuration.GetSection("BookService")
);

builder.Services.AddSingleton<IBookService>(sp =>
{
    var options = sp.GetRequiredService<IOptions<BookServiceOptions>>().Value;
    return new BookService(options.FilePath);
});

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
    var revenue = await bookService.SortByRevenue();
    return Results.Ok(revenue);
})
.WithName("SortByRevenue")
.WithOpenApi();

//get most sold book
app.MapGet("/GetWhere", async Task<IResult> (IBookService bookService, int quantity) =>
{
    var getbyQuantity = await bookService.GetWhere(x => x.CopiesSold <= quantity);
    return Results.Ok(getbyQuantity);
})
.WithName("GetWhere")
.WithOpenApi();

app.Run();

