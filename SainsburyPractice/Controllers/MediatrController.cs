using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SainsburyPractice.Domain.MediatRServices;

namespace SainsburyPractice.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MediatrController : ControllerBase
    {
        private readonly IMediator mediatR;

        public MediatrController(IMediator mediatR)
        {
            this.mediatR = Guard.Against.Null(mediatR , nameof(mediatR));
        }

        [HttpGet("list")]
        public async Task<IActionResult> Employee()
        {
            var list = await this.mediatR.Send(new AddEmployeeCommand());

            return list == null || list.Count == 0 ? BadRequest() : Ok(list);
        }

        //[HttpPost]
        //public async Task<IActionResult> Employee(EmployeeViewModel model)
        //{
        //    Guard.Against.Null(model, nameof(model));
        //    var message = await this.employeeServices.AddEmployee(model);

        //    return message == null ? Ok() : BadRequest(message);
        //}

        //[HttpGet]
        //public async Task<IActionResult> SingleEmployee(int employeeId)
        //{
        //    Guard.Against.Null(employeeId, nameof(employeeId));
        //    var single = await this.employeeServices.GetEmployeeById(employeeId);

        //    return single == null ? BadRequest() : Ok(single);
        //}

    }
}
