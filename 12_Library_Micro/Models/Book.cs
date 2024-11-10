namespace _12_Library_Micro.Models;

abstract class IdInheriter
{
    private static int _id;
    public int Id { get; set; }
    protected IdInheriter() { }

    protected IdInheriter(int num)
    {
        _id++;
        Id = _id;
    }
}

class Book : IdInheriter
{
    public string Name { get; set; }
    public string AuthorName { get; set; }
    public double Price { get; set; }
    public void ShowInfo()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}, AuthorName: {AuthorName}, Price: {Price}");
    }

    public Book() { }

    public Book(string name, string authorName, double price) : base(1)
    {
        Name = name;
        AuthorName = authorName;
        Price = price;
    }
}
