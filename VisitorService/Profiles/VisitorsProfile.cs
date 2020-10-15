using AutoMapper;
using VisitorService.DTOs;
using VisitorService.Models;

namespace VisitorService.Profiles
{
    public class VisitorsProfile : Profile
    {
        public VisitorsProfile()
        {
            CreateMap<Visitor, VisitorReadDTO>();
            CreateMap<VisitorCreateDTO, Visitor>();
            CreateMap<VisitorUpdateDTO, Visitor>();
            CreateMap<Visitor, VisitorUpdateDTO>();
        }
    }
}
