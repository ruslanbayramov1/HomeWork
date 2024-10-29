using _09_Generic;

namespace _09_Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Wolf w = new(true, 120, 15, "Female", "gray", 1500);
                Elephant e = new(4000, false, 55, "Male", "Asia", 8000);
                Meat f = new("Beef", 1500);
                ZooCage<Elephant, Meat> cage = new(e, f);

                Console.WriteLine(w);
                Console.WriteLine(e);
                Console.WriteLine(f);

                Console.WriteLine("\n---------HP after hunt---------\n");
                w.Hunt(e);
                Console.WriteLine(e);

                Console.WriteLine("\n\n---------HP after food---------\n");
                cage.EatFood(e);
                Console.WriteLine(e);
            }
            catch (Exception ex) when (ex is InvalidIntInputException || ex is InvalidGenderException || ex is InvalidMeatTypeException)
            {
                Console.WriteLine($"{ex.GetType().ToString().Split('.')[^1]}: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType().ToString().Split('.')[^1]}: {ex.Message}");
            }
        }
    }
}
