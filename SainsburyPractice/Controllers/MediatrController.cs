using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SainsburyPractice.Domain.MediatRServices;
using SainsburyPractice.Domain.ViewModel;

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
            var list = await this.mediatR.Send(new EmployeeListCommand());

            return list == null || list.Count == 0 ? BadRequest() : Ok(list);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Employee(EmployeeViewModel model)
        {
            Guard.Against.Null(model, nameof(model));

            var message = await this.mediatR.Send(new AddEmployeeCommand(model));

            return message == null ? Ok("Employee added successfully") : BadRequest(message);
        }

        [HttpGet("details")]
        public async Task<IActionResult> Employee(int employeeId)
        {
            Guard.Against.Null(employeeId, nameof(employeeId));

            var details = await this.mediatR.Send(new GetEmployeeByIdCommand(employeeId));
            return details == null ? BadRequest() : Ok(details);
        }

    }
}
