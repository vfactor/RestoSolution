using Data.Models.SQLServer;

namespace Data.Collections
{
    public class ServiceStatuses(RestaurantReadOnlyContext dbcontext) : IMap<Information.ServiceStatuses>
    {
        public ICollection<ServiceStatus> Values { get; set; } = [.. dbcontext.ServiceStatuses.ToArray()];
        public Information.ServiceStatuses ToInformation() => new([.. Values.Select(s => s.ToInformation()).ToArray()]);
    }
}
