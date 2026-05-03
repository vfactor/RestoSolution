using gRPCService.Services;
using Microsoft.EntityFrameworkCore;
using gRPCService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

var conStr = builder.Configuration.GetConnectionString("ConnectionString") ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<Data.Models.SQLServer.RestaurantReadOnlyContext>(options =>options.UseSqlServer(conStr));
builder.Services.AddDbContext<Data.Models.SQLServer.RestaurantContext>(options =>options.UseSqlServer(conStr));

builder.Services.AddSingleton<App>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
