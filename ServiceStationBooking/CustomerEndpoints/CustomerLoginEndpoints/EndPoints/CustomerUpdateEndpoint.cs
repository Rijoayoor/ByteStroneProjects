using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Model;

public class CustomerUpdateEnpoint : Endpoint<Customer>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Put("/api/customer/{id}");
        AllowAnonymous();
    }
    public CustomerUpdateEnpoint(ServiceContext context)
    {
        _context = context;
    }
    public override async Task HandleAsync(Customer req, CancellationToken ct)
    {

        var id = Route<int>("id");
        var customer = _context.Customers.Where(s => s.BookingId == id).FirstOrDefault();
        if (customer == null)
        {
            await SendNotFoundAsync();
        }

        customer.ServiceRequirements = req.ServiceRequirements;

        await _context.SaveChangesAsync();

        System.Console.WriteLine(customer);
        await SendAsync(customer);
    }
}