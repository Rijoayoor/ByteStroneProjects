using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Model;

public class GetBookingEndpoint : EndpointWithoutRequest<dynamic[]>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Get("/api/executive/{id}");
        AllowAnonymous();
    }
    public GetBookingEndpoint(ServiceContext context)
    {
        _context = context;
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        

         var result = (from booking in _context.Bookings
                      join customer in _context.Customers
                      on booking.CustomerId equals customer.CustomerId
                      where booking.ExecutiveId == id
                        && 
                        (booking.Status == "new"
                        || booking.Status == "In progress"
                        || booking.Status == "completed"
                        || booking.Status == "Cancelled"
                        )
                      select new
                      {
                          booking.BookingId,
                          booking.BookingDate,
                          booking.CustomerId,
                          customer.ContactNumber,
                          customer.ServiceRequirements,
                          customer.CustomerName,
                          booking.Status
                      }).ToArray();
        if (result == null)
            await SendNotFoundAsync();
        else
            await SendAsync(result);
    }
}