using _12_Library_Micro.Utils;

namespace _12_Library_Micro.Models;

class Library
{
    private string path = Path.Combine("C:", "AB108", "home-tasks", "12_Library_Micro", "Files", "Database.json");
    private int _id;
    public int Id { get; set; }
    public string Name { get; set; }
    private List<Book> Books = [];

    public Library(string name)
    {
        Name = name;
    }

    public async Task AddBook(Book book)
    {
        Books.Add(book);
        await FileHelper.WriteFileAsync(path, Books);
    }

    public async Task<Book> GetBookById(int id)
    {
        List<Book> books = await FileHelper.ReadFileAsync(path);
        Book? book = books.Find(book => book.Id == id);
        if (book == null)
        {
            throw new Exception($"There is no book with id {id}");
        }

        return book; 
    }

    public async Task RemoveBook(int id)
    {
        List<Book> books = await FileHelper.ReadFileAsync(path);
        Book? book = books.Find(book => book.Id == id);
        if (book == null)
        {
            throw new Exception($"There is no book with id {id}");
        }

        books.Remove(book);
        Books = books;

        await FileHelper.WriteFileAsync(path, Books);
    }
}
