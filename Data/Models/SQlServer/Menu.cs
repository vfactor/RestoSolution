using System;
using System.Collections.Generic;

namespace Data.Models.SQLServer;

public partial class Menu
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte State { get; set; }

    public virtual ICollection<MenuDetail> MenuDetails { get; set; } = new List<MenuDetail>();

    public virtual State StateNavigation { get; set; } = null!;
}
