using FastEndpoints;
using FluentValidation;
using Model;
using service.Core.Services;


public class CustomerDetailsEndpoint : Endpoint<Customer>
{

    private readonly CustomerDetailService? _customerDetailService;
    public override void Configure()
    {
        Post("/api/customer");
        AllowAnonymous();

    }

    public CustomerDetailsEndpoint(CustomerDetailService customerDetailService)
    {
        _customerDetailService = customerDetailService;
    }



    public override async Task HandleAsync(int id, string customername, string customernumber, string email, string address, string vehiclenumber, string vehiclemodel, string servicerequirements,
int customerid, int bookingid, CancellationToken cancellationToken)
    {

        var addCustomer = await _customerDetailService.AddCustomerDetails(id, customername, customernumber, email, address, vehiclenumber, vehiclemodel, servicerequirements,
 customerid, bookingid, cancellationToken)

 await SendAsync(addCustomer);

    }
}
