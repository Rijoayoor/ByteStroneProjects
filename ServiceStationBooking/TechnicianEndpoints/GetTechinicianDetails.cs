using FastEndpoints;
using Model;

public class TechnicianGetEndpoint : EndpointWithoutRequest<ServiceTechnician[]>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Get("/api/technician");
        AllowAnonymous();
    }

    public TechnicianGetEndpoint(ServiceContext context)
    {
        _context = context;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(_context.ServiceTechnicians.ToArray());
    }
}
