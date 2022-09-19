using System.Reflection;
using Library.Domain.ProjectAggregate.Models;
using Library.SharedKernel;
using Library.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Library.Infrastructure;

public class LibraryContext : DbContext
{
    private readonly IDomainEventDispatcher? _dispatcher;

    public LibraryContext(DbContextOptions<LibraryContext> options,
        IDomainEventDispatcher? dispatcher)
        : base(options)
    {
        _dispatcher = dispatcher;
    }

    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<BookCollection> BookCollections => Set<BookCollection>();
    public DbSet<Domain.ProjectAggregate.Models.Library> Libraries => Set<Domain.ProjectAggregate.Models.Library>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        // ignore events if no dispatcher provided
        if (_dispatcher == null)
        {
            return result;
        }

        // dispatch events only if save was successful
        var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);
        return result;
    }

    public override int SaveChanges() => SaveChangesAsync().GetAwaiter().GetResult();
}