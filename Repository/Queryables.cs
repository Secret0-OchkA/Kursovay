using Domain.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Queryable.Queryable
{
    public static class Queryables 
    {
        public static Company? Company(this IQueryable<Company> companies, int companyId)
            => companies.Where(c => c.Id == companyId).SingleOrDefault();
        public static IQueryable<Department> ByCompany(this IQueryable<Department> departments, int companyId)
            => departments.Where(d => d.CompanyId == companyId);
        public static IQueryable<Employee> ByCompany(this IQueryable<Employee> employees, int companyId)
            => employees.Where(e => e.Department != null && e.Department.CompanyId == companyId);
        public static IQueryable<Expense> ByCompany(this IQueryable<Expense> expenses, int companyId)
            => expenses.Where(ex => ex.department.CompanyId == companyId);
        public static IQueryable<ExpenseType> ByCompany(this IQueryable<ExpenseType> expenseTypes, int companyId)
            => expenseTypes.Where(ext => ext.CompanyId == companyId);

        public static Department? Department(this IQueryable<Department> departments, int departmentId)
            => departments.Where(d => d.Id == departmentId).SingleOrDefault();
        public static IQueryable<Employee> ByDepartment(this IQueryable<Employee> employees, int departmentId)
            => employees.Where(e => e.Department != null && e.DepartmentId == departmentId);
        public static IQueryable<Expense> ByDepartment(this IQueryable<Expense> expenses, int departmentId)
            => expenses.Where(expenses => expenses.DepartmentId == departmentId);

        public static Employee? Employee(this IQueryable<Employee> employees, int employeeId)
            => employees.Where(e => e.Id == employeeId).SingleOrDefault();
        public static IQueryable<Expense> ByEmployee(this IQueryable<Expense> expenses, int employeeId)
            => expenses.Where(ex => ex.EmploeeId == employeeId);

        public static Expense? Expense(this IQueryable<Expense> expenses, int expenseId)
            => expenses.Where(ex => ex.Id == expenseId).SingleOrDefault();
    }
}
