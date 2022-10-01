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

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}