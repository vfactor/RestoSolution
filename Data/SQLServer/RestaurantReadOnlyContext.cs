using Microsoft.EntityFrameworkCore;

namespace Data.SQLServer;

public partial class RestaurantReadOnlyContext : RestaurantContext
{
    public RestaurantReadOnlyContext(DbContextOptions<RestaurantContext> options) : base(options) => this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    public override int SaveChanges() => throw new InvalidOperationException("This context is read-only and cannot save changes.");
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => throw new InvalidOperationException("This context is read-only and cannot save changes.");
    public override int SaveChanges(bool acceptAllChangesOnSuccess) => throw new InvalidOperationException("This context is read-only and cannot save changes.");
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default) => throw new InvalidOperationException("This context is read-only and cannot save changes.");   
}
