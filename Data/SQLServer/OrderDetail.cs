using System;
using System.Collections.Generic;

namespace Data.SQLServer;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int MenuDetailId { get; set; }

    public byte ServiceStatus { get; set; }

    public string? SpecialInstruction { get; set; }

    public virtual MenuDetail MenuDetail { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual ServiceStatus ServiceStatusNavigation { get; set; } = null!;
}
