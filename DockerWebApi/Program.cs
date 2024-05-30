using Microsoft.AspNetCore.Identity;

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


app.MapGet("/readLogs", (HttpContext httpContext) =>
{
    string filePath = "logs/logs.txt";
    if (!File.Exists(filePath))
    {
        httpContext.Response.WriteAsync("Logs file dos not exist!");
        httpContext.Response.StatusCode = 404;
        return null; 
    }
    var logs= File.ReadAllText(filePath);
    return logs;

});
app.MapGet("/echo", (string message) =>
{
    Console.WriteLine(message);
    string filePath = "logs/logs.txt";
    if(!File.Exists(filePath))
    {
        Directory.CreateDirectory("logs");
       using StreamWriter writer = File.CreateText(filePath);
        writer.WriteLine(message);

    }
    else
    {
        using StreamWriter writer = File.AppendText(filePath);
        writer.WriteLine(message);
    }
    return message;
})
.WithName("Echo")
.WithOpenApi();

app.Run();

