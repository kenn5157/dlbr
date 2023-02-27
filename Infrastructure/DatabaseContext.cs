using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Generate Primary Keys
        modelBuilder.Entity<Field>()
            .HasKey(x => x.Id)
            .HasName("PK_Field");
        
        modelBuilder.Entity<Job>()
            .HasKey(x => x.Id)
            .HasName("PK_Job");

        // Generate Keys
        modelBuilder.Entity<Field>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Job>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
    }
    
    public DbSet<Field> FieldTable { get; set; }
    public DbSet<Job> JobTable { get; set; }
}