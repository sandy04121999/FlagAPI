using Flag.Core.Interfaces;
using Flag.Core.Services;
using Flags.Infrastructure.Stores;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<InMemoryDbFeatureStore>();
builder.Services.AddSingleton<IFeatureStore, RedisFeatureStore>();
builder.Services.AddSingleton<FeatureEvaluator>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();

