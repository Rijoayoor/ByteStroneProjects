using Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/customers", () =>
{
    var dbcontext = new ServiceContext();
    
    return Results.Ok(dbcontext.Customers);
}
);
app.MapPost("/customers" , ()=>
{
    Service service=new ();
    
}

);


app.Run();
