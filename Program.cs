using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SolidPrincipalWithDecoratorPatternAndDbContext.Decorator;
using SolidPrincipalWithDecoratorPatternAndDbContext.Factory;
using SolidPrincipalWithDecoratorPatternAndDbContext.Provider;
using SolidPrincipalWithDecoratorPatternAndDbContext.Repository;
using SolidPrincipalWithDecoratorPatternAndDbContext.Service;
using SolidPrincipalWithDecoratorPatternAndDbContext.Strategy;
using SolidPrincipalWithGenericDbContext.DbContext;
using SolidPrincipalWithGenericDbContext.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDBContext, NoSqlDbContext>(); // Register NoSQL DB Context
/*builder.Services.AddScoped<IDBContext, SqlDbContext>();   */// Register SQL DB Context
builder.Services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>)); // Default SQL Repository
builder.Services.AddScoped(typeof(NoSqlRepository<>)); // Direct NoSQL Repository
builder.Services.AddScoped<RepositoryFactory>(); // Repository Factory
builder.Services.AddScoped<ITenantConfigurationProvider, TenantConfigurationProvider>();
builder.Services.AddScoped<IDBContext>(provider =>
{
    var useSql = builder.Configuration.GetValue<bool>("UseSqlDatabase");

    if (useSql)
    {
        var dbContext = provider.GetRequiredService<DbContext>();
        return new SqlDbContext(dbContext);
    }
    else
    {
        var mongoDatabase = provider.GetRequiredService<IMongoDatabase>();
        return new NoSqlDbContext(mongoDatabase);
    }
});

// Added strategy 
builder.Services.AddScoped<CreditCardPaymentStrategy>();
builder.Services.AddScoped<PayPalPaymentStrategy>();
builder.Services.AddScoped<UPIStrategy>();
builder.Services.AddScoped<IPaymentStrategyFactory, PaymentStrategyFactory>();
builder.Services.AddScoped<PaymentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
