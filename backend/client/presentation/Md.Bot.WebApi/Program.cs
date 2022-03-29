using Md.Bot.Domain.Interfaces;
using Md.Bot.Application.Services;
using Md.Bot.Domain.Commands;
using Serilog;
using Md.Bot.Application.Commands;
using Md.Bot.Persistentce;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var cfg = builder.Configuration;
var env = builder.Environment;

builder.Host.UseSerilog((ctx, cfg) =>
    cfg.WriteTo.Console());

builder.Services.AddPersistence(cfg);

builder.Services.AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<ICommandService, CommandService>();
builder.Services.AddSingleton<IStateService, StateService>();
builder.Services.AddSingleton<TelegramBotService>();
builder.Services.AddSingleton<Command, StartCommand>();
builder.Services.AddSingleton<Command, BackCommand>();
builder.Services.AddSingleton<Command, StartCommand>();
builder.Services.AddSingleton<Command, AvailableOrdersCommand>();
builder.Services.AddSingleton<Command, MyOrdersCommand>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Md.Bot.WebApi", Version = "v1" });
});


var app = builder.Build();

app.UseSerilogRequestLogging();

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Md.Bot.WebApi v1"));
}

app.Services.GetRequiredService<TelegramBotService>().GetBotAsync().Wait();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();