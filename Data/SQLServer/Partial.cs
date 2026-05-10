namespace Data.SQLServer
{
    public partial class AppInfo : IMap<Information.AppInfo>
    {
        public Information.AppInfo ToInformation() => new()
        {
            Id = this.Id,
            Name = this.Name,
            InstallOn = new(){ Year = this.InstallOn.Year, Month = this.InstallOn.Month, Day = this.InstallOn.Day },
            Version = this.Version,
            License = this.License.ToString(),
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
            Code = this.Code,
            Name = this.Name
        };
    }
    public partial class ServiceStatus : IMap<Information.ServiceStatus>
    {
        public Information.ServiceStatus ToInformation() => new()
        {
            Id = this.Id,
            NextStatusId = this.NextStatusId ?? 0,
            Code = this.Code
        };
    }
    public partial class DictioaryEntry : IMap<Information.DictionaryEntry>
    {
        public Information.DictionaryEntry ToInformation() => new()
        {
            Key = this.Key,
            Value = this.Value
        };
    }
}