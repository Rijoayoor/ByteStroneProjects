using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Model;

public class ExecutiveUpdateEnpoint : Endpoint<Booking>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Put("/api/executive/{executiveId}/customer/{customerId}");
        AllowAnonymous();
    }
    public ExecutiveUpdateEnpoint(ServiceContext context)
    {
        _context = context;
    }
    public override async Task HandleAsync(Booking req, CancellationToken ct)
    {
        

        var executiveId = Route<int>("executiveId");
        var customerId = Route<int>("customerId");

        var booking = await _context.Bookings.FirstOrDefaultAsync(s => s.CustomerId == customerId && s.ExecutiveId == executiveId);

        if (booking == null)
        {
            await SendNotFoundAsync();
            return;
        }

        var executives = _context.ServiceExecutives.ToList();
        var sortedExecutives = executives.OrderBy(e => e.Count);
        var selectedExecutives = sortedExecutives.First();
        booking.ExecutiveId = selectedExecutives.ExecutiveId; 

        booking.Status = req.Status;
        await _context.SaveChangesAsync();
        // Count.updatecount(booking.BookingId, _context);
        Count.updatecount(selectedExecutives.ExecutiveId, _context);

        await SendAsync(booking);
    }
}