using System;
using System.Collections.Generic;

namespace SainsburyPractice.Repository.DataModel
{
    /// <summary>
    /// Test tables for sainsbury
    /// </summary>
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public string Details { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public bool IsValid { get; set; }
        public DateTime? DateInActive { get; set; }
    }
}
