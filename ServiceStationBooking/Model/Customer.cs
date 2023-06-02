using System;
using System.Collections.Generic;

namespace Model;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string VehicleNumber { get; set; } = null!;

    public string VehicleModel { get; set; } = null!;

    public string ServiceRequirements { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
