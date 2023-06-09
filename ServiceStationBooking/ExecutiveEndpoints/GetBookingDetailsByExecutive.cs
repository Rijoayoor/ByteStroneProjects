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
        // var executive = _context.Bookings.Where(s => s.ExecutiveId == id).FirstOrDefault();
        var executive = _context.Customers.Where(c => c.Bookings.Any(b => b.ExecutiveId == id))
        .Select(c => new { c.CustomerName, c.ContactNumber, c.ServiceRequirements })
        .ToArray();


        if (executive == null)
            await SendNotFoundAsync();
        else
            await SendAsync(executive);

    }


}
