namespace _11_FileStream
{
    internal class Program
    {
        const string path = @"C:\AB108\home-tasks\11_FileStream\Data\names.json";
        static void Main(string[] args)
        {
            try
            {
                if (!File.Exists(path))
                    File.Create(path).Close();

                Add("Jack").Wait();
                Add("Jim").Wait();
                Add("Adam").Wait();

                Console.WriteLine(Exist("John").Result);

                Update(1, "Jimmie").Wait();
                Delete(0).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static async Task Add(string name)
        {
            List<string> names = await FileHelper.ReadDataAsync(path);
            names.Add(name);
            await FileHelper.WriteDataAsync(path, names);
        }
        static async Task<bool> Exist(string name)
        {
            List<string> names = await FileHelper.ReadDataAsync(path);
            bool isExists = names.Exists(n => n == name);
            return isExists;
        }

        static async Task Update(int index, string name)
        {
            List<string> names = await FileHelper.ReadDataAsync(path);
            if (index > names.Count || index < 0)
                throw new Exception("Index is big or less than bounds of list");

            names[index] = name;
            await FileHelper.WriteDataAsync(path, names);
        }

        static async Task Delete(int index)
        {
            List<string> names = await FileHelper.ReadDataAsync(path);
            names.RemoveAt(index);
            await FileHelper.WriteDataAsync(path, names);
        }
    }
}
