using FastEndpoints;
using Model;
using service.Core.Customers;
using service.Core.Services;
using service.Infrastructure;

public class CustomerGetEndpoint : EndpointWithoutRequest<Customer[]>
{
    private readonly CustomerService _customerService;
    public override void Configure()
    {
        Get("/api/customers");
        AllowAnonymous();
    }
    public CustomerGetEndpoint(CustomerService customerService)
    {
        _customerService = customerService;
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
      await _customerService.GetCustomerDetails();
    }
}