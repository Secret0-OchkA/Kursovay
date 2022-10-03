using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ExpenseService : IServiceToEntity<Expense>
    {
        public void ConfirmExpense() => throw new NotImplementedException();

        public void ValidateExpense() => throw new NotImplementedException();

        public void ChangeAmmountExpense() => throw new NotImplementedException();

        public void DeleteExpense() => throw new NotImplementedException();

        public Expense GetEntity()
        {
            throw new NotImplementedException();
        }
    }
}
