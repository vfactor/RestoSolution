using System;
using System.Collections.Generic;

namespace Data.Models.SQLServer;

public partial class DictioaryEntry
{
    public string UniqueCode { get; set; } = null!;

    public string LanguageCode { get; set; } = null!;

    public string? Value { get; set; }

    public virtual LanguageCode LanguageCodeNavigation { get; set; } = null!;
}
