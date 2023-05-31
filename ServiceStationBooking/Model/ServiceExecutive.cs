using System;
using System.Collections.Generic;

namespace Model;

public partial class ServiceExecutive
{
    public int ExecutiveId { get; set; }

    public string? ExecutiveName { get; set; }

    public string? ContactNumber { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
