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
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, string?>
    {
        private readonly IEmployeeRepository employeeRepository;
        public AddEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<string?> Handle(AddEmployeeCommand request,
      CancellationToken cancellationToken) 
        {
           return await this.employeeRepository.SaveEmployee(request.employee); 
        } 

    }
}
