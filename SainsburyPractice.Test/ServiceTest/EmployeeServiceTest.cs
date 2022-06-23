using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using SainsburyPractice.Domain.Services;
using SainsburyPractice.Domain.ViewModel;
using SainsburyPractice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SainsburyPractice.Test.ServiceTest
{
    public class EmployeeServiceTest
    {
        private IFixture _fixture;
        private readonly Mock<IEmployeeRepository> employeeRepository;
        private readonly EmployeeServices employeeServices;

        public EmployeeServiceTest()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
            employeeRepository = _fixture.Freeze<Mock<IEmployeeRepository>>();
            employeeServices = new EmployeeServices(employeeRepository.Object);
        }

        [Fact]
        public async Task AddEmployeeShouldCallSaveEmployeeAndReturnModel()
        {
            //Arrange
            var model = _fixture.Create<IEmployee>();
            string? message = null; 
            employeeRepository.Setup(x => x.SaveEmployee(model)).ReturnsAsync(message);

            //Act
            var result = await employeeServices.AddEmployee(model); 

            //Assert 
            result.Should().BeNull();
            result.Should().BeEquivalentTo(null);
            employeeRepository.Verify(x => x.SaveEmployee(model), Times.Once());
        }

        [Fact]
        public async Task GetEmployeeByIdShoulCallFetchEmployeeByIdAndReurnModel()
        {
            //Arrange
            int employeeId = _fixture.Create<int>();
            var model = _fixture.Create<IEmployee>();
            employeeRepository.Setup(x => x.FetchEmployeeById(employeeId)).ReturnsAsync(model);

            //Act
            var result = await employeeServices.GetEmployeeById(employeeId);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IEmployee>();
            employeeRepository.Setup(x => x.FetchEmployeeById(employeeId));

        }

        [Fact]
        public async Task GetEmployeeListShouldCallGetEmployeeListAndReturnModel()
        {
            var model = _fixture.Create<IList<IEmployee>>();
            employeeRepository.Setup(x => x.FetchEmployeeList()).ReturnsAsync(model);

            //Act
            var result = await employeeServices.GetEmployeeList();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IList<IEmployee>>();
            employeeRepository.Verify(x => x.FetchEmployeeList(), Times.Once());
        }
    }
}
