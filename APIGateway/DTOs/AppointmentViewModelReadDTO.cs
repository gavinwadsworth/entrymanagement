using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.DTOs
{
    public class AppointmentViewModelReadDTO
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public string VisitorFullName { get; set; }
        public string EmployeeFullName { get; set; }
        public int VisitorId { get; set; }
        public int EmployeeId { get; set; }
    }
}
