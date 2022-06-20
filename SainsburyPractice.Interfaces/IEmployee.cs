using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SainsburyPractice.Interfaces
{
    public interface IEmployee
    {
         int EmployeeId { get; set; }
         string Name { get; set; }
         string Details { get; set; }
         DateTime DateCreated { get; set; }
         bool IsValid { get; set; }
         DateTime? DateInActive { get; set; }
    }
}
