global using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Model;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddDbContext<ServiceContext>();


builder.Services.AddCors(options =>

{

    options.AddPolicy("AllowAll",

          builder =>

          {

              builder.AllowAnyOrigin()

                     .AllowAnyMethod()

                     .AllowAnyHeader();

          });

});
var app = builder.Build();
app.UseRouting();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.UseFastEndpoints();

app.Run();


