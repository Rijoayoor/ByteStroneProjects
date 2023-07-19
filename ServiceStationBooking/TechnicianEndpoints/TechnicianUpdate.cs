using FastEndpoints;
// using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Model;

public class TechnicianUpdateEnpoint : Endpoint<Booking>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Put("/api/technician/{technicianId}/customer/{customerId}");
        AllowAnonymous();
    }
    public TechnicianUpdateEnpoint(ServiceContext context)
    {
        _context = context;
    }
    public override async Task HandleAsync(Booking req, CancellationToken ct)
    {


        var technicianId = Route<int>("technicianId");
        var customerId = Route<int>("customerId");

        var booking = await _context.Bookings.FirstOrDefaultAsync(s => s.CustomerId == customerId && s.TechnicianId == technicianId);

        if (booking == null)
        {
            await SendNotFoundAsync();
            return;
        }

        var technicians = _context.ServiceTechnicians.ToList();
        var sortedTechnicians = technicians.OrderBy(e => e.Count);
        var selectedTechnicians = sortedTechnicians.First();
        booking.TechnicianId = selectedTechnicians.TechnicianId;
        booking.Status = req.Status;

        await _context.SaveChangesAsync();
        CountTechnicianJob.updatecounttechnician(selectedTechnicians.TechnicianId, _context);
        await SendAsync(booking);
    }
}