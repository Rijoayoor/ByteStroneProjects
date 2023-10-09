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
        System.Console.WriteLine("hiiii");
        var id = Route<int>("id");


        // var result = (from customer in _context.Customers
        //               join booking in _context.Bookings
        //               on customer.BookingId equals booking.BookingId
        //               where booking.ExecutiveId == id
        //                 &&
        //                 (booking.Status == "new"
        //                 || booking.Status == "In progress"
        //                 || booking.Status == "Assigned"
        //                 || booking.Status == "completed"
        //                 || booking.Status == "Cancelled"
        //                 )
        //               select new
        //               {
        //                   booking.BookingId,
        //                   booking.BookingDate,
        //                   booking.CustomerId,
        //                   customer.ContactNumber,
        //                   customer.ServiceRequirements,
        //                   customer.CustomerName,
        //                   booking.Status
        //               }).ToArray();



        var result = (from booking in _context.Bookings
                      join customer in _context.Customers
                      on booking.BookingId equals customer.BookingId into customerGroup
                      from customer in customerGroup.DefaultIfEmpty()
                      join serviceTechnician in _context.ServiceTechnicians
                      on booking.TechnicianId equals serviceTechnician.TechnicianId into technicianGroup
                      from technician in technicianGroup.DefaultIfEmpty()
                      where booking.ExecutiveId == id
                        &&
                        (booking.Status == "new"
                        || booking.Status == "Assigned"
                        || booking.Status == "In progress"
                        || booking.Status == "completed"
                        || booking.Status == "Cancelled"
                        )
                      orderby booking.BookingDate descending
                      select new
                      {
                          booking.BookingId,
                          booking.BookingDate,
                          booking.CompletionDate,
                          booking.CustomerId,
                          customer.ContactNumber,
                          customer.ServiceRequirements,
                          customer.CustomerName,
                          technician.TechnicianName,
                          booking.Status
                      }).ToArray();
        if (result == null)
            await SendNotFoundAsync();
        else
            await SendAsync(result);
    }
}