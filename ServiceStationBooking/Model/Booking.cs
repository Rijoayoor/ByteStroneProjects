using System;
using System.Collections.Generic;

namespace Model;

public partial class Booking
{
    public int BookingId { get; set; }

    public int CustomerId { get; set; }

    public DateOnly? BookingDate { get; set; }

    public string? Status { get; set; }

    public int? ExecutiveId { get; set; }

    public int? TechnicianId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ServiceExecutive? Executive { get; set; }
}
