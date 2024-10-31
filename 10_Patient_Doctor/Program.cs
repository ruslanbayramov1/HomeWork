using _10_Patient_Doctor.Exceptions;
using _10_Patient_Doctor.Extensions;
using _10_Patient_Doctor.Models;

namespace _10_Patient_Doctor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Hospital!");
            string menu = """
                1. Create Appointment
                2. Finish Appointment
                3. See all Appointments
                4. See all weekly Appointments
                5. See all daily Appointments
                6. See all continuing Appointments
                7. Exit menu
                """;

            Hospital hospital = new();
            bool isContinue = true;

            Console.WriteLine(menu);
            while (isContinue)
            {
                Console.Write("\nEnter code: ");
                int code;

                
                if (!int.TryParse(Console.ReadLine(), out code))
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                    continue;
                }

                switch (code)
                {
                    case 1:
                        try
                        {
                            Console.Write("Enter patient name: ");
                            string patName = Console.ReadLine();
                            Console.Write("Enter doctor name: ");
                            string docName = Console.ReadLine();
                            Console.Write("Enter date YY/MM/DD: ");
                            string[] dates = Console.ReadLine().Split('/');
                            Appointment ap = new(patName, docName, new DateTime(Convert.ToInt32(dates[0]), Convert.ToInt32(dates[1]), Convert.ToInt32(dates[2])));
                            hospital.AddAppointment(ap);
                        }
                        catch (Exception ex) when (ex is HospitalException)
                        {
                            Console.WriteLine($"{ex.GetType().ToString().Split('.')[^1]}: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 2:
                        try
                        {
                            Console.Write("Enter no: ");
                            int no = Convert.ToInt32(Console.ReadLine());
                            hospital.EndAppointment(no);
                        }
                        catch (Exception ex) when (ex is HospitalException)
                        {
                            Console.WriteLine($"{ex.GetType().ToString().Split('.')[^1]}: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 3:
                        try
                        {
                            hospital.Appointments.DisplayAllAppointmentInfo();
                        }
                        catch (Exception ex) when (ex is HospitalException)
                        {
                            Console.WriteLine($"{ex.GetType().ToString().Split('.')[^1]}: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 4:
                        try
                        {
                            hospital.GetWeeklyAppointments().DisplayAllAppointmentInfo();
                        }
                        catch (Exception ex) when (ex is HospitalException)
                        {
                            Console.WriteLine($"{ex.GetType().ToString().Split('.')[^1]}: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 5:
                        try
                        {
                            hospital.GetTodaysAppointments().DisplayAllAppointmentInfo();
                        }
                        catch (Exception ex) when (ex is HospitalException)
                        {
                            Console.WriteLine($"{ex.GetType().ToString().Split('.')[^1]}: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 6:
                        try
                        {
                            hospital.GetAllContinuingAppointments().DisplayAllAppointmentInfo();
                        }
                        catch (Exception ex) when (ex is HospitalException)
                        {
                            Console.WriteLine($"{ex.GetType().ToString().Split('.')[^1]}: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 7:
                        try
                        {
                            isContinue = false;
                            Console.WriteLine("You exit !");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid option! Please select a valid menu option.");
                        Console.WriteLine(menu);
                        break;
                }
            }
        }
    }
}
