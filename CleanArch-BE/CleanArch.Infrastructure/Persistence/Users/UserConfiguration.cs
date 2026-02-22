using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanArch.Domain.Models;

namespace CleanArch.Infrastructure.Persistence.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50);
           
        builder.HasIndex(u => u.Username).IsUnique();
        
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasIndex(u => u.Email).IsUnique();
        
        //example
        // builder.HasMany(p => p.Tasks)      // User has many Tasks
        //     .WithOne(t => t.Project)    // Task has one User
        //     .HasForeignKey(t => t.ProjectId) // The FK is on the Task
        //     .OnDelete(DeleteBehavior.Cascade); // Delete tasks if project is deleted
    }
}