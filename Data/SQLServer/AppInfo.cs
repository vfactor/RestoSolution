using System;
using System.Collections.Generic;

namespace Data.SQLServer;

public partial class AppInfo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly InstallOn { get; set; }

    public string Version { get; set; } = null!;

    public Guid License { get; set; }
}
