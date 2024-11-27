using Microsoft.EntityFrameworkCore;
using SealCraft.Presentation.Context;
using SealCraft.Presentation.SecretManager;

var builder = WebApplication.CreateBuilder(args);

var awsConfiguration = await AwsSecretsManagerHelper.LoadSecretsAsync(
    "AppSecretKeys",
    "us-east-1"
);
builder.Configuration.AddConfiguration(awsConfiguration);

var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");

builder.Services.AddDbContext<SealCraftDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();