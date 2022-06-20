using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SainsburyPractice.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEmployee?> FetchEmployeeById(int employeeId);
        Task<string?> SaveEmployee(IEmployee model);
        Task<IList<IEmployee>> FetchEmployeeList();
    }
}
