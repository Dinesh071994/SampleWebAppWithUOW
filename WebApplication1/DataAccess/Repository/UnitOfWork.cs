using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataAccess.Repository.Interface;

namespace WebApplication1.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeDbContext _context;

        private readonly IEmployeeRepository _employeeRepository;

        public UnitOfWork(EmployeeDbContext context, IEmployeeRepository employeeRepository)
        {
            _context = context;
            _employeeRepository = employeeRepository;
        }

        public IEmployeeRepository employeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    throw new Exception("employee repo not initialized");
                }
                return _employeeRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
