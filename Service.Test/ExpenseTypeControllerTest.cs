using Api.Test.Infrastructura;
using DockerTestBD.Api.Controllers;
using Domain.ApiModel;
using Domain.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Api.Test
{
    class ExpenseTypeControllerTest
    {
        ApplicationDbContextTest dbContext;
        ExpenseTypeController controller;
        [SetUp]
        public void Setup()
        {
            this.dbContext = new ApplicationDbContextFactory().CreateDbContext("Database");
            controller = new ExpenseTypeController(dbContext);
        }

        [Test]
        public void GetById_Should_BadRequest_When_NotExistCompany()
        {
            var result = controller.Get(-1,1);
            Assert.IsNotNull(result);
            Assert.That(result is BadRequestObjectResult);
        }
        [Test]
        public void GetById_Should_BadRequest_When_NotExistExpenseType()
        {
            var result = controller.Get(1, -1);
            Assert.IsNotNull(result);
            Assert.That(result is BadRequestObjectResult);
        }
        [Test]
        public void DeletById_Should_BadRequest_When_NotExistCompany()
        {
            var result = controller.Delet(-1, 1);
            Assert.IsNotNull(result);
            Assert.That(result is BadRequestObjectResult);
        }
        [Test]
        public void DeletById_Should_BadRequest_When_NotExistExpenseType()
        {
            var result = controller.Delet(1, -1);
            Assert.IsNotNull(result);
            Assert.That(result is BadRequestObjectResult);
        }
        [Test]
        public void Update_Should_BadRequest_When_NotExistCompany() 
        {
            ExpenseTypeView expenseType = new ExpenseTypeView();
            expenseType.Limit = 10;

            var result = controller.Update(-1, 1, expenseType);
            Assert.IsNotNull(result);
            Assert.That(result is BadRequestObjectResult);
        }
        [Test]
        public void Update_Should_BadRequest_When_NotExistExpenseType()
        {
            ExpenseTypeView expenseType = new ExpenseTypeView();
            expenseType.Limit = 10;

            var result = controller.Update(1, -1, expenseType);
            Assert.IsNotNull(result);
            Assert.That(result is BadRequestObjectResult);
        }
        [Test]
        public void Update_Should_BadRequest_When_LimitLessOrEqualZero()
        {
            ExpenseTypeView expenseType = new ExpenseTypeView();
            expenseType.Limit = -10;

            var result = controller.Update(1, 1, expenseType);
            Assert.IsNotNull(result);
            Assert.That(result is BadRequestObjectResult);
        }

    }
}
