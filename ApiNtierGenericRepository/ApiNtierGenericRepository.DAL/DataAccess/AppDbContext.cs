using ApiNtierGenericRepository.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiNtierGenericRepository.DAL.DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<ApiNtierGenericRepository.DAL.Entities.Group> Groups { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Room> Rooms { get; set; }

    public AppDbContext(DbContextOptions opt) : base(opt)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
