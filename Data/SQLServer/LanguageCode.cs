using System;
using System.Collections.Generic;

namespace Data.SQLServer;

public partial class LanguageCode
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<DictioaryEntry> DictioaryEntries { get; set; } = new List<DictioaryEntry>();
}
