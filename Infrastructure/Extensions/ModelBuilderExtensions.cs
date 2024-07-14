using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions;

internal static class ModelBuilderExtensions
{
    internal static void RemoveCascadeDeleteConvention(this ModelBuilder modelBuilder)
    {
        // Get all the foreign keys in the model that are not ownership and have cascade delete behavior
        var foreignKeys = modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(entity => entity.GetForeignKeys())
            .Where(fk => fk is { IsOwnership: false, DeleteBehavior: DeleteBehavior.Cascade })
            .ToList();

        // Change the delete behavior of each foreign key to restrict
        foreach (var fk in foreignKeys)
            fk.DeleteBehavior = DeleteBehavior.Restrict;
    }
}