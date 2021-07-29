using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services.Interface
{
   public interface IEmployeeService :IBaseService<Employee>
    {
        //if using predicate
        // var predicate = PredicateBuilder.True<Employee>();
        // predicate = predicate.And(x=>x.urproperty....);
    }
}
