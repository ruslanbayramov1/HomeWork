using _10_Patient_Doctor.Exceptions;
using _10_Patient_Doctor.Models;

namespace _10_Patient_Doctor.Extensions;

static class HospitalHelper
{
    public static void DisplayAllAppointmentInfo(this List<Appointment> appointments)
    {
        if (appointments.Count == 0)
            throw new HospitalException("There is no appointments to display !");

        appointments.ForEach(ap => ap.DisplayInfo());
    }
}
