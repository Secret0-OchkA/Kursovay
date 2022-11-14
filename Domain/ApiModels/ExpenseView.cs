using Domain.ApiModel;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ApiModels
{
    public class ExpenseView : BaseViewEntity
    {
        public bool Confirm { get; set; } = false;
        public bool Valid { get; set; } = false;

        public DateTime date { get; set; } = DateTime.Now;
        public decimal amount { get; set; } = 0;

        public int expenseTypeId { get; set; } = 0;

        public ExpenseView() { }
        public ExpenseView(Expense expense) : base(expense)
        {
            this.Confirm = expense.Confirm;
            this.Valid = expense.Valid;
            this.date = expense.date;
            this.amount = expense.amount;

            this.expenseTypeId = expense.ExpenseTypeId;
        }
    }
}
