using System;
using System.Collections.Generic;

namespace Data.Models.SQLServer;

public partial class Item
{
    public int Id { get; set; }

    public int ParentId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte State { get; set; }

    public bool IsVegan { get; set; }

    public bool IsMilk { get; set; }

    public bool IsEgg { get; set; }

    public bool IsPeanut { get; set; }

    public bool IsTreenut { get; set; }

    public bool IsShellfish { get; set; }

    public bool IsExtra { get; set; }

    public bool IsService { get; set; }

    public virtual ICollection<MenuDetail> MenuDetails { get; set; } = new List<MenuDetail>();

    public virtual State StateNavigation { get; set; } = null!;
}
