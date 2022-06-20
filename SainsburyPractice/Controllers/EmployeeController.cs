using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SainsburyPractice.Domain.ViewModel;
using SainsburyPractice.Interfaces;

namespace SainsburyPractice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices employeeServices;
        public EmployeeController(IEmployeeServices employeeServices)
        {
            this.employeeServices = Guard.Against.Null(employeeServices, nameof(employeeServices));
        }


        [HttpGet]
        public async Task<IActionResult> Employee()
        {
            var list = await this.employeeServices.GetEmployeeList();

            return list == null || list.Count == 0  ? BadRequest() : Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Employee(EmployeeViewModel model)
        {
            Guard.Against.Null(model, nameof(model));
            var message = await this.employeeServices.AddEmployee(model);

            return message == null ? Ok() : BadRequest(message);
        }

        [HttpGet]
        public async Task<IActionResult> SingleEmployee(int employeeId)
        {
            Guard.Against.Null(employeeId, nameof(employeeId));
            var single = await this.employeeServices.GetEmployeeById(employeeId);

            return single == null ? BadRequest() : Ok(single);
        }
    }
}
