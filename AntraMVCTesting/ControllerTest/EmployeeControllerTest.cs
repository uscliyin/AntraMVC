using AntraMVC.Controllers;
using AntraMVC.Models.Domain;
using AntraMVC.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntraMVCTesting.ControllerTest
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private Mock<IEmployeeService> _mockEmployeeSerive;
        private EmployeeController _employeeController;

        [TestInitialize]
        public void SetUp()
        {
            _mockEmployeeSerive = new Mock<IEmployeeService>();
            _employeeController = new EmployeeController(_mockEmployeeSerive.Object);
        }
        //public EmployeeControllerTest()
        //{
        //    _mockEmployeeSerive = new Mock <IEmployeeService>();
        //    _employeeController = new EmployeeController(_mockEmployeeSerive.Object);
        //}

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
            var result = await _employeeController.Index();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
