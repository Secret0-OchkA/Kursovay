using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmployeeService : IServiceToEntity<Employee>
    {
        public ExpenseService CreateExpense() => throw new NotImplementedException();

        public IEnumerable<ExpenseService> GetExpenses() => throw new NotImplementedException();
        //if not confirm
        public void DeleteExpense() => throw new NotImplementedException();


        public void ChangeRoleEmploey() => throw new NotImplementedException();

        public DepartmentService GetDepartment() => throw new NotImplementedException();

        public Employee GetEntity()
        {
            throw new NotImplementedException();
        }
    }
}
