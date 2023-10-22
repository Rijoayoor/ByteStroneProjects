using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Model;

public class SearchDetailsEndpoint : EndpointWithoutRequest<dynamic[]>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Get("/api/details/name/{name}/date/{date}/email/{email}/vehiclemodel/{vehiclemodel}/requirement/{requirement}/{executiveid}");
        AllowAnonymous();
    }
    public SearchDetailsEndpoint(ServiceContext context)
    {
        _context = context;
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        // var name = Route<string>("name");
        // var date = Route<string>("date");
        // DateOnly convertedDate;
        // DateOnly.TryParse(date, out convertedDate);
        // var email = Route<string>("email");
        // var vehiclemodel = Route<string>("vehiclemodel");
        // var requirement = Route<string>("requirement");
        // var executiveid = Route<int>("executiveid");

        // var result = (from booking in _context.Bookings
        //               join customer in _context.Customers
        //               on booking.CustomerId equals customer.CustomerId
        //               where (customer.CustomerName.Contains(name)
        //               || booking.BookingDate == convertedDate
        //               || customer.Email == email
        //               || customer.VehicleModel == vehiclemodel
        //               || customer.ServiceRequirements == requirement)
        //               && booking.ExecutiveId == executiveid
        //               select new
        //               {
        //                   booking.BookingId,
        //                   customer.CustomerId,
        //                   customer.CustomerName,
        //                   customer.Email,
        //                   customer.VehicleModel,
        //                   booking.BookingDate,
        //                   customer.ServiceRequirements,
        //                   customer.ContactNumber,
        //                   booking.Status
        //               }).ToArray();

        var name = Route<string>("name");
        var date = Route<string>("date");
        DateOnly convertedDate;
        DateOnly.TryParse(date, out convertedDate);
        var email = Route<string>("email");
        var vehiclemodel = Route<string>("vehiclemodel");
        var requirement = Route<string>("requirement");
        var executiveid = Route<int>("executiveid");

        var result = (from booking in _context.Bookings
                      join customer in _context.Customers
                      on booking.BookingId equals customer.BookingId
                      where (!string.IsNullOrEmpty(name) && customer.CustomerName.ToLower().Contains(name.ToLower())
                      || booking.BookingDate == convertedDate
                      || (!string.IsNullOrEmpty(email) && customer.Email.ToLower() == email.ToLower())
                      || (!string.IsNullOrEmpty(vehiclemodel) && customer.VehicleModel.ToLower() == vehiclemodel.ToLower())
                      || (!string.IsNullOrEmpty(requirement) && customer.ServiceRequirements.ToLower() == requirement.ToLower()))
                      && booking.ExecutiveId == executiveid
                      select new
                      {
                          booking.BookingId,
                          customer.CustomerId,
                          customer.CustomerName,
                          customer.Email,
                          customer.VehicleModel,
                          booking.BookingDate,
                          customer.ServiceRequirements,
                          customer.ContactNumber,
                          booking.Status
                      }).ToArray();


        if (result.Length == 0)
        {
            await SendAsync(null);
        }
        else
        {
            await SendAsync(result);
        }
    }
}


