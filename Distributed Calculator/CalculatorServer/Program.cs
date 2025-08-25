using CalculatorServer.Services;
using CalculatorServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

var app = builder.Build();


app.MapGrpcService<CalculatorService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

app.Run();
