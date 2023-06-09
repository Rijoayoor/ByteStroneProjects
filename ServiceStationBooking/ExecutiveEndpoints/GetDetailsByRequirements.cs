using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Model;

public class GetDetailsByRequirementsEndpoint : EndpointWithoutRequest<dynamic[]>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Get("/api/detailsrequirement/{requirement}");
        AllowAnonymous();
    }

    public GetDetailsByRequirementsEndpoint(ServiceContext context)
    {
        _context = context;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var requirement = Route<string>("requirement");

        var result = (from booking in _context.Bookings
                      join customer in _context.Customers
                      on booking.CustomerId equals customer.CustomerId
                      where customer.ServiceRequirements.Contains(requirement)
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
