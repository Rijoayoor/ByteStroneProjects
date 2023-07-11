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
         var booking = new Booking()
        {

            CustomerId=customer.CustomerId,
            
            


        };
        
        await SendAsync(booking);


    }
}
public class CustomerValidator : Validator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(x => x.CustomerName)
            .NotEmpty()
            .WithMessage("Your name is required!")
            .Matches(@"^[a-zA-Z\s]+$")
            .WithMessage("Name must contain only letters and spaces.");
        RuleFor(x => x.ContactNumber)
            .NotEmpty()
            .WithMessage("Contact number is required!")
            .Matches(@"^[0-9]+$")
            .WithMessage("contact number must contain only digits");
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email id is required!")
            .EmailAddress()
            .WithMessage("Invalid Email address");
        RuleFor(x => x.VehicleNumber)
            .NotEmpty()
            .WithMessage("Vehicle number is required!");
        RuleFor(x => x.VehicleModel)
            .NotEmpty()
            .WithMessage("Vehicle model is required!");
        RuleFor(x => x.ServiceRequirements)
             .NotEmpty()
             .WithMessage("Service requirement is required!");
    }
}