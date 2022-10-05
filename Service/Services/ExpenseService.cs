using Domain.Model;
using Repository.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ExpenseService : BaseService<Expense>
    {
        public ExpenseService(IRepository<Expense> repository) : base(repository) { }

        public void ConfirmExpense(int id)
        {
            Expense expense = Get(id);

            if (!expense.Valid) return;

            expense.Confirm = true;
            repository.SaveChange();
        }

        public void ValidateExpense(int id)
        {
            Expense expense = Get(id);

            expense.Valid = true;
            repository.SaveChange();
        }

        public void ChangeAmmountExpense(int id, decimal amount)
        {
            Expense expense = Get(id);

            if (expense.Confirm) throw new InvalidOperationException();

            expense.Valid = false;
            expense.amount = amount;
            expense.date = DateTime.Now;

            repository.SaveChange();
        }

        public void ChangeExpenseType(int Id, ExpenseType expenseType)
        {
            Expense expense = Get(Id);

            expense.expenseType = expenseType;
            repository.Update(expense);
            repository.SaveChange();
        }
    }
}
