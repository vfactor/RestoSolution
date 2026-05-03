using System;
using System.Collections.Generic;

namespace Data.Models.SQLServer;

public partial class State
{
    public byte Id { get; set; }

    public string Code { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<MenuDetail> MenuDetails { get; set; } = new List<MenuDetail>();

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
}
