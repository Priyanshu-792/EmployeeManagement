using EmployeeManagement.DTOs;
using EmployeeManagement.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;


namespace EmployeeManagement.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
   

            CreateMap<Department, DepartmentDTO>().ReverseMap();
        }
    }
}
