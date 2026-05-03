using Data.Models.SQLServer;

namespace Data.Collections
{
    public class States(RestaurantReadOnlyContext dbcontext) : IMap<Information.States>
    {
        public virtual ICollection<Models.SQLServer.State> Values { get; set; } = [.. dbcontext.States];
        public Information.States ToInformation() => new([.. Values.Select(v => v.ToInformation())]);
    }
}
