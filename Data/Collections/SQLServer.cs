using Data.SQLServer;

namespace Data.Collections
{
    public class States(RestaurantReadOnlyContext dbcontext) : IMap<Information.States>
    {
        public Information.States ToInformation() => new([.. dbcontext.States.Select(s => s.ToInformation())]);
    }
    public class ServiceStatuses(RestaurantReadOnlyContext dbcontext) : IMap<Information.ServiceStatuses>
    {
       public Information.ServiceStatuses ToInformation() => new([.. dbcontext.ServiceStatuses.Select(s => s.ToInformation())]);
    }
    public class LanguageCodes(RestaurantReadOnlyContext dbcontext) : IMap<Information.LanguageCodes>
    {
        public Information.LanguageCodes ToInformation() => new([.. dbcontext.LanguageCodes.Select(lc => lc.ToInformation())]);
    }
    public class Dictionary(RestaurantReadOnlyContext dbcontext, LanguageCode languageCode) : IMap<Information.Dictionary>
    {
        public Information.Dictionary ToInfmation() => new(languageCode.ToInformation(),
                                                            [..dbcontext.DictioaryEntries.Where(e => e.LanguageCode == languageCode.Code)
                                                            .Select(e => e.ToInformation())]);
    }
    public class Dictionaries(RestaurantReadOnlyContext dbcontext) : IMap<Information.Dictionaries>
    {
        public Information.Dictionaries ToInformation() => new([..dbcontext.LanguageCodes.Select(lc => new Dictionary(dbcontext, lc)).Select(d => d.ToInfmation())]);
    }
}
