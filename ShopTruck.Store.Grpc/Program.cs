using ShopTruck.Store.Grpc.Services;
using ShopTruck.Store.Application;
using ShopTruck.Store.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddApplicationDI();
builder.Services.AddInfrastructureDI();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<StoreService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
