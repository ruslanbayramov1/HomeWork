using _12_Library_Micro.Models;
using Newtonsoft.Json;

namespace _12_Library_Micro.Utils;

class FileHelper
{
    public static async Task<List<Book>> ReadFileAsync(string path)
    { 
        using StreamReader sr = new StreamReader(path);
        string text = await sr.ReadToEndAsync();

        List<Book>? data = JsonConvert.DeserializeObject<List<Book>>(text);
        data ??= new List<Book>();

        return data;
    }

    public static async Task WriteFileAsync(string path, List<Book> books)
    {
        using StreamWriter sw = new StreamWriter(path, false);
        string text = JsonConvert.SerializeObject(books);

        await sw.WriteAsync(text);
    }
}
