namespace _06_Access_Modifiers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Singer santana = new("Carlos", "Santana", 60);
            Song smooth = new("Smooth", "Rock", santana );
            smooth.AddRating(7.5);
            smooth.AddRating(6.5);
            smooth.AddRating(6.7);
            smooth.AddRating(8.7);
            smooth.AddRating(9.5);

            smooth.GetInfo();
        }
    }
}
