using Domain.Model;
using Repository.RepositoryPattern;
using Service.ServiceConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DepartmentService : BaseService<Department>
    {
        public DepartmentService(IRepository<Department> repository) : base(repository) { }

        public void SetBuget(int id, decimal buget)
        {
            Department department = Get(id);

            if (buget < 0) throw new ArgumentException();

            department.budget = buget;
            repository.SaveChange();
        }

        #region Employees
        public Employee GetEmployee(int id, int employeeId, IServiceConnectRead<Department,Employee> employeeController)
            => employeeController.Get(id, employeeId);

        public IEnumerable<Employee> GetEmployees(int id, IServiceConnectRead<Department, Employee> employeeController)
            => employeeController.GetAll(id);

        public void RemoveEmployee(int id, int employeeId, IServiceConnectDelete<Department, Employee> employeeController)
            => employeeController.Delete(id, employeeId);

        public void AddEmployee(int id, Employee employee, IServiceConnectAdd<Department, Employee> employeeController) 
            => employeeController.Add(id, employee);
        #endregion

        #region BugetPlan
        public BugetPlan GetBugetPlan(int id, int budgetPlanId, IServiceConnectRead<Department, BugetPlan> bugetPlanController)
            => bugetPlanController.Get(id, budgetPlanId);

        public void CreatePlan(int id, BugetPlan bugetPlan, IServiceConnectAdd<Department, BugetPlan> bugetPlanController)
            => bugetPlanController.Add(id, bugetPlan);

        public void DeletePlan(int id, int bugetPlanId, IServiceConnectDelete<Department, BugetPlan> bugetPlanController)
            => bugetPlanController.Delete(id, bugetPlanId);
        #endregion

        #region Expense
        public void GetExpenses(int id, IServiceConnectRead<Department, Expense> expenseController)
            => expenseController.GetAll(id);
        public void GetExpense(int id, int expenseId, IServiceConnectRead<Department, Expense> expenseController)
            => expenseController.Get(id, expenseId);
        #endregion
    }
}
