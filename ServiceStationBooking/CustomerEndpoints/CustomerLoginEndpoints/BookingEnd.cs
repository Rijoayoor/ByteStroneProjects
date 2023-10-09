// using FastEndpoints;
// using FluentValidation;
// using Microsoft.EntityFrameworkCore;
// using Model;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Routing;



// public class CustomerDetailsEndpoint : Endpoint<Customer,Booking>
// {
//     private readonly ServiceContext _context;
   

//     // public override void Configure()
//     // {
//     //     Post("/api/customer");
//     //     AllowAnonymous();

//     // }
//     public CustomerDetailsEndpoint(ServiceContext context)
//     {
//         _context = context;
        
//     }

   
//     public override async Task HandleAsync(Customer customer, CancellationToken ct)
//     {
        

//         _context.Customers.Add(customer);
       
//         await _context.SaveChangesAsync();
        
//         // await SendAsync(customer);

//     }
//     //  public override async Task HandleAsync(Booking booking, CancellationToken ct)
//     // {
        

//     //     _context.Bookings.Add(booking);
       
//     //     await _context.SaveChangesAsync();
        
//     //     // await SendAsync(customer);

//     // }
// }

