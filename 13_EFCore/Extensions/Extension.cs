using _13_EFCore.Models;

namespace _13_EFCore.Extensions;

static class Extension
{
    public static bool Print(this List<Product> products)
    {
        if (products.Count == 0)
        {
            return false;
        }
        for (var i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{products.ElementAt(i).Id}. {products.ElementAt(i).Name} - {products.ElementAt(i).Price}");
        }
        return true;
    }
}
