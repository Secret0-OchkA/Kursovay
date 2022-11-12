using Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace Domain.ApiModel
{
    public class ExpenseView : BaseViewEntity
    {
        public bool Confirm { get; set; } = false;
        public bool Valid { get; set; } = false;

        public DateTime date { get; set; } = DateTime.Now;
        public decimal amount { get; set; } = 0;

        public int expenseTypeId = 0;

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
