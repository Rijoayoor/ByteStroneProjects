// // using FastEndpoints;
// // using FluentValidation;
// // using Model;
// // public class CustomerDetailsBookingEnpoint : Endpoint<Customer>
// // {
// //     private readonly ServiceContext _context;
// //     public override void Configure()
// //     {
// //         Post("/api/customer");
// //         AllowAnonymous();
// //     }
// //     public CustomerDetailsBookingEnpoint(ServiceContext context)
// //     {
// //         _context = context;
// //     }
// //     public override async Task HandleAsync(Customer customer, CancellationToken ct)
// //     {

// //         _context.Customers.Add(customer);
// //         await _context.SaveChangesAsync();
// //         Booking booking = new();

// //         string bookingDateStr = "2023-06-28";
// //         DateOnly bookingDate;

// //         if (DateOnly.TryParse(bookingDateStr, out bookingDate))
// //         {
// //         //     // Use the bookingDate value as needed
// //         //     // For example, pass it to a method or assign it to a property
// //         //     booking.BookingDate = bookingDate;
// //         //     booking.ServiceId = 3;
// //         booking.ServiceId=3;
// //         booking.BookingDate=bookingDate;

// //             booking.CustomerId = customer.CustomerId;
// //         }
// //         _context.Bookings.Add(booking);

// //         await _context.SaveChangesAsync();
// //         Count.updatecount(booking.BookingId, _context);


// //         await SendAsync(customer);


// //     }
// // }
// // // public class CustomerValidator : Validator<Customer>
// // // {
// // //     public CustomerValidator()
// // //     {
// // //         RuleFor(x => x.CustomerName)
// // //             .NotEmpty()
// // //             .WithMessage("Your name is required!")
// // //             .Matches(@"^[a-zA-Z\s]+$")
// // //             .WithMessage("Name must contain only letters and spaces.");
// // //         RuleFor(x => x.ContactNumber)
// // //             .NotEmpty()
// // //             .WithMessage("Contact number is required!")
// // //             .Matches(@"^[0-9]+$")
// // //             .WithMessage("contact number must contain only digits");
// // //         RuleFor(x => x.Email)
// // //             .NotEmpty()
// // //             .WithMessage("Email id is required!")
// // //             .EmailAddress()
// // //             .WithMessage("Invalid Email address");
// // //         RuleFor(x => x.VehicleNumber)
// // //             .NotEmpty()
// // //             .WithMessage("Vehicle number is required!");
// // //         RuleFor(x => x.VehicleModel)
// // //             .NotEmpty()
// // //             .WithMessage("Vehicle model is required!");
// // //         RuleFor(x => x.ServiceRequirements)
// // //              .NotEmpty()
// // //              .WithMessage("Service requirement is required!");
// // //     }
// // // }










// // using FastEndpoints;
// // using FluentValidation;
// // using Model;
// // using System.IO;
// // using System.Text;
// // using System.Text.Json;

// // public class CustomerDetailsBookingEnpoint : Endpoint<Customer>
// // {
// //     private readonly ServiceContext _context;

// //     public override void Configure()
// //     {
// //         Post("/api/customer/new");
// //         AllowAnonymous();
// //     }

// //     public CustomerDetailsBookingEnpoint(ServiceContext context)
// //     {
// //         _context = context;
// //     }

// //     public override async Task HandleAsync(Customer customer, CancellationToken ct)
// //     {
// //         _context.Customers.Add(customer);
// //         await _context.SaveChangesAsync();

// //         // Retrieve the booking details from the API request
// //         Booking booking = await GetBookingDetailsFromRequest();

// //         booking.CustomerId = customer.CustomerId;
// //         _context.Bookings.Add(booking);
// //         await _context.SaveChangesAsync();

// //         // await SendAsync(customer, booking);

// //         await SendAsync(customer.CustomerId, booking.ServiceId);
// //     }

// //     private async Task<Booking> GetBookingDetailsFromRequest()
// //     {
// //         // Retrieve the booking details from the API request

// //         using (StreamReader reader = new StreamReader(HttpContext.Request.Body, Encoding.UTF8))
// //         {
// //             string requestBody = await reader.ReadToEndAsync();
// //             Booking booking = JsonSerializer.Deserialize<Booking>(requestBody);

// //             return booking;
// //         }
// //     }
// // }



// using FastEndpoints;
// using FluentValidation;
// using Model;
// using System.IO;
// using System.Text;
// using System.Text.Json;

// public class CustomerDetailsBookingEnpoint : Endpoint<Customer>
// {
//     private readonly ServiceContext _context;

//     public override void Configure()
//     {
//         Post("/api/customer/new");
//         AllowAnonymous();
//     }

//     public CustomerDetailsBookingEnpoint(ServiceContext context)
//     {
//         _context = context;
//     }

//     public override async Task HandleAsync(Customer customer, CancellationToken ct)
//     {
//         _context.Customers.Add(customer);
//         await _context.SaveChangesAsync();

//         // Retrieve the booking details from the API request
//         Booking booking = await GetBookingDetailsFromRequest();

//         booking.CustomerId = customer.CustomerId;
//         _context.Bookings.Add(booking);
//         await _context.SaveChangesAsync();

//         await SendAsync(customer, booking);
//     }

//     private async Task<Booking> GetBookingDetailsFromRequest()
//     {
//         // Retrieve the booking details from the API request

//         using (StreamReader reader = new StreamReader(HttpContext.Request.Body, Encoding.UTF8))
//         {
//             string requestBody = await reader.ReadToEndAsync();
//             CustomerBookingData bookingData = JsonSerializer.Deserialize<CustomerBookingData>(requestBody);

//             Booking booking = new Booking
//             {
                
//                 ServiceId = bookingData.ServiceId,
//                 BookingDate = bookingData.BookingDate
//             };

//             return booking;
//         }
//     }

//     private async Task SendAsync(Customer customer, Booking booking)
//     {
//         // Implement the logic to send the customer and booking information
//         // Example logic:
//         // var message = new Message
//         // {
//         //     CustomerId = customer.CustomerId,
//         //     BookingId = booking.BookingId,
//         //     // Include other relevant properties
//         // };
//         // await MessageSender.SendMessageAsync(message);
//     }
// }

// public class CustomerBookingData
// {
//     public string ServiceRequirements { get; set; }
//     public int ServiceId { get; set; }
//     public DateOnly BookingDate { get; set; }
// }
