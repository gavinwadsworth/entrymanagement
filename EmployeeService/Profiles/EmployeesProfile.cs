using AutoMapper;
using EmployeeService.DTOs;
using EmployeeService.Models;

namespace EmployeeService.Profiles
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Employee, EmployeeReadDTO>();
            CreateMap<EmployeeCreateDTO, Employee>();
            CreateMap<EmployeeUpdateDTO, Employee>();
            CreateMap<Employee, EmployeeUpdateDTO>();
        }
    }
}
