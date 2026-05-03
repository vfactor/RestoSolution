namespace Data.Models.SQLServer
{
    public partial class AppInfo : IMap<Information.AppInfo>
    {
        public Information.AppInfo ToInformation() => new()
        {
           Name = this.Name
        };
    }
    public partial class State : IMap<Information.State>
    {
        public Information.State ToInformation() => new()
        {
            Id = Id,
            Code = Code
        };
    }
    public partial class LanguageCode : IMap<Information.LanguageCode>
    {
        public Information.LanguageCode ToInformation() => new()
        {
            Code = Code,
            Name = Name
        };
    }
    public partial class ServiceStatus : IMap<Information.ServiceStatus>
    {
        public Information.ServiceStatus ToInformation() => new()
        {
            Id = Id,
            NextStatusId = NextStatusId ?? 0,
            Code = Code
        };
    }
    public partial class DictioaryEntry : IMap<Information.DictionaryEntry>
    {
        public Information.DictionaryEntry ToInformation() => new()
        {
            Key = UniqueCode ?? string.Empty,
            Value = Value ?? string.Empty
        };
    }
}