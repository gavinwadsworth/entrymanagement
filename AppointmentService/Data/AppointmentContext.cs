using AppointmentService.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentService.Data
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base (options)
        {

        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        //public virtual DbSet<VisitorAppointment> VisitorAppointments { get; set; }
    }
}
