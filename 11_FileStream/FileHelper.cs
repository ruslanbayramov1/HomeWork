using Newtonsoft.Json;

namespace _11_FileStream;

static class FileHelper
{
    public static async Task<List<string>> ReadDataAsync(string path)
    {
        using StreamReader sr = new StreamReader(path);
        string text = await sr.ReadToEndAsync();

        List<string>? data = JsonConvert.DeserializeObject<List<string>>(text);
        if (data == null)
            return new List<string>();

        return data;
    }

    public static async Task WriteDataAsync(string path, List<string> data)
    {
        using StreamWriter sw = new StreamWriter(path, false);
        string text = JsonConvert.SerializeObject(data);
        await sw.WriteAsync(text);
    }
}
