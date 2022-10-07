using Domain.Model;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceConnect.EmployeeConnects
{
    internal class EmployeeExpenseConnect :
        IServiceConnectAdd<Employee, Expense>,
        IServiceConnectDelete<Employee, Expense>,
        IServiceConnectRead<Expense, Expense>
    {
        readonly BaseService<Employee> employeeService;
        readonly BaseService<Expense> expenseService;

        public EmployeeExpenseConnect(BaseService<Employee> employeeService,
            BaseService<Expense> expenseService)
        {
            this.employeeService = employeeService;
            this.expenseService = expenseService;
        }

        public void Add(int parentId, Expense entity)
        {
            Employee employee = employeeService.Get(parentId);

            if (employee.Department == null) throw new NullReferenceException();

            entity.employee = employee;
            entity.department = employee.Department;

            expenseService.Create(entity);
        }

        public void Delete(int parentId, int chieldId)
        {
            Expense expense = expenseService.Get(chieldId);

            if (expense.Confirm) throw new OperationCanceledException();

            expenseService.Delete(chieldId);
        }

        public Expense Get(int parentId)
            => employeeService.Get(parentId).Expenses.FirstOrDefault(new Expense());

        public IEnumerable<Expense> GetAll(int parentId)
            => employeeService.Get(parentId).Expenses;
    }
}
