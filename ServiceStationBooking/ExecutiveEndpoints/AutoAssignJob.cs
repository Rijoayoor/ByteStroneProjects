using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Model;
public class AutoAssignJobEndpoint : Endpoint<Booking>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Put("/api/autoassign/executive/{executiveId}/booking/{bookingId}");
        AllowAnonymous();
    }
    public AutoAssignJobEndpoint(ServiceContext context)
    {
        _context = context;
    }
    public override async Task HandleAsync(Booking booking, CancellationToken ct)
    {
        var executiveId = Route<int>("executiveId");
        var bookingId = Route<int>("bookingId");

        var bookedService = await _context.Bookings.FirstOrDefaultAsync(s => s.BookingId == bookingId && s.ExecutiveId == executiveId);

        if (bookedService == null)
        {
            await SendNotFoundAsync();
           
        }
        var technicians = _context.ServiceTechnicians.ToList();
        var sortedTechnicians = technicians.OrderBy(e => e.Count);
        var selectedTechnicians = sortedTechnicians.First();
        booking.TechnicianId = selectedTechnicians.TechnicianId;
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
        Count.updatecount(selectedTechnicians.TechnicianId, _context);

    }
}
