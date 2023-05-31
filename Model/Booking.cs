using System;
using System.Collections.Generic;

namespace Model;

public partial class Booking
{
    public int BookingId { get; set; }

    public int CustomerId { get; set; }

    public int ServiceId { get; set; }

    public int ExecutiveId { get; set; }

    public int TechnicianId { get; set; }

    public DateOnly? BookingDate { get; set; }

    public string? Status { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ServiceExecutive Executive { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;

    public virtual ServiceTechnician Technician { get; set; } = null!;
}
