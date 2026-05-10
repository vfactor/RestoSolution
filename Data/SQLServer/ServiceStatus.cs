using System;
using System.Collections.Generic;

namespace Data.SQLServer;

public partial class ServiceStatus
{
    public byte Id { get; set; }

    public byte? NextStatusId { get; set; }

    public string Code { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Seating> Seatings { get; set; } = new List<Seating>();
}
