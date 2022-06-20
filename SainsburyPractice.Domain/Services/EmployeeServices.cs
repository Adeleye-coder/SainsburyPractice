using SainsburyPractice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SainsburyPractice.Domain.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<string?> AddEmployee(IEmployee model)
        {
            return await this.employeeRepository.SaveEmployee(model);
        }

        public async Task<IEmployee?> GetEmployeeById(int employeeId)
        {
            return await this.employeeRepository.FetchEmployeeById(employeeId);
        }


        public async Task<IList<IEmployee>> GetEmployeeList()
        {
            return await this.employeeRepository.FetchEmployeeList();
        }
    }
}
