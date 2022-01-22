using Md.Persistentce;

var builder = WebApplication.CreateBuilder(args);

var cfg = builder.Configuration;
var env = builder.Environment;

builder.Services.AddPersistence(cfg);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
