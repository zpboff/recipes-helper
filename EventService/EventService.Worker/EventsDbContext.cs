using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace EventService.Worker;

public class EventsDbContext : DbContext
{
    public DbSet<EventEntity> Events { get; set; } = null!;

    public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<EventEntity>()
            .HasIndex(b => b.Id);
        
        modelBuilder
            .Entity<EventEntity>()
            .HasIndex(b => b.Key)
            .IncludeProperties(b => b.AppName);
        
        modelBuilder
            .Entity<EventEntity>()
            .Property(b => b.Id)
            .HasValueGenerator<GuidValueGenerator>();
    }
}