using SainsburyPractice.Interfaces;
using SainsburyPractice.Repository.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SainsburyPractice.Repository.Mapper
{
    public static class EmployeeMapper
    {

        public static IEmployee EmployeeListModelObj(this Employee model)
        {
            return new EmployeeModel
            { 
                Name = model.Name,
                Details = model.Details,
                DateCreated = model.DateCreated,
                IsValid = model.IsValid,
                DateInActive = model.DateInActive,
                EmployeeId = model.EmployeeId
            };
        }


        public static Employee EmployeeModelObj(this IEmployee model)
        {
            return new Employee
            {
                Name = model.Name,
                Details = model.Details,
                DateCreated = DateTime.Now,
                IsValid = model.IsValid,
                DateInActive = model.DateInActive,
                EmployeeId = model.EmployeeId
            };
        }
    }
}
