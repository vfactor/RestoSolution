using System;
using System.Collections.Generic;

namespace Data.SQLServer;

public partial class DictioaryEntry
{
    public string Key { get; set; } = null!;

    public string LanguageCode { get; set; } = null!;

    public string Value { get; set; } = null!;

    public virtual LanguageCode LanguageCodeNavigation { get; set; } = null!;
}
