using MediatR;
using SainsburyPractice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SainsburyPractice.Domain.MediatRServices
{
    public record GetEmployeeByIdCommand(int employeeId) : IRequest<IEmployee>
    {
    }
}
