namespace service.Core.Customers;
public class Customer
{
     public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string VehicleNumber { get; set; } = null!;

    public string VehicleModel { get; set; } = null!;

    public string ServiceRequirements { get; set; } = null!;

    public int CustomerId { get; set; }

    public int? BookingId { get; set; }
}