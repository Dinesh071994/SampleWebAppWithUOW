using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataAccess.Repository.Interface;
using WebApplication1.Models;
using WebApplication1.Services.Interface;

namespace WebApplication1.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Employee> Create(Employee model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            var employeeList = await _unitOfWork.employeeRepository.GetAllAsync(false);
            return employeeList.ToList();
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> Update(Employee model)
        {
            throw new NotImplementedException();
        }
    }
}
