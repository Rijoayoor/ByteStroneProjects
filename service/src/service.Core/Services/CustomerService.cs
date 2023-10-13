using System.Threading;
using System.Threading.Tasks;
using service.Core.Interfaces;


namespace service.Core.Services;

    public class CustomerService : ICustomerService
    {
        private readonly ServiceContext _context;

        public CustomerService(ServiceContext context)
        {
            _context = context;
        }

        public async Task GetCustomerDetails()
        {
            var customerDetails = await _context.Customers.ToArray();
            return customerDetails;
        }
        
        }