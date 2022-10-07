using Domain.Model;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceConnect.DepartmentConnects
{
    internal class DepartmentExpenseConnect : IServiceConnectRead<Department, Expense>
    {
        readonly BaseService<Department> departmentService;

        public DepartmentExpenseConnect(BaseService<Department> departmentService)
        {
            this.departmentService = departmentService;
        }

        public Expense Get(int parentId, int chieldId)
            => departmentService.Get(parentId).Expenses.Where(ex => ex.Id == chieldId).Single();

        public IEnumerable<Expense> GetAll(int parentId)
            => departmentService.Get(parentId).Expenses;
    }
}
