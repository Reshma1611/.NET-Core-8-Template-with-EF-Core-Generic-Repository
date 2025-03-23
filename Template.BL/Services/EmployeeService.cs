using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Template.BL.DTOModels;
using Template.BL.Repositories;
using Template.DL.DBModels;
using Template.DL;


namespace Template.BL.Services
{
    public class EmployeeService : IGenericInterface<EmployeeDTO>
    {
        private readonly IGenericRepository<Employee> _applicationContext;
        private readonly IMapper _mapper;

        public EmployeeService(IGenericRepository<Employee> applicationContext, IMapper mapper)
        {
            _applicationContext = applicationContext;
            _mapper = mapper;
        }
        public async Task<ResponseData<List<EmployeeDTO>>> GetAllAsync()
        {
            List<Employee> data = await _applicationContext.ReadAllAsync();
            List<EmployeeDTO> response = new List<EmployeeDTO>();
            response = _mapper.Map<List<EmployeeDTO>>(data);

            ResponseData<List<EmployeeDTO>> jsonResponse = new ResponseData<List<EmployeeDTO>>()
            {
                Message = "",
                Data = response,
                Status = (int)HttpStatusCode.OK
            };
            return jsonResponse;
        }
        public async Task<ResponseData<EmployeeDTO>> GetAsync(int id)
        {
            Employee data = await _applicationContext.ReadAsync(id);
            EmployeeDTO response = new EmployeeDTO();
            response = _mapper.Map<EmployeeDTO>(data);

            ResponseData<EmployeeDTO> jsonResponse = new ResponseData<EmployeeDTO>()
            {
                Message = "",
                Data = response,
                Status = (int)HttpStatusCode.OK
            };
            return jsonResponse;

        }
        public async Task<ResponseData> CreateAsync(EmployeeDTO model)
        {
            var data = _mapper.Map<Employee>(model);
            await _applicationContext.CreateAsync(data);
            return new ResponseData() { Message = "Employee Created successfully", Status = (int)HttpStatusCode.Created };
        }
        public async Task<ResponseData> UpdateAsync(EmployeeDTO model, int id)
        {
            model.Id = id;
            var data = _mapper.Map<Employee>(model);

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
