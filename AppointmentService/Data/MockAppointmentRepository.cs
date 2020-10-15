using AppointmentService.Models;
using System;
using System.Collections.Generic;

namespace AppointmentService.Data
{
    public class MockAppointmentRepository : IAppointmentRepository
    {
        public void CreatAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public void DeleteAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Appointment GetAppointment(int id)
        {
            return new Appointment { Id = 0, Title = "Mock Test Meeting 1", StartTime = new DateTime(2020, 9, 4,10,00,00), FinishTime = new DateTime(2020, 9, 4, 11, 00, 00), EmployeeId = 1 };
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            var appointments = new List<Appointment>
            {
                new Appointment { Id = 0, Title = "Mock Test Meeting 1", StartTime = new DateTime(2020, 9, 4,10,00,00), FinishTime = new DateTime(2020, 9, 4, 11, 00, 00), EmployeeId = 1 },
                new Appointment { Id = 1, Title = "Mock Test Meeting 2", StartTime = new DateTime(2020, 9, 14,10,00,00), FinishTime = new DateTime(2020, 9, 4, 11, 00, 00), EmployeeId = 2 },
                new Appointment { Id = 2, Title = "Mock Test Meeting 3", StartTime = new DateTime(2020, 9, 24,10,00,00), FinishTime = new DateTime(2020, 9, 4, 11, 00, 00), EmployeeId = 3 }
            };
            return appointments;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
