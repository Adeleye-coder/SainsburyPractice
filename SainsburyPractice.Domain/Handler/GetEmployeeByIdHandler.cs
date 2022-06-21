using MediatR;
using SainsburyPractice.Domain.MediatRServices;
using SainsburyPractice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SainsburyPractice.Domain.Handler
{
    internal class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdCommand, IEmployee?>
    {
        private readonly IEmployeeRepository employeeRepository;
        public GetEmployeeByIdHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<IEmployee?> Handle(GetEmployeeByIdCommand request, 
            CancellationToken cancel)
        {
            return await this.employeeRepository.FetchEmployeeById(request.employeeId);
        }
    }
}
