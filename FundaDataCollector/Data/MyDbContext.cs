using FundaDataCollector.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FundaDataCollector.Data;

public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
{
    public DbSet<Property> Properties { get; set; }
    public DbSet<PaginationController> PaginationControllers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.MakelaarId);
        });

        modelBuilder.Entity<PaginationController>(entity =>
        {
            entity.HasKey(e => e.HasTuin);
        });
    }
}