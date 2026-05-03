using System;
using System.Collections.Generic;

namespace Data.Models.SQLServer;

public partial class Seating
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public byte ServiceStatus { get; set; }

    public byte MaxSeat { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ServiceStatus ServiceStatusNavigation { get; set; } = null!;
}
