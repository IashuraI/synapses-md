using Md.Infrastucture.Meta.Services;
using Md.Persistentce;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var cfg = builder.Configuration;
var env = builder.Environment;

builder.Services.AddControllers()
    .AddOData(options => {
        options.Select().Filter().OrderBy();
        options.AddRouteComponents("odata", EdmModelProvider.GetEdmModel(cfg["EdmModelAssemby"]));
    });

builder.Host.UseSerilog((ctx, cfg) => cfg.WriteTo.Console());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Md.WebApi", Version = "v1" });
});

builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
builder.Services.AddSingleton<ResourceService>();

builder.Services.AddPersistence(cfg);

WebApplication app = builder.Build();

app.UseSerilogRequestLogging();

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Md.WebApi v1"));
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();