using FastEndpoints;
using FluentValidation;
using Model;
public class BookingEnpoint : Endpoint<Booking>
{
    private readonly ServiceContext _context;

    public override void Configure()
    {
        Post("/api/booking");
        AllowAnonymous();

    }
    public BookingEnpoint(ServiceContext context)
    {
        _context = context;
    }

    public override async Task HandleAsync(Booking booking, CancellationToken ct)
    {

        _context.Bookings.Add(booking);

        await _context.SaveChangesAsync();



        await SendAsync(booking);

    }
}

public class BookingValidator : Validator<Booking>
{
    public BookingValidator()
    {
        RuleFor(x => x.ServiceId)
            .NotEmpty()
            .WithMessage("Serevice id is required!");


        RuleFor(x => x.BookingDate)
            .NotEmpty()
            .WithMessage("Booking date is required!");

        RuleFor(x => x.ExecutiveId)
            .NotEmpty()
            .WithMessage("Executive id is required!");



    }
}