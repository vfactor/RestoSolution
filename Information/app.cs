namespace Information
{
    public partial class States
    {
        public States(State[] states) => values_ = [.. states];
    }  
    public partial class ServiceStatuses
    {
        public ServiceStatuses(ServiceStatus[] serviceStatuses) => values_ = [.. serviceStatuses];
    }
    public partial class LanguageCodes
    {
        public LanguageCodes(LanguageCode[] languageCodes) => values_ = [.. languageCodes];
    }
    public partial class Dictionary
    {
        public Dictionary(LanguageCode languageCode, DictionaryEntry[] entries)
        {
            LanguageCode = languageCode;
            entries_ = [.. entries];
        }
    }
    public partial class Dictionaries
    {
        public Dictionaries(Dictionary[] dictionaries)
        {
            collection_ = [.. dictionaries];
        }
        public Dictionary? GetDictionary(LanguageCode lc) => Collection.FirstOrDefault(d => d.LanguageCode.Code == lc.Code);
    }
}
