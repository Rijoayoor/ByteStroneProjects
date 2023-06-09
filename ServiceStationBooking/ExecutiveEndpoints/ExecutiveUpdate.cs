using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Model;

public class ExecutiveUpdateEnpoint : Endpoint<Booking>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Put("/api/executive/{id}");
        AllowAnonymous();
    }

    public ExecutiveUpdateEnpoint(ServiceContext context)
    {
        _context = context;
    }

    public override async Task HandleAsync(Booking req, CancellationToken ct)
    {
        var id = Route<int>("id");

        var executive = _context.Bookings.Where(s => s.ExecutiveId == id).FirstOrDefault();

        if (executive == null)
        {
            await SendNotFoundAsync();
        }


        executive.Status = req.Status;

        await _context.SaveChangesAsync();

        Count.updatecount(executive.ExecutiveId,_context);

        await SendAsync(executive);

    }
}