using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using Merchandise.Services;
using Merchandise.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>
(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql")), 
    contextLifetime: ServiceLifetime.Scoped
);

builder.Services.AddScoped<MapService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<OrderedProductService>();

var app = builder.Build();

using (var serviceScope = ((IApplicationBuilder)app).ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope())
{
    serviceScope?.ServiceProvider.GetRequiredService<DataContext>().Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseErrorMiddleware();

app.MapControllers();

app.Run();
