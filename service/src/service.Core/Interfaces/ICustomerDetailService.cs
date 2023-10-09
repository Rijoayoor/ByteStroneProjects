namespace service.Core.Interfaces;
 public interface ICustomerDetailService
 {
    Task AddCustomerDetails(int id, string customername, string customernumber,string email,string address, string vehiclenumber, string vehiclemodel, string servicerequirements,
int customerid, int bookingid, CancellationToken cancellationToken);
 }