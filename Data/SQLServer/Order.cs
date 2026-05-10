using System;
using System.Collections.Generic;

namespace Data.SQLServer;

public partial class Order
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public int CustomerId { get; set; }

    public int SeatingId { get; set; }

    public byte Seat { get; set; }

    public byte ServiceStatus { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly? InPreparationTime { get; set; }

    public TimeOnly? ReadyTime { get; set; }

    public TimeOnly? CloseTime { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Seating Seating { get; set; } = null!;

    public virtual ServiceStatus ServiceStatusNavigation { get; set; } = null!;
}
