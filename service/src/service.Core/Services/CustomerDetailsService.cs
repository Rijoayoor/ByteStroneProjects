using System.Threading;
using System.Threading.Tasks;
using Model;
using service.Core.Interfaces;


namespace service.Core.Services;

    public class CustomerDetailService : ICustomerDetailService
    {
        private readonly ServiceContext _context;

        public CustomerDetailService(ServiceContext context)
        {
            _context = context;
        }

        public async Task AddCustomerDetails(
            int id, 
            string customername, 
            string customernumber, 
            string email, 
            string address, 
            string vehiclenumber, 
            string vehiclemodel, 
            string servicerequirements,
            int customerid, 
            int bookingid, 
            CancellationToken cancellationToken)
        {
            // Create a Customer object using the provided data
            var customer = new Customer
            {
                Id = id,
                CustomerName = customername,
                ContactNumber = customernumber,
                Email = email,
                Address = address,
                VehicleNumber = vehiclenumber,
                VehicleModel = vehiclemodel,
                ServiceRequirements = servicerequirements,
                CustomerId = customerid,
                BookingId = bookingid
            };

            // Add the customer to the DbContext
            _context.Customers.Add(customer);

            // Save changes to the database
            await _context.SaveChangesAsync();
        }
    }

