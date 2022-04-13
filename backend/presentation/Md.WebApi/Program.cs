using Md.Infrastucture.Meta.Odata;
using Md.Persistentce;
using Md.Persistentce.Data;
using Microsoft.AspNetCore.OData;
using Microsoft.OpenApi.Models;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

ConfigurationManager cfg = builder.Configuration;
IWebHostEnvironment env = builder.Environment;

builder.Services.AddControllers()
    .AddOData(options => {
        options.Select().Filter().OrderBy().Count().Expand().SkipToken();
        options.AddRouteComponents("odata", EdmModelProvider.GetEdmModel(cfg["EdmModelAssemby"]));
    }).AddNewtonsoftJson();

builder.Host.UseSerilog((ctx, cfg) => cfg.WriteTo.Console());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Md.WebApi", Version = "v1" });
});

builder.Services.AddPersistence(cfg);

WebApplication app = builder.Build();

app.UseSerilogRequestLogging();

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Md.WebApi v1"));
}

app.Services.GetService<MdDbContext>()!.Database.EnsureCreatedAsync().Wait();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();