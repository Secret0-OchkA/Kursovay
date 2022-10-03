using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Test
{
    internal class DepartmentServiceTest
    {
        ApplicationDbContext dbContext;
        [SetUp]
        public void Setup()
        {
            dbContext = new ApplicationDbContextFactory().CreateDbContext("DepartmentService");
        }

        public class AddEmployee
        {
            [Test]
            public void When_EmployeeAdded_Should_NotAdd()
            {

            }
            [Test]
            public void When_EmployeeInOtherDepartmetn_Should_NotAdd()
            {

            }
        }
        public class EditBuget
        {
            [Test]
            public void When_SetBugetSigned_Should_Cancel()
            {

            }
        }
        public class EditBugetPlan
        {
            [Test]
            public void When_SetBugetSigned_Should_Cancel()
            {

            }
        }
    }
}
