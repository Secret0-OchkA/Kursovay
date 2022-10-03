using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Test
{
    internal class AccountantServiceTest
    {
        ApplicationDbContext dbContext;
        [SetUp]
        public void Setup()
        {
            dbContext = new ApplicationDbContextFactory().CreateDbContext("AccountantService");
        }

        class GetAllExpenses
        {
            [Test]
            public void When_ExistExpense_Should_ReturnThen()
            {

            }
            [Test]
            public void When_NotExistExpense_Should_ReturnNullObj()
            {

            }
        }

        class ConfirmExpense
        {
            [Test]
            public void When_ValidExpense_Sholud_Confirm()
            {

            }
            [Test]
            public void When_Ivalidexpense_Sholud_NotifyCanceled()
            {

            }
        }

        class ValidateExpense
        {
            [Test]
            public void When_Correct_ShouldValid()
            {

            }
            [Test]
            public void When_NotCorret_Shoule_NotifyCanceled()
            {

            }
        }

        class DeleteExpenses
        {
            [Test]
            public void When_ExpenseConfirmOrValid_Should_Delete()
            {

            }
        }
    }
}
