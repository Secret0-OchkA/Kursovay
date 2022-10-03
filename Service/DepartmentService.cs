using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DepartmentService : IServiceToEntity<Department>
    {
        public IEnumerable<EmployeeService> GetEmployees() => throw new NotImplementedException();

        public EmployeeService AddEmployee() => throw new NotImplementedException();

        public void DeleteEmloyee() => throw new NotImplementedException();



        public BugetPlanService CreateBugetPlan() => throw new NotImplementedException();

        public BugetPlanService GetBugetPlan() => throw new NotImplementedException();

        public IEnumerable<ExpenseService> GetExpenses() => throw new NotImplementedException();


        public decimal GetBuget() => throw new NotImplementedException();

        public void EditBuget() => throw new NotImplementedException();

        public Department GetEntity()
        {
            throw new NotImplementedException();
        }
    }
}
