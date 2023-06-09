using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
        var executives = _context.ServiceExecutives.ToList();
        var sortedExecutives = executives.OrderBy(e => e.Count);
        var selectedExecutives = sortedExecutives.First();
        booking.ExecutiveId = selectedExecutives.ExecutiveId;


        _context.Bookings.Add(booking);



        await _context.SaveChangesAsync();
        Count.updatecount(selectedExecutives.ExecutiveId, _context);

        await SendAsync(booking);

        //     var availableExecutives = await _context.ServiceExecutives
        //     .Where(e => e.IsAvailable)
        //     .ToListAsync(ct);

        // if (availableExecutives.Any())
        // {
        //     // Assign the first available executive
        //     booking.ExecutiveId = availableExecutives.First().ExecutiveId;

        //     _context.Bookings.Add(booking);
        //     await _context.SaveChangesAsync();

        //     await SendAsync(booking);
        // }

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

        // RuleFor(x => x.ExecutiveId)
        //     .NotEmpty()
        //     .WithMessage("Executive id is required!");



    }
}