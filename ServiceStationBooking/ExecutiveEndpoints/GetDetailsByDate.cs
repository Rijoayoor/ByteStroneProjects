using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Model;

public class GetDetailsByDateEndpoint : EndpointWithoutRequest<dynamic[]>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Get("/api/detailsdate/{date}");
        AllowAnonymous();
    }

    public GetDetailsByDateEndpoint(ServiceContext context)
    {
        _context = context;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var date = Route<string>("date");
        DateOnly convertedDate;

        if (DateOnly.TryParse(date, out convertedDate))
        {

            var result = (from booking in _context.Bookings
                          join customer in _context.Customers
                          on booking.CustomerId equals customer.CustomerId
                          where booking.BookingDate == convertedDate
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
        else
            await SendNotFoundAsync();







    }


}
