using Domain.Model;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceConnect.ExpenseTypeConnects
{
    internal class ExpenseTypeExpenseConnect : IServiceConnectRead<ExpenseType, Expense>
    {
        readonly BaseService<ExpenseType> expenseTypeService;

        public ExpenseTypeExpenseConnect(BaseService<ExpenseType> expenseTypeService)
        {
            this.expenseTypeService = expenseTypeService;
        }

        public Expense Get(int parentId)
            => expenseTypeService.Get(parentId).Expenses.FirstOrDefault(new Expense());

        public IEnumerable<Expense> GetAll(int parentId)
            => expenseTypeService.Get(parentId).Expenses;
    }
}
