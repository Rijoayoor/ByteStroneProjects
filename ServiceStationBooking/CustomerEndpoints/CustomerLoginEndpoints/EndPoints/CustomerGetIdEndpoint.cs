using FastEndpoints;
using Model;

public class CustomerGetIdEndpoint : EndpointWithoutRequest<Customer>
{
    private readonly ServiceContext _context;
    public override void Configure()
    {
        Get("/api/customers/{id}");
        AllowAnonymous();
    }
    public CustomerGetIdEndpoint(ServiceContext context)
    {
        _context = context;
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        var customer = _context.Customers.Where(s => s.CustomerId == id).FirstOrDefault();
        if (customer == null)
            await SendNotFoundAsync();
        else
            await SendAsync(customer);
    }
}