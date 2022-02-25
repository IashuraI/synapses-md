using Md.Domain.Entities.Identity;
using Md.Domain.Entities.Order;
using Md.Domain.Entities.Product;
using Md.Infrastucture.Meta.Services;
using Md.Persistentce;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var cfg = builder.Configuration;
var env = builder.Environment;

builder.Services.AddControllers()
    .AddOData(options => {
        options.Select().Filter().OrderBy();
        options.AddRouteComponents("odata", GetEdmModel());
    });

builder.Host.UseSerilog((ctx, cfg) =>
    cfg.WriteTo.Console());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Md.Bot.WebApi", Version = "v1" });
});

builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
builder.Services.AddSingleton<ResourceService>();

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

IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

    builder.EntitySet<Product>(nameof(Product));
    builder.EntitySet<Order>(nameof(Order));
    builder.EntitySet<Role>(nameof(Role));
    builder.EntitySet<User>(nameof(User));
    builder.EntitySet<Category>(nameof(Category));

    return builder.GetEdmModel();
}
