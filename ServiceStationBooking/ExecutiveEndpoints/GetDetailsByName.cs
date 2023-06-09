using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Model;

public class GetDetailsByNameEndpoint : EndpointWithoutRequest<dynamic[]>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Get("/api/details/{name}");
        AllowAnonymous();
    }

    public GetDetailsByNameEndpoint(ServiceContext context)
    {
        _context = context;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var name = Route<string>("name");

        var result = (from booking in _context.Bookings
                      join customer in _context.Customers
                      on booking.CustomerId equals customer.CustomerId
                      where customer.CustomerName.Contains(name)
                      select new
                      {
                          booking.BookingId,
                          booking.BookingDate,
                          booking.CustomerId,
                          booking.ServiceId,
                          customer.CustomerName
                      }).ToArray();


        if (result == null)
            await SendNotFoundAsync();
        else
        {

            await SendAsync(result);
        }



    }


}
