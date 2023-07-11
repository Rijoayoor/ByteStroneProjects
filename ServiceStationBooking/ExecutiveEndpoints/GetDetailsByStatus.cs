using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Model;

public class GetDetailsByStatusEndpoint : EndpointWithoutRequest<dynamic[]>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Get("/api/detailsstatus");
        AllowAnonymous();
    }
    public GetDetailsByStatusEndpoint(ServiceContext context)
    {
        _context = context;
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        // var status = Route<string>("status");
        var result = (from booking in _context.Bookings
                      join customer in _context.Customers
                      on booking.CustomerId equals customer.CustomerId
                      where booking.Status == "new" || booking.Status == "In progress"
                      select new
                      {
                          booking.BookingId,
                          booking.BookingDate,
                          booking.CustomerId,
                          booking.ServiceId,
                          customer.CustomerName,
                          booking.Status
                      }).ToArray();
        if (result == null)
            await SendNotFoundAsync();
        else
        {
            await SendAsync(result);
        }
    }
}