using Data.Models.SQLServer;

namespace Data.Collections
{
    public class LanguageCodes(RestaurantReadOnlyContext dbcontext): IMap<Information.LanguageCodes>
    {
        public ICollection<LanguageCode> Values { get; set; } = [.. dbcontext.LanguageCodes.ToArray()];
        public Information.LanguageCodes ToInformation() => new([.. Values.Select(lc => lc.ToInformation()).ToArray()]);
    }
}
