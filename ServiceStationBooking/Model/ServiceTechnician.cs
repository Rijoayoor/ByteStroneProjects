using System;
using System.Collections.Generic;

namespace Model;

public partial class ServiceTechnician
{
    public int TechnicianId { get; set; }

    public string? TechnicianName { get; set; }

    public string? ContactNumber { get; set; }

    public int? Count { get; set; }

    public string? ExperienceYear { get; set; }

    public string? ExperienceArea { get; set; }
}
