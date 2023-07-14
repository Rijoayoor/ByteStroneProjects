using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Model;

public class SearchDetailsEndpoint : EndpointWithoutRequest<dynamic[]>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Get("/api/details/name/{name}/date/{date}/email/{email}/vehiclemodel/{vehiclemodel}/requirement/{requirement}");
        AllowAnonymous();
    }
    public SearchDetailsEndpoint(ServiceContext context)
    {
        _context = context;
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var name = Route<string>("name");
        var date = Route<string>("date");
        DateOnly convertedDate;
        DateOnly.TryParse(date, out convertedDate);
        var email = Route<string>("email");
        var vehiclemodel = Route<string>("vehiclemodel");
        var requirement = Route<string>("requirement");

        var result = (from booking in _context.Bookings
                      join customer in _context.Customers
                      on booking.CustomerId equals customer.CustomerId
                      where (customer.CustomerName == name
                      && booking.BookingDate == convertedDate &&
                      customer.Email == email && customer.VehicleModel == vehiclemodel &&
                      customer.ServiceRequirements == requirement)
                      select new
                      {
                          booking.BookingId,
                          customer.CustomerId,
                          customer.CustomerName,
                          customer.Email,
                          customer.VehicleModel,
                          booking.BookingDate,
                          customer.ServiceRequirements,
                          customer.ContactNumber,
                          booking.Status  
                      }).ToArray();
        if (result == null)
            await SendNotFoundAsync();
        else
        {
            await SendAsync(result);
            System.Console.WriteLine(result);
        }
    }
}