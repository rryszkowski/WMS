using System.Reflection;
using WMS.Api.Modules;
using WMS.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddWriteDatabase();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.Load("WMS.Application")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Write: PostgresSQL + EF Core
// Read: MySQL + Dapper
// Sychnronization: RabbitMQ + MassTransit. Occurs eventual consistency problem.
// One handler handling multiple events, like ProductHandler having implemented multiple handler interfaces like ICommand<AddProduct>, ICommand<RateProduct> etc.
app.UseCustomerModule();

app.Run();
