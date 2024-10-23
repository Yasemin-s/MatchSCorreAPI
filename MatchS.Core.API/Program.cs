using MatchS.Core.API.StartUp;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ServiceConfiguration(builder.Configuration);
var app = builder.Build();
app.AppConfiguration();

