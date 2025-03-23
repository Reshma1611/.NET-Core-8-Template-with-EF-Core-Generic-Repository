using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Net;
using Template.BL.DTOModels;
using Template.BL.Repositories;
using Template.DL.DBModels;
using Template.DL;

namespace Template.BL.Services
{
    public class DepartmentService : IGenericInterface<DepartmentDTO>
    {
        private readonly IGenericRepository<Department> _applicationContext;
        private readonly IMapper _mapper;

        public DepartmentService(IGenericRepository<Department> applicationContext, IMapper mapper, ApplicationContext context)
        {
            _applicationContext = applicationContext;
            _mapper = mapper;
        }
        public async Task<ResponseData<List<DepartmentDTO>>> GetAllAsync()
        {
            List<Department> data = await _applicationContext.ReadAllAsync();
            List<DepartmentDTO> response = new List<DepartmentDTO>();
            response = _mapper.Map<List<DepartmentDTO>>(data);

            ResponseData<List<DepartmentDTO>> jsonResponse = new ResponseData<List<DepartmentDTO>>()
            {
                Message = "",
                Data = response,
                Status = (int)HttpStatusCode.OK
            };
            return jsonResponse;
        }
        public async Task<ResponseData<DepartmentDTO>> GetAsync(int id)
        {
            Department data = await _applicationContext.ReadAsync(id);
            DepartmentDTO response = new DepartmentDTO();
            response = _mapper.Map<DepartmentDTO>(data);

            ResponseData<DepartmentDTO> jsonResponse = new ResponseData<DepartmentDTO>()
            {
                Message = "",
                Data = response,
                Status = (int)HttpStatusCode.OK
            };
            return jsonResponse;

        }
        public async Task<ResponseData> CreateAsync(DepartmentDTO model)
        {
            var data = _mapper.Map<Department>(model);
            await _applicationContext.CreateAsync(data);
            return new ResponseData() { Message = "Department Created successfully", Status = (int)HttpStatusCode.Created };
        }
        public async Task<ResponseData> UpdateAsync(DepartmentDTO model, int id)
        {
            model.Id = id;
            var data = _mapper.Map<Department>(model);

            var msg = await _applicationContext.UpdateAsync(data, id);
            return new ResponseData() { Message = msg, Status = (int)HttpStatusCode.OK };
        }
        public async Task<ResponseData> DeleteAsync(int id)
        {
            var msg = await _applicationContext.DeleteAsync(id);
            return new ResponseData() { Message = msg, Status = (int)HttpStatusCode.OK };

        }
    }
}
