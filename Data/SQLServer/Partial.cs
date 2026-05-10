namespace Data.SQLServer
{
    public partial class AppInfo : AbstractMap<Information.AppInfo>
    {
        public override Information.AppInfo ToInformation() => new()
        {
            Id = this.Id,
            Name = this.Name,
            InstallOn = new(){ Year = this.InstallOn.Year, Month = this.InstallOn.Month, Day = this.InstallOn.Day },
            Version = this.Version,
            License = this.License.ToString(),
        };
    }
    public partial class State : AbstractMap<Information.State>
    {
        public override Information.State ToInformation() => new() 
        {
            Id = Id,
            Code = Code
        };
    }
    public partial class LanguageCode : AbstractMap<Information.LanguageCode>
    {
        public  override Information.LanguageCode ToInformation() => new()
        {
            Code = this.Code,
            Name = this.Name
        };
    }
    public partial class ServiceStatus : AbstractMap<Information.ServiceStatus>
    {
        public override Information.ServiceStatus ToInformation() => new()
        {
            Id = this.Id,
            NextStatusId = this.NextStatusId ?? 0,
            Code = this.Code
        };
    }
    public partial class DictioaryEntry : AbstractMap<Information.DictionaryEntry>
    {
        public override Information.DictionaryEntry ToInformation() => new()
        {
            Key = this.Key,
            Value = this.Value
        };
    }
}