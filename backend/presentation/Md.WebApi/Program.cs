using Md.Persistentce;
using Microsoft.AspNetCore.OData;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var cfg = builder.Configuration;
var env = builder.Environment;

builder.Services.AddControllers()
    .AddOData(options => options.Select().Filter().OrderBy());

builder.Host.UseSerilog((ctx, cfg) =>
    cfg.WriteTo.Console());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Md.Bot.WebApi", Version = "v1" });
});

builder.Services.AddPersistence(cfg);

var app = builder.Build();

app.UseSerilogRequestLogging();

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Synapses.MealDelivery.Client v1"));
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
