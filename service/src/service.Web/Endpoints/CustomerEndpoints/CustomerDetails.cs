// using FastEndpoints;
// using FluentValidation;
// using Model;
// using service.Core.Services;
// using service.web.Endpoints.CustomerEndpoints;


// public class CustomerDetailsEndpoint : Endpoint<CustomerDetailsRequest>
// {

//     private readonly CustomerDetailService _customerDetailService;
//     public override void Configure()
//     {
//         Post("/api/customer");
//         AllowAnonymous();

//     }

//     public CustomerDetailsEndpoint(CustomerDetailService customerDetailService)
//     {
//         _customerDetailService = customerDetailService;
//     }



//     public override async Task HandleAsync(CustomerDetailsRequest request, CancellationToken cancellationToken)
//     {

//         // var addCustomer = await _customerDetailService.AddCustomerDetails( request.CustomerName, request.ContactNumber, request.Email, request.Address, request.VehicleNumber, request.VehicleModel, request.ServiceRequirements,request.CustomerId, request.BookingId);

//         var addCustomer = await _customerDetailService.AddCustomerDetails(request.CustomerId,
//         request.CustomerName,
//         request.ContactNumber,
//         request.Email,
//         request.Address,
//         request.VehicleNumber,
//         request.VehicleModel,
//         request.ServiceRequirements,
//         request.CustomerId,
//         request.BookingId);
//         await SendAsync(addCustomer);

//     }
// }
