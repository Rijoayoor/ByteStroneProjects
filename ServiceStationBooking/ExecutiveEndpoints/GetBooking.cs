using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Model;

public class GetBookingEndpoint : EndpointWithoutRequest<Booking>
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

        var executive = _context.Bookings.Where(s => s.ExecutiveId == id).FirstOrDefault();

        //  var executive = _context.Bookings.Where(s => s.ExecutiveId == id).ToList();





        if (executive == null)
            await SendNotFoundAsync();
        else
            await SendAsync(executive);

        // await _context.WriteJsonAsync(executive);
    }


}
