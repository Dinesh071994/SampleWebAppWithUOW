using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataAccess.Repository.Interface;
using WebApplication1.Models;

namespace WebApplication1.DataAccess.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly EmployeeDbContext _libraryDbContext;

        public EmployeeRepository(EmployeeDbContext libraryDbContext) :base(libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
    }
}
