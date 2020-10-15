using System;

namespace APIGateway.Models
{
    public class Appointment
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int EmployeeId { get; set; }
        public int VisitorId { get; set; }
    }
}
