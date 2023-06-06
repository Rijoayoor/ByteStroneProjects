using FastEndpoints;
using FluentValidation;
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

        var customer = _context.Customers.Where(s => s.CustomerId == id).FirstOrDefault();

        if (customer == null)
        {
            await SendNotFoundAsync();
        }

        customer.CustomerName = req.CustomerName;

        customer.ContactNumber = req.ContactNumber;

        customer.Email = req.Email;

        customer.Address = req.Address;

        customer.VehicleNumber = req.VehicleNumber;

        customer.VehicleModel = req.VehicleModel;

        customer.ServiceRequirements = req.ServiceRequirements;



        await _context.SaveChangesAsync();

        await SendAsync(customer);

    }
}