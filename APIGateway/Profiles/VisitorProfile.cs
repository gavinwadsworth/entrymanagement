using APIGateway.DTOs;
using APIGateway.Models;
using AutoMapper;

namespace APIGateway.Profiles
{
    public class VisitorProfile : Profile
    {
        public VisitorProfile()
        {
            CreateMap<Visitor, VisitorReadDTO>();
        }
    }
}
