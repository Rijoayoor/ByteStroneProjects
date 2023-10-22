using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Model;

public class AssignJobEnpoint : Endpoint<Booking>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Put("/api/executive/{executiveId}/booking/{bookingId}");
        AllowAnonymous();
    }
    public AssignJobEnpoint(ServiceContext context)
    {
        _context = context;
    }
    public override async Task HandleAsync(Booking req, CancellationToken ct)
    {

        var executiveId = Route<int>("executiveId");
        var bookingId = Route<int>("bookingId");


        var booking = await _context.Bookings.FirstOrDefaultAsync(s => s.BookingId == bookingId && s.ExecutiveId == executiveId);

        if (booking == null)
        {
            await SendNotFoundAsync();
            return;
        }

        booking.TechnicianId = req.TechnicianId;
        // booking.Status = req.Status;
        booking.Status = "Assigned";
        booking.ExpectedCompletionDate = req.ExpectedCompletionDate;

        var technicians = _context.ServiceTechnicians.ToList();
        var sortedTechnicians = technicians.OrderBy(e => e.Count);
        var selectedTechnicians = sortedTechnicians.First();
        req.TechnicianId = selectedTechnicians.TechnicianId;

        await _context.SaveChangesAsync();
        CountTechnicianJob.updatecounttechnician(selectedTechnicians.TechnicianId, _context);
        await SendAsync(booking);
    }
}