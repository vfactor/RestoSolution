using Data.SQLServer;

namespace Data.Collections
{
    public class States(RestaurantReadOnlyContext dbcontext) : AbstractMap<Information.States>
    {
        public override Information.States ToInformation(CollectionMapper maappers) => new([.. dbcontext.States.Select(s => s.ToInformation(maappers))]);
    }
    public class ServiceStatuses(RestaurantReadOnlyContext dbcontext) : AbstractMap<Information.ServiceStatuses>
    {
       public override Information.ServiceStatuses ToInformation() => new([.. dbcontext.ServiceStatuses.Select(s => s.ToInformation())]);        
       public override Information.ServiceStatuses ToInformation(CollectionMapper maappers) => new([.. dbcontext.ServiceStatuses.Select(s => s.ToInformation(maappers))]);
    }
    public class LanguageCodes(RestaurantReadOnlyContext dbcontext) : AbstractMap<Information.LanguageCodes>
    {
        public override Information.LanguageCodes ToInformation(CollectionMapper maappers) => new([.. dbcontext.LanguageCodes.Select(lc => lc.ToInformation(maappers))]);
    }
    public class Dictionary(RestaurantReadOnlyContext dbcontext, LanguageCode languageCode) : AbstractMap<Information.Dictionary>
    {
        public override Information.Dictionary ToInformation(CollectionMapper maappers) => new(languageCode.ToInformation(),
                                                                        [..dbcontext.DictioaryEntries.Where(e => e.LanguageCode == languageCode.Code)
                                                                        .Select(e => e.ToInformation(maappers))]);
    }
    public class Dictionaries(RestaurantReadOnlyContext dbcontext) : AbstractMap<Information.Dictionaries>
    {
        public override Information.Dictionaries ToInformation(CollectionMapper maappers) => new([..dbcontext.LanguageCodes.Select(lc => new Dictionary(dbcontext, lc)).Select(d => d.ToInformation(maappers))]);
    }
}
