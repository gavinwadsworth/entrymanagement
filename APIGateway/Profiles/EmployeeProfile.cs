using APIGateway.DTOs;
using APIGateway.Models;
using AutoMapper;

namespace APIGateway.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeReadDTO>();
        }
    }
}
