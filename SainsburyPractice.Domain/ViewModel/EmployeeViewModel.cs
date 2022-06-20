using SainsburyPractice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SainsburyPractice.Domain.ViewModel
{
    public class EmployeeViewModel : IEmployee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public string Details { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public bool IsValid { get; set; }
        public DateTime? DateInActive { get; set; }
    }
}
