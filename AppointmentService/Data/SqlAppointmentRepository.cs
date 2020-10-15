using AppointmentService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppointmentService.Data
{
    public class SqlAppointmentRepository : IAppointmentRepository
    {
        private readonly AppointmentContext _context;

        public SqlAppointmentRepository(AppointmentContext context)
        {
            _context = context;
        }

        public void CreatAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment));
            }

            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void DeleteAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Appointment GetAppointment(int id)
        {
            return _context.Appointments.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _context.Appointments.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateAppointment(Appointment appointment)
        {
            // Not required.
        }
    }
}
