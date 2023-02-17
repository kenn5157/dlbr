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

        // Generate Keys
        modelBuilder.Entity<Field>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
    }
    
    public DbSet<Field> FieldTable { get; set; }
}