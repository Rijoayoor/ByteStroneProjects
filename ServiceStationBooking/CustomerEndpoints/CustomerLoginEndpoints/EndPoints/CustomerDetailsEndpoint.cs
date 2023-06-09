using FastEndpoints;
using FluentValidation;
using Model;
public class CustomerDetailsEnpoint : Endpoint<Customer>
{
    private readonly ServiceContext _context;

    public override void Configure()
    {
        Post("/api/customer");
        AllowAnonymous();

    }
    public CustomerDetailsEnpoint(ServiceContext context)
    {
        _context = context;
    }

    public override async Task HandleAsync(Customer customer, CancellationToken ct)
    {

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        await SendAsync(customer);

    }
}

public class CustomerValidator : Validator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(x => x.CustomerName)
            .NotEmpty()
            .WithMessage("Your name is required!");


        RuleFor(x => x.ContactNumber)
            .NotEmpty()
            .WithMessage("Contact number is required!");


        RuleFor(x => x.VehicleNumber)
            .NotEmpty()
            .WithMessage("Vehicle model is required!");

        RuleFor(x => x.VehicleModel)
            .NotEmpty()
            .WithMessage("Vehicle model is required!");

        RuleFor(x => x.ServiceRequirements)
             .NotEmpty()
             .WithMessage("Vehicle model is required!");
    }
}