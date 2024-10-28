namespace _08_Exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MeetingSchedule mainSchedule = new();
                mainSchedule.SetMeeting("Oct. Meeting", new DateTime(2024, 08, 14), new DateTime(2024, 08, 25));
                mainSchedule.SetMeeting("Sep. Meeting", new DateTime(2024, 09, 15), new DateTime(2024, 09, 20));
                Console.WriteLine(mainSchedule.Meetings[0]);
                Console.WriteLine(mainSchedule.Meetings[1]);

                mainSchedule.SetMeeting("Sep. Second Meeting", new DateTime(2024, 09, 20), new DateTime(2024, 09, 25)); // reserved date error
                mainSchedule.SetMeeting("Nov. Meeting", new DateTime(2024, 11, 14), new DateTime(2024, 11, 13)); // wrong date error
            }
            catch (ReservedDateIntervalException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (WrongDateIntervalException ex)
            {
                Console.WriteLine($"Wrong date interval: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Reservations finished!");
            }
        }
    }
}
