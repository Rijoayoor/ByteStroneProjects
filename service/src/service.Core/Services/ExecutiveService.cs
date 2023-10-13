// using System.Threading;
// using System.Threading.Tasks;
// using Model;
// using service.Core.Interfaces;


// namespace service.Core.Services;

//     public class ExecutiveService : IExecutiveService
//     {
//         private readonly ServiceContext _context;

//         public ExecutiveService(ServiceContext context)
//         {
//             _context = context;
//         }

//         public async Task GetBookingDetailsByExecutive(CancellationToken cancellationToken)
//         {
//                 var result = (from booking in _context.Bookings
//                       join customer in _context.Customers
//                       on booking.BookingId equals customer.BookingId into customerGroup
//                       from customer in customerGroup.DefaultIfEmpty()
//                       join serviceTechnician in _context.ServiceTechnicians
//                       on booking.TechnicianId equals serviceTechnician.TechnicianId into technicianGroup
//                       from technician in technicianGroup.DefaultIfEmpty()
//                       where booking.ExecutiveId == id
//                         &&
//                         (booking.Status == "new"
//                         || booking.Status == "Assigned"
//                         || booking.Status == "In progress"
//                         || booking.Status == "completed"
//                         || booking.Status == "Cancelled"
//                         )
//                       orderby booking.BookingDate descending
//                       select new
//                       {
//                           booking.BookingId,
//                           booking.BookingDate,
//                           booking.CompletionDate,
//                           booking.CustomerId,
//                           customer.ContactNumber,
//                           customer.ServiceRequirements,
//                           customer.CustomerName,
//                           technician.TechnicianName,
//                           booking.Status
//                       }).ToArray();
//         if (result == null)
//             await SendNotFoundAsync();
//         else
//             await SendAsync(result);
//     }
//         }
        

