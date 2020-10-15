using APIGateway.DTOs;
using APIGateway.Models;
using AutoMapper;


namespace APIGateway.Profiles
{
    public class AppointmentViewModelProfile : Profile
    {
        public AppointmentViewModelProfile()
        {
            CreateMap<Appointment,AppointmentViewModelReadDTO>();
        }
    }
}
