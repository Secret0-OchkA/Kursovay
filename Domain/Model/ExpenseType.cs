﻿namespace Domain.Model
{
    public class ExpenseType : BaseDbEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Limit { get; set; }
    }
}
