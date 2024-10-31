using _10_Patient_Doctor.Exceptions;

namespace _10_Patient_Doctor.Models;

class Appointment
{
    private static int _no;
    private DateTime _startDate;
    public int No { get; }
    public string Patient { get; set; }
    public string Doctor { get; set; }
    public DateTime StartDate 
    { 
        get => _startDate; 
        set
        {
            if (value > DateTime.Now)
                throw new HospitalException("Start date can not be higher than current date!");

            _startDate = value;
        }
    }
    public DateTime? EndDate { get; set; }

    public Appointment(string patient, string doctor, DateTime startDate)
    {
        No = ++_no;
        Patient = patient;
        Doctor = doctor;
        StartDate = startDate;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"{{ No: {No}, Patient: {Patient}, Doctor: {Doctor}, Start Date: {StartDate}, EndDate: {EndDate} }}");
    }
}
