using Microsoft.EntityFrameworkCore;
using CleanArch.Domain.Models;

namespace CleanArch.Infrastructure.Persistence;

public sealed class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}