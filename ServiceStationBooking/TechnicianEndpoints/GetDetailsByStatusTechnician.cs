using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Model;

public class GetDetailsByStatusTechnicianEndpoint : EndpointWithoutRequest<dynamic[]>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Get("/api/detailsstatustechnician/{technicianId}");
        AllowAnonymous();
    }
    public GetDetailsByStatusTechnicianEndpoint(ServiceContext context)
    {
        _context = context;
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        int technicianId = Route<int>("technicianId");
        var result = (from booking in _context.Bookings
                      join customer in _context.Customers
                      on booking.CustomerId equals customer.CustomerId
                      where booking.TechnicianId == technicianId
                        && 
                        (booking.Status == "new"
                        || booking.Status == "In progress"
                        // || booking.Status == "completed"
                        // || booking.Status == "Cancelled"
                        )
                      select new
                      {
                          booking.BookingId,
                          booking.BookingDate,
                          booking.CustomerId,
                          customer.ContactNumber,
                          customer.ServiceRequirements,
                          customer.CustomerName,
                          booking.Status
                      }).ToArray();
          var result1=result.FirstOrDefault();

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