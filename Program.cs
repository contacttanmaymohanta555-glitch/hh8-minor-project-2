using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/status", async (HttpContext context) =>
{
    using var reader = new StreamReader(context.Request.Body);
    var body = await reader.ReadToEndAsync();
    Console.WriteLine("\n[SERVER] New Security Report Received:");
    Console.WriteLine(body);
    return Results.Ok("Status received");
});

app.Run();