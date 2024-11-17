namespace _13_EFCore.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    public ICollection<User> Users { get; set; }
}
