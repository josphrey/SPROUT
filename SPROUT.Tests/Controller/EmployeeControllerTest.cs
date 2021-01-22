
namespace SPROUT.Tests.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.AspNetCore.Mvc;
    using Xunit;
    using Moq;
    using System.Net.Http;

    using SPROUT.Controllers;
    using SPROUT.Models;
    using SPROUT.Services;
    using SPROUT.Entities;

    public class EmployeeControllerTest
    {
        [Fact]
        public void Index_Get_WithListOfAllEmployee()
        {
            // Arrange
            var repository = lstEmployee();
            var mockrepo = new Mock<IEmployeeService>();
            mockrepo.Setup(x => x.GetAllEmployee()).Returns(repository);
            var controller = new EmployeeController(mockrepo.Object);

            // Act 
            var result = controller.Index() as ViewResult;
            var model = result.Model as List<EmployeeViewModel>;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(6, model.Count());
        }

        [Fact]
        public void Salary_Get_EmployeeDetails()
        {
            // Arrange
            var repository = lstEmployee().Find(x => x.Id == 1);
            var mockrepo = new Mock<IEmployeeService>();
            mockrepo.Setup(x => x.GetEmployeeById(1)).Returns(repository);
            var controller = new EmployeeController(mockrepo.Object);
            // Act 
            var result = controller.Salary(1) as ViewResult;
            var model = result.Model as EmployeeViewModel;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("John Koenig", model.Name);
        }

        [Fact]
        public void Create_Get_ReturnsView()
        {
            // Arrange
            var mockrepo = new Mock<IEmployeeService>();
            var controller = new EmployeeController(mockrepo.Object);

            // Act 
            var result = controller.Create();

            // Assert
            Assert.NotNull(result as ViewResult);
        }

      

        private List<EmployeeViewModel> lstEmployee()
        {
            var lst = new List<EmployeeViewModel>
            {
                new EmployeeViewModel() { Id=1, Name="John Koenig", Birthday = new DateTime(1975, 10, 17), Tin=10001, EmployeeType="Regular"  },
                new EmployeeViewModel() { Id=2, Name="Joseph", Birthday = new DateTime(1988, 08, 29), Tin=10002, EmployeeType="Regular" },
                new EmployeeViewModel() { Id=3, Name="Dylan Hunt", Birthday = new DateTime(2000, 10, 2), Tin=10003, EmployeeType="Regular" },
                new EmployeeViewModel() { Id=4, Name="Leela Turanga", Birthday = new DateTime(1999, 3, 28), Tin=10004, EmployeeType="Regular" },
                new EmployeeViewModel() { Id=5, Name="John Crichton", Birthday = new DateTime(1999, 3, 19), Tin=10005, EmployeeType="Contractual" },
                new EmployeeViewModel() { Id=6, Name="Dave Lister", Birthday = new DateTime(1988, 2, 15), Tin =10006, EmployeeType="Contractual" },
            };
            return lst;
        }
    }
}
