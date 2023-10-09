global using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddDbContext<ServiceContext>();
builder.Services.AddScoped<Booking>();
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAll",
//           builder =>
//           {
//               builder.AllowAnyOrigin()
//                      .AllowAnyMethod()
//                      .AllowAnyHeader();
//           });
// });
builder.Services.AddCors(options =>

    options.AddPolicy("AllowSpecificOrigin",
    builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod();
    })
    );
var app = builder.Build();
// app.UseRouting();
// app.UseHttpsRedirection();
// app.UseCors("AllowAll");
app.UseCors("AllowSpecificOrigin");
// app.UseAuthorization();
app.UseFastEndpoints();
app.Run();