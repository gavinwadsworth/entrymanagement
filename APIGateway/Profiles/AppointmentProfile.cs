using APIGateway.DTOs;
using APIGateway.Models;
using AutoMapper;

namespace APIGateway.Profiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, AppointmentReadDTO>();
        }
    }
}
