using System;

namespace KioskSPA.Models
{
    public class AppointmentViewModel
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public string EmployeeFullName { get; set; }
    }
}
