﻿using Domain.Model;
using Repository.RepositoryPattern;
using Service.ServiceConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EmployeeService : BaseService<Employee>
    {
        public EmployeeService(IRepository<Employee> repository) : base(repository) { }

        public void ChangeName(int id, string name)
        {
            Employee employee = Get(id);
            if (employee.Name == name) return;

            employee.Name = name;
            repository.SaveChange();
        }

        #region Expense
        public IEnumerable<Expense> GetExpenses(int id, IServiceConnectRead<Employee, Expense> expenseController)
            => expenseController.GetAll(id);
        public Expense GetExpense(int id, int expenseId, IServiceConnectRead<Employee, Expense> expenseController)
            => expenseController.Get(id, expenseId);

        public void AddExpense(int id, Expense entity, IServiceConnectAdd<Employee, Expense> expenseController)
            => expenseController.Add(id, entity);

        public void DeletExpense(int id, int expenseId, IServiceConnectDelete<Employee, Expense> expenseController)
            => expenseController.Delete(id, expenseId);
        #endregion

        public void ChangeRole(int id, Role role)
        {
            Employee employee = Get(id);
            employee.Role = role;
            repository.Update(employee);
            repository.SaveChange();
        }

        //public void ChangeRole(int id, Role role)
        //{
        //    Employee employee = Get(id);

        //    employee.Role = role;

        //    repository.Update(employee);
        //    repository.SaveChange();
        //}

        //public IEnumerable<Expense> GetExpenses(int id)
        //    => Get(id).Expenses;
        //public Expense GetExpense(int id, int expenseId)
        //    => Get(id).Expenses.Where(ex => ex.Id == expenseId).Single();

        //public void AddExpense(int id, Expense entity)
        //{
        //    Employee employee = Get(id);

        //    if (entity.EmploeeId != 0 && entity.EmploeeId != id) throw new ArgumentException();

        //    var res = from ex in employee.Expenses
        //              where ex.Id == entity.Id
        //              select ex;
        //    if (res.Count() > 0) throw new ArgumentException();

        //    employee.Expenses.Add(entity);
        //    repository.Update(employee);
        //    repository.SaveChange();
        //}
        //public void DeletExpense(int id, int expenseId, ExpenseService expenseService)
        //{
        //    Employee employee = Get(id);

        //    Expense expense = employee.Expenses.Where(d => d.Id == expenseId).Single();

        //    expenseService.Delete(expenseId);
        //}
    }
}
