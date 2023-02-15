using Elabor8.Bradl.CommandHandler;
using Elabor8.Bradl.Query;
using Elabor8.Bradl.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IFactRepository, FactRepository>();

var asm = Assembly.GetAssembly(typeof(FactCreateCommandHandler));

builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(asm));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
