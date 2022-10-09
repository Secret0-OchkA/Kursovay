﻿namespace Domain.Model
{
    public class Expense : BaseDbEntity
    {
        public bool Confirm { get; set; } = false;
        public bool Valid { get; set; } = false;

        //[JsonIgnore]
        public int ExpenseTypeId { get; set; }
        //[Required]
        public virtual ExpenseType expenseType { get; set; } = null!;

        public DateTime date { get; set; }
        public decimal amount { get; set; }

        //[JsonIgnore]
        public int DepartmentId { get; set; }
        //[Required]
        public virtual Department department { get; set; } = null!;

        //[JsonIgnore]
        public int EmploeeId { get; set; }
        public virtual Employee? employee { get; set; }
    }
}
