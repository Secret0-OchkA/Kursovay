using Api.Test.Infrastructura;
using DockerTestBD.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Test
{
    class EmployeeControllerTest
    {
        ApplicationDbContextTest dbContext;
        EmployeeController controller;
        [SetUp]
        public void Setup()
        {
            this.dbContext = new ApplicationDbContextFactory().CreateDbContext("Database");
            controller = new EmployeeController(dbContext);
        }

        [Test]
        public void GetById_Should_BadRequest_When_NotExistEmployee()
        {
            var result = controller.Get(-1);
            Assert.IsNotNull(result);
            Assert.That(result is BadRequestObjectResult);
        }
        [Test]
        public void DeleteById_Should_BadRequest_When_NotExistEmployee()
        {
            var result = controller.Delete(-1);
            Assert.IsNotNull(result);
            Assert.That(result is BadRequestObjectResult);
        }
    }
}
