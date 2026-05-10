using System;
using EfcCodeFirst.Entites.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EfcCodeFirst.Data.Interceptors;

public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context == null)
        {
            return base.SavingChanges(eventData, result);
        }
        var entries = eventData.Context.ChangeTracker.Entries<ISoftDeletable>()
                        .Where(e => e.State == EntityState.Deleted)
                        .ToList();
        foreach (var entry in entries)
        {
            // Reference Owned Types
            foreach (var ownedType in entry.References
                        .Where(r => r.TargetEntry != null
                        && r.TargetEntry.Metadata.IsOwned()
                        && r.TargetEntry.State == EntityState.Deleted))
            {
                ownedType.TargetEntry!.State = EntityState.Modified;
            }
            entry.State = EntityState.Modified;
            entry.Entity.Delete();
        }
        return base.SavingChanges(eventData, result);
    }
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context == null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
        var entries = eventData.Context.ChangeTracker.Entries<ISoftDeletable>()
                        .Where(e => e.State == EntityState.Deleted)
                        .ToList();
        foreach (var entry in entries)
        {
            // Reference Owned Types
            foreach (var ownedType in entry.References
                        .Where(r => r.TargetEntry != null
                        && r.TargetEntry.Metadata.IsOwned()
                        && r.TargetEntry.State == EntityState.Deleted))
            {
                ownedType.TargetEntry!.State = EntityState.Modified;
            }
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
