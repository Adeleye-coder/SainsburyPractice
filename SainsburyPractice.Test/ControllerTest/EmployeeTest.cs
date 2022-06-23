using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SainsburyPractice.Controllers;
using SainsburyPractice.Domain.ViewModel;
using SainsburyPractice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SainsburyPractice.Test.ControllerTest
{
    public class EmployeeTest
    {
        public IFixture _fixture;
        private readonly EmployeeController employeeController;
        private readonly Mock<IEmployeeServices> employeeServices;

        public EmployeeTest()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
            employeeServices = _fixture.Freeze<Mock<IEmployeeServices>>();
            employeeController = new EmployeeController(employeeServices.Object);
        }

        [Fact]
        public async Task EmployeeShouldCallGetEmployeeListAndReturnOkIfResponseIsNotNull()
        {
            //Arrange 
            var model = _fixture.Create<IList<IEmployee>>();
            employeeServices.Setup(x => x.GetEmployeeList()).ReturnsAsync(model);
              
            //Act
            var result = await employeeController.Employee();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            employeeServices.Verify(x => x.GetEmployeeList(), Times.Once());
        }

        [Fact]
        public async Task EmployeeShouldCallGetEmployeeListAndReturnBadRequestIfResponseIsNull()
        {
            //Arrange
            IList<IEmployee> employeeList = new List<IEmployee>(); 
            employeeServices.Setup(x => x.GetEmployeeList()).ReturnsAsync(employeeList);

            //Act
            var result = await employeeController.Employee();

            //Assert
            result.Should().NotBeNull(); 
            result.Should().BeAssignableTo<BadRequestResult>();
            employeeServices.Verify(x => x.GetEmployeeList(), Times.Once());
        }

        [Fact]
        public async Task EmployeeShouldCallAddEmployeeAndReturnOkIfResponseIsNull()
        {
            //Arrange
            string addEmployee = null;
            var model = _fixture.Create<EmployeeViewModel>();
            employeeServices.Setup(x => x.AddEmployee(model)).ReturnsAsync(addEmployee);


            //Act
           var result = await employeeController.Employee(model);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkResult>();
            employeeServices.Verify(x => x.AddEmployee(model), Times.Once());
        }


        [Fact]
        public async Task EmployeeShouldCallAddEmployeeAndReturnBadRequestIfResponseIsNotNull()
        {
            //Arrange
            string addEmployee = "Error";
            var model = _fixture.Create<EmployeeViewModel>();
            employeeServices.Setup(x => x.AddEmployee(model)).ReturnsAsync(addEmployee);

            //Act
            var result = await employeeController.Employee(model);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            employeeServices.Verify(x => x.AddEmployee(model), Times.Once());
        }

        [Fact]
        public async Task EmployeeShouldCallGetEmployeeByIdAndReturnOkIfResponseIsNotNull()
        {
            //Arrange
            int employeeId = _fixture.Create<int>();
            var model = _fixture.Create<IEmployee>();
            employeeServices.Setup(x => x.GetEmployeeById(employeeId)).ReturnsAsync(model);

            //Act
            var result = await employeeController.Employee(employeeId);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            employeeServices.Verify(x => x.GetEmployeeById(employeeId), Times.Once());
        }

        [Fact]
        public async Task EmployeeShouldCallGetEmployeeByIdAndReturnBadRequestIfResponseIsNull()
        {
            //Arrange
            int employeeId = _fixture.Create<int>();
            IEmployee? model = null;
            employeeServices.Setup(x => x.GetEmployeeById(employeeId)).ReturnsAsync(model);

            //Act
            var result = await employeeController.Employee(employeeId);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestResult>();
            employeeServices.Verify(x => x.GetEmployeeById(employeeId));
        }
    }
}
