using Data;
using gRPCService;
using gRPCService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

var conStr = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<Data.SQLServer.RestaurantReadOnlyContext>(options =>options.UseSqlServer(conStr));
builder.Services.AddDbContext<Data.SQLServer.RestaurantContext>(options => options.UseSqlServer(conStr));

builder.Services.AddSingleton<App>();
builder.Services.AddSingleton<CollectionMapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<AppService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
