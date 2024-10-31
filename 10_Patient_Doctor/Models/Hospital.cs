using _10_Patient_Doctor.Exceptions;
using _10_Patient_Doctor.Services.Abstraction;
using Microsoft.VisualBasic;

namespace _10_Patient_Doctor.Models;

class Hospital : IHospital
{
    public List<Appointment> Appointments { get; set; } = new();

    public void AddAppointment(Appointment appointment)
    {
        Appointments.Add(appointment);
    }

    public void AddAppointment(params Appointment[] appointments)
    {
        foreach (Appointment appointment in appointments)
        {
            Appointments.Add(appointment);
        }
    }

    public void EndAppointment(int no)
    {
        Appointment ap = GetAppointment(no);

        if (ap != null)
            ap.EndDate = DateTime.Now;
    }

    public List<Appointment> GetAllAppointments()
    {
        return Appointments;
    }

    public List<Appointment> GetAllContinuingAppointments()
    {
        List<Appointment> appointments = Appointments.FindAll(ap => ap.EndDate == null);

        if (appointments.Count == 0)
            throw new HospitalException("There is no continuing appointments !");

        return appointments;
    }

    public Appointment GetAppointment(int no)
    {
        Appointment? ap = Appointments.Find(ap => ap.No == no);

        if (ap == null)
            throw new HospitalException($"The appointment with no ({no}) does not exists !");

        return ap;
    }

    public List<Appointment> GetTodaysAppointments()
    {
        List<Appointment> appointments = Appointments.FindAll(ap => ap.StartDate.Date == DateTime.Now.Date);

        if (appointments.Count == 0)
            throw new HospitalException($"There is no appointment for today !");

        return appointments;
    }

    public List<Appointment> GetWeeklyAppointments()
    {
        List<Appointment> appointments = Appointments.FindAll(ap =>
        {
            DateTime today = DateTime.Now.Date;
            DateTime startDate = today.AddDays(-(int)today.DayOfWeek + 1); // ornek: 3cu gundeyikse, Add (-3 + 1), 1ci gune gedirik
            DateTime endDate = startDate.AddDays(6);

            return ap.StartDate.Date >= startDate && ap.StartDate.Date <= endDate;
        });

        if (appointments.Count == 0)
            throw new HospitalException("There is no appointments for this week");

        return appointments;
    }
}
