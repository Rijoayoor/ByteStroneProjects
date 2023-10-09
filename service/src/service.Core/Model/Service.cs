using System;
using System.Collections.Generic;

namespace Model;

public partial class Service
{
    public int ServiceId { get; set; }

    public string? ServiceName { get; set; }

    public string? Description { get; set; }

    public string? Price { get; set; }
}
