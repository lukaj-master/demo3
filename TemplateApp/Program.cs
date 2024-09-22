using System.Net;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks();
var app = builder.Build();

app.MapHealthChecks("/healthz");
app.MapGet("/", () => "Hello from " + Dns.GetHostName() + "!");

app.Run();
