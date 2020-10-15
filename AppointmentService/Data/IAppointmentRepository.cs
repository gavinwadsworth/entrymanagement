using AppointmentService.Models;
using System.Collections.Generic;

namespace AppointmentService.Data
{
    public interface IAppointmentRepository
    {
        bool SaveChanges();
        IEnumerable<Appointment> GetAppointments();
        Appointment GetAppointment(int id);
        void CreatAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(Appointment appointment);
    }
}
