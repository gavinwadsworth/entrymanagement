//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace AppointmentService.Models
//{
//    public class VisitorAppointment
//    {
//        public VisitorAppointment()
//        {
//            Appointments = new List<Appointment>();
//        }
//        public int Id { get; set; }
//        [Required]
//        public int VisitorId { get; set; }
//        public DateTime? VisitorSignIn { get; set; }
//        public DateTime? VisitorSignOut { get; set; }
//        public List<Appointment> Appointments { get; set; }
//    }
//}
