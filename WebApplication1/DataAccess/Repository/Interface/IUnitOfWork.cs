using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DataAccess.Repository.Interface
{
    public interface IUnitOfWork
    {
        IEmployeeRepository employeeRepository { get; }
        void Save();

        Task SaveAsync();
    }
}
