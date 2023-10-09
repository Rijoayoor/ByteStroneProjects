using FastEndpoints;
using FluentValidation;
using Model;

namespace service.web.Endpoints.CustomerEndpoints;

public class CustomerDetailsRequest
{
     public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string VehicleNumber { get; set; } = null!;

    public string VehicleModel { get; set; } = null!;

    public string ServiceRequirements { get; set; } = null!;

    public int CustomerId { get; set; }

    public int? BookingId { get; set; }
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
        // RuleFor(x => x.Email)
        //     .NotEmpty()
        //     .WithMessage("Email id is required!")
        //     .EmailAddress()
        //     .WithMessage("Invalid Email address");
        // RuleFor(x => x.VehicleNumber)
        //     .NotEmpty()
        //     .WithMessage("Vehicle number is required!");
        // RuleFor(x => x.VehicleModel)
        //     .NotEmpty()
        //     .WithMessage("Vehicle model is required!");
        RuleFor(x => x.ServiceRequirements)
             .NotEmpty()
             .WithMessage("Service requirement is required!");
    }
}