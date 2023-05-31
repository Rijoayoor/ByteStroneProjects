using System;
using System.Collections.Generic;

namespace Model;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? ContactNumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? VehicleNumber { get; set; }

    public string? VehicleModel { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
