﻿namespace _13_EFCore.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public ICollection<Product> Products { get; set; }
}
