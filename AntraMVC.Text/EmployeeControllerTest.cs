using AntraMVC.Controllers;
using AntraMVC.Models.Domain;
using AntraMVC.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AntraMVC.Text
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private readonly Mock<IEmployeeService> _mockEmployeeSerive;
        private readonly EmployeeController _accountController;
        EmployeeControllerTest(EmployeeController accountController, Mock<IEmployeeService> mockEmployeeSerive)
        {
            _mockEmployeeSerive = mockEmployeeSerive;
            _accountController = new EmployeeController(_mockEmployeeSerive.Object);
        }

        [TestMethod]
        public async Task Index_ReturnEmployees()
        {
            //Arrange
            var mockEmployees = new List<Employee>()
            {
                new Employee
                {
                    Name="FFFFF",StartDate=DateTime.Now,Age=20,Desciption="good"
                }
            };
            _mockEmployeeSerive.Setup(serivce => serivce.GetAllEmployees()).ReturnsAsync(mockEmployees);

            //Act
            var result = await _accountController.Index();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
