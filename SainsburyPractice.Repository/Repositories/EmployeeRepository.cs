using Microsoft.EntityFrameworkCore;
using SainsburyPractice.Interfaces;
using SainsburyPractice.Repository.DataModel;
using SainsburyPractice.Repository.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SainsburyPractice.Repository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SainsburysContext sainsburyContext;

        public EmployeeRepository(SainsburysContext sainsburyContext)
        {
            this.sainsburyContext = sainsburyContext;
        }

        public async Task<IList<IEmployee>> FetchEmployeeList()
        { 
          return  await this.sainsburyContext.Employees.Select(x => x.EmployeeListModelObj()).ToListAsync();
        }

        public async Task<string?> SaveEmployee(IEmployee model)
        {
            try
            {
                //Check if it already exist
                var existingDate = await sainsburyContext.Employees.Where(x => x.Name == model.Name).FirstOrDefaultAsync();

                if (existingDate != null) return "Employee Already exist with such name";

                await this.sainsburyContext.Employees.AddAsync(model.EmployeeModelObj());
                sainsburyContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return "Error Saving Employee" + ", message :" + ex.Message;
            }
            return null;
        }

        public async Task<IEmployee?> FetchEmployeeById(int employeeId)
        {
            return await this.sainsburyContext.Employees.Where(x => x.EmployeeId == employeeId).Select(y => y.EmployeeListModelObj()).FirstOrDefaultAsync();
        }
    }
}
