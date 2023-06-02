using FastEndpoints;
using Model;

public class CustomerGetEndpoint : EndpointWithoutRequest<Customer[]>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Get("/api/customers");
        AllowAnonymous();
    }

    public CustomerGetEndpoint(ServiceContext context)
    {
        _context = context;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(_context.Customers.ToArray());
    }
}
