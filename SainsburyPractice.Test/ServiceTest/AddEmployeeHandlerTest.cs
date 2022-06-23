using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using SainsburyPractice.Domain.Handler;
using SainsburyPractice.Domain.MediatRServices;
using SainsburyPractice.Interfaces; 

namespace SainsburyPractice.Test.ServiceTest
{
    public class AddEmployeeHandlerTest
    {
        private IFixture _fixture;
        private readonly Mock<IEmployeeRepository> employeeRepository;
        private readonly AddEmployeeHandler addEmployeeHandler;

        public AddEmployeeHandlerTest()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
            employeeRepository = _fixture.Freeze<Mock<IEmployeeRepository>>();
            addEmployeeHandler = new AddEmployeeHandler(employeeRepository.Object);
        }

        [Fact]
        public async Task AddEmployeeHandlerShouldCallHandlerAndReturnResponeNull()
        {
            //Arrange
            var model = _fixture.Create<IEmployee>();
            string response = null;
            employeeRepository.Setup(x => x.SaveEmployee(model)).ReturnsAsync(response);

            //Act 
            var result = await addEmployeeHandler.Handle(new AddEmployeeCommand(model), CancellationToken.None);

            //Assert
            result.Should().BeNull();
            employeeRepository.Verify(x => x.SaveEmployee(model), Times.Once());
        }

        [Fact]
        public async Task AddEmployeeHandlerShouldCallHandlerAndReturnResponseSuccessfully()
        {
            //Arrange
            var model = _fixture.Create<IEmployee>();
            string response = _fixture.Create<string>();
            employeeRepository.Setup(x => x.SaveEmployee(model)).ReturnsAsync(response);

            //Act
            var result = await addEmployeeHandler.Handle(new AddEmployeeCommand(model), CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<string>();
            employeeRepository.Verify(x =>x.SaveEmployee(model), Times.Once());
        }

    }
}
