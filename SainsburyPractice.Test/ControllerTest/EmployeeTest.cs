using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SainsburyPractice.Controllers;
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
        public async Task Employee_ShouldReturnNull_IfNo()
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
        public async Task Employee_ShouldReturnBadRequest_WhenModelIsNull()
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
    }
}
