using FastEndpoints;
using Model;

public class CustomerGetIdEndpoint : EndpointWithoutRequest<dynamic[]>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Get("/api/customers/{id}");
        AllowAnonymous();
    }
    public CustomerGetIdEndpoint(ServiceContext context)
    {
        _context = context;
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        var result =
        (from booking in _context.Bookings
         join customer in _context.Customers
         on booking.BookingId equals customer.BookingId
         where customer.CustomerId == id
         select new
         {
             customer.CustomerId,
             customer.CustomerName,
             customer.ContactNumber,
             customer.ServiceRequirements,
             booking.BookingDate,
             booking.Status
         }
        ).ToArray();


        if (result == null)
            await SendNotFoundAsync();
        else
            await SendAsync(result);


    }
}