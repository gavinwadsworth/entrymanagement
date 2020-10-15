using AppointmentService.DTOs;
using AppointmentService.Models;
using AutoMapper;

namespace AppointmentService.Profiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, AppointmentReadDTO>();
            CreateMap<AppointmentCreateDTO, Appointment>();
            CreateMap<AppointmentUpdateDTO, Appointment>();
            CreateMap<Appointment, AppointmentUpdateDTO>();
            //CreateMap<VisitorAppointment, AppointmentDetailReadDTO>();
            //CreateMap<Appointment, AppointmentDetailReadDTO>();
        }
    }
}
