using FastEndpoints;
using FluentValidation;
using Model;
public class CustomerBookingEnpoint : Endpoint<Customer, int>
{
    private readonly ServiceContext _context;

    public override void Configure()
    {
        Post("/api/customer");
        AllowAnonymous();

    }
    public CustomerBookingEnpoint(ServiceContext context)
    {
        _context = context;
    }

    public override async Task HandleAsync(Customer customer, CancellationToken ct)
    {

        _context.Customers.Add(customer);

        await _context.SaveChangesAsync();

        await SendAsync(customer.CustomerId);
    }
}



public class CustomerValidator : Validator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(x => x.CustomerName)
            .NotEmpty()
            .WithMessage("Your name is required!");
        // .MinimumLength(5)
        // .WithMessage("your name is too short!");

        RuleFor(x => x.ContactNumber)
            .NotEmpty()
            .WithMessage("Contact number is required!");
        // .GreaterThan(18)
        // .WithMessage("you are not legal yet!");

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