namespace Service.Test
{
    public class EmployeeServiceTest
    {
        ApplicationDbContext dbContext;
        [SetUp]
        public void Setup()
        {
            dbContext = new ApplicationDbContextFactory().CreateDbContext("EmployeeService");
        }
        
        public class CancelExpense
        {
            [Test]
            public void When_ExpenseNotConfirm_Should_Delet()
            {

            }
            [Test]
            public void When_ExpenseConfirm_Should_NotDelet()
            {

            }
        }

        public class EditExpense
        {
            [Test]
            public void When_ExpenseNotConfirm_Should_Edit()
            {

            }
            [Test]
            public void When_ExpenseConfirm_Should_NotEdit()
            {

            }
        }

        public class GetAllExpenses
        {
            [Test]
            public void Should_GetOwnedExpense()
            {

            }
        }
    }
}