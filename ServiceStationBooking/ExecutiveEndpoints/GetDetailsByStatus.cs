using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Model;

public class GetDetailsByStatusEndpoint : EndpointWithoutRequest<dynamic[]>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Get("/api/detailsstatus/{executiveId}");
        AllowAnonymous();
    }
    public GetDetailsByStatusEndpoint(ServiceContext context)
    {
        _context = context;
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        int executiveId = Route<int>("executiveId");



        var result = (from booking in _context.Bookings
                      join customer in _context.Customers
                      on booking.BookingId equals customer.BookingId into customerGroup
                      from customer in customerGroup.DefaultIfEmpty()
                      join serviceTechnician in _context.ServiceTechnicians
                      on booking.TechnicianId equals serviceTechnician.TechnicianId into technicianGroup
                      from technician in technicianGroup.DefaultIfEmpty()
                      where booking.ExecutiveId == executiveId &&
                            (booking.Status == "new" || booking.Status == "In progress" || booking.Status == "Assigned")
                      orderby booking.BookingDate descending
                      select new
                      {
                          booking.BookingId,
                          booking.BookingDate,
                          customer.ContactNumber,
                          customer.ServiceRequirements,
                          customer.CustomerName,
                          technician.TechnicianName,
                          booking.ExecutiveId,
                          booking.Status
                      }).ToArray();
        var result1 = result.FirstOrDefault();

        if (result1 == null)
        {
            await SendNotFoundAsync();
        }
        else
        {
            await SendAsync(result);
        }
    }
}