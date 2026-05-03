namespace Information
{
    public partial class States
    {
        public States(State[] states) => values_ = [.. states];
    }   
    public partial class LanguageCode
    {
        public LanguageCode(string code) => Code = code;
    }
    public partial class LanguageCodes
    {
        public LanguageCodes(LanguageCode[] languageCodes) => values_ = [..languageCodes];
    }
    public partial class ServiceStatuses
    {
        public ServiceStatuses(ServiceStatus[] serviceStatuses) => values_ = [.. serviceStatuses];
    }
}
