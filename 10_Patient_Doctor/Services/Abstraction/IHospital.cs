using _10_Patient_Doctor.Models;

namespace _10_Patient_Doctor.Services.Abstraction;

interface IHospital
{
    void AddAppointment(Appointment appointment);
    void EndAppointment(int no);
    Appointment GetAppointment(int no);
    List<Appointment> GetAllAppointments();
    List<Appointment> GetWeeklyAppointments();
    List<Appointment> GetTodaysAppointments();
    List<Appointment> GetAllContinuingAppointments();
}
