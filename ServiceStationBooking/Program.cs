global using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Model;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddDbContext<ServiceContext>();
var app = builder.Build();

app.UseFastEndpoints();


app.Run();
