using _12_Library_Micro.Models;

namespace _12_Library_Micro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("C:", "AB108", "home-tasks", "12_Library_Micro", "Files", "Database.json");
            if (!File.Exists(path))
            {
                string? dirPath = Path.GetDirectoryName(path);
                if (!Directory.Exists(dirPath) && dirPath != null)
                { 
                    Directory.CreateDirectory(dirPath);
                }
                File.Create(path).Close();
                Console.WriteLine($"Directory created at {path}");
            }
            Library lib = new("National Library");

            bool isContinue = true;
            int code = 0;
            double price;
            string menu = "1. Add book\n2. Get book by id\n3. Remove book\n0. Quit";

            Console.WriteLine($"Welcome to {lib.Name} !");
            Console.WriteLine(menu);
            while (isContinue)
            {
                Console.Write("Enter action code: ");
                code = Convert.ToInt32(Console.ReadLine());
                switch (code)
                {
                    case 1:
                        try
                        {
                            Console.Write("Please enter book name: ");
                            string name = Console.ReadLine();

                            Console.Write("Please enter book author: ");
                            string author = Console.ReadLine();

                            Console.Write("Please enter book price: ");
                            price = Convert.ToDouble(Console.ReadLine());

                            Book book = new(name, author, price);
                            book.ShowInfo();

                            lib.AddBook(book).Wait();
                        }
                        catch (Exception ex) 
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        try
                        {
                            Console.Write("Please enter book id: ");
                            int.TryParse(Console.ReadLine(), out int id);

                            Book book = lib.GetBookById(id).Result;
                            book.ShowInfo();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        try
                        {
                            Console.Write("Please enter book id: ");
                            int.TryParse(Console.ReadLine(), out int id);

                            lib.RemoveBook(id).Wait();
                            Console.WriteLine("Book removed !");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 0:
                        isContinue = false;
                        Console.WriteLine($"You are quit from library !");
                        break;
                    default:
                        Console.WriteLine(menu);
                        break;
                }
            }
        }
    }
}
