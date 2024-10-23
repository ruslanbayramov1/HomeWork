namespace _07_Indexers;

internal class Program
{
    static void Main(string[] args)
    {
        ListInt list = new ListInt();
        list.Add(2);
        list.Add(6, 7, 9);
        list.Add(1);
        list.Add(3, 1, 8);
        list[0] = 10; // indexer

        Console.WriteLine($"Initial array: {list}\n\n");

        Console.WriteLine($"{list.Pop()} popped");
        Console.WriteLine(list);

        int num = 4;
        int index = list.Ints.Length - 1;
        list.Insert(num, index);
        Console.WriteLine($"\n{num} inserted to index {index}");
        Console.WriteLine(list);

        Console.WriteLine($"\nSum: {list.Sum()}\nAverage: {list.Average()}");

        Console.WriteLine($"\nIndex of 1: {list.IndexOf(1)}\nLast index of 1: {list.LastIndexOf(1)}");

        Console.WriteLine($"\nContains 5: {list.Contains(5)}");
    }
}
