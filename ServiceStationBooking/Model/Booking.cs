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

    public DateOnly? ExpectedCompletionDate { get; set; }

    public DateOnly? CompletionDate { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ServiceExecutive? Executive { get; set; }

    public virtual ServiceTechnician? Technician { get; set; }
}
