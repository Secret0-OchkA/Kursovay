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
            throw new NotImplementedException();
        }

        public void Delete(int parentId, int chieldId)
        {
            throw new NotImplementedException();
        }

        public Expense Get(int parentId, int chieldId)
            => employeeService.Get(parentId).Expenses.Where(ex => ex.Id == chieldId).Single();

        public IEnumerable<Expense> GetAll(int parentId)
            => employeeService.Get(parentId).Expenses;
    }
}
