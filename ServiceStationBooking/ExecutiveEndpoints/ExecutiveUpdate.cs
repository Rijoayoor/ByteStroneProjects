using FastEndpoints;
// using FluentValidation;
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
        // var id = Route<int>("id");
        // var executives = _context.Bookings.Where(s => s.ExecutiveId == id);
        // if (executives == null)
        // {
        //     await SendNotFoundAsync();
        // }
        // foreach(var executive in executives)
        // {
        // executive.Status = req.Status;
        // }
        // await _context.SaveChangesAsync();
        // Count.updatecount(id,_context);
        // await SendAsync(executives);

        //     var id = Route<int>("id");
        // var executiveId = req.ExecutiveId;

        var executiveId = Route<int>("executiveId");
        var customerId = Route<int>("customerId");

        var booking = await _context.Bookings.FirstOrDefaultAsync(s => s.CustomerId == customerId && s.ExecutiveId == executiveId);

        if (booking == null)
        {
            await SendNotFoundAsync();
            return;
        }

        booking.Status = req.Status;
        await _context.SaveChangesAsync();
        Count.updatecount(booking.BookingId, _context);

        await SendAsync(booking);
    }
}