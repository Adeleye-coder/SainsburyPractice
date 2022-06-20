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
    public class GetEmployeeListHandler : IRequestHandler<AddEmployeeCommand, IList<IEmployee>>
    {
        private readonly IEmployeeRepository employeeRepository;
        public GetEmployeeListHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<IList<IEmployee>> Handle(AddEmployeeCommand request,
        CancellationToken cancellationToken) => await this.employeeRepository.FetchEmployeeList();
    }
}
