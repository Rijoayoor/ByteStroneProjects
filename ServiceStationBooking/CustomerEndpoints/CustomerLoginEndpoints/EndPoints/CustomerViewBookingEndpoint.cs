using FastEndpoints;
using Model;

public class CustomerViewBookingEndpoint : EndpointWithoutRequest<Booking[]>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Get("/api/bookings");
        AllowAnonymous();
    }
    public CustomerViewBookingEndpoint(ServiceContext context)
    {
        _context = context;
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(_context.Bookings.ToArray());
    }
}