using AutoMapper;
using Template.BL.DTOModels;

//using Template.BL.DTOModels;
using Template.DL.DBModels;

namespace Template.BL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<DepartmentDTO, Department>().ReverseMap(); 
            CreateMap<EmployeeDTO, Employee>().ReverseMap(); 
        }
    }
}
