using System;
using System.Collections.Generic;

namespace Data.Models.SQLServer;

public partial class MenuDetail
{
    public int Id { get; set; }

    public int MenuId { get; set; }

    public int ItemId { get; set; }

    public decimal Price { get; set; }

    public byte State { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Menu Menu { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual State StateNavigation { get; set; } = null!;
}
