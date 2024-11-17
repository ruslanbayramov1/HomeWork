using _13_EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace _13_EFCore.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EFCoreTaskOne;Trusted_Connection=True;TrustServerCertificate=True;");
        base.OnConfiguring(optionsBuilder);
    }
}
