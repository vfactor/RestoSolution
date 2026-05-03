using Data.Models.SQLServer;
using Information;

namespace Data.Collections
{
    public class Dictionary(RestaurantReadOnlyContext dbcontext, string languageCode) : IMap<Information.Dictionary>
    {
        public Models.SQLServer.LanguageCode LanguageCode { get; set; } = dbcontext.LanguageCodes.First(lc => lc.Code == languageCode);
        public ICollection<DictioaryEntry> Entries { get; set; } = [.. dbcontext.DictioaryEntries.Where(lc => lc.LanguageCode == languageCode).ToArray()];
        public Information.Dictionary ToInformation() => new(LanguageCode.ToInformation(), [.. Entries.Select(d => d.ToInformation()).ToArray()]);
    }
    public class Dictionaries(RestaurantReadOnlyContext dbcontext, LanguageCodes languageCodes) : IMap<Information.Dictionaries>
    {
        public ICollection<Dictionary> Collection { get; set; } = [.. languageCodes.Values.Select(lc => new Dictionary(dbcontext, lc.Code)).ToArray()];       
        public Information.Dictionaries ToInformation() => new([.. Collection.Select(d => d.ToInformation()).ToArray()]);
    }
}
