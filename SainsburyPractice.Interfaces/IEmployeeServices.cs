using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SainsburyPractice.Interfaces
{
    public interface IEmployeeServices
    {
        Task<string?> AddEmployee(IEmployee model);
        Task<IEmployee?> GetEmployeeById(int employeeId);
        Task<IList<IEmployee>> GetEmployeeList();
    }
}
