using Domain.Model;

namespace Context.Queryable
{
    public static class Queryables
    {
        public static T? GetObj<T>(this IQueryable<T> entityes, int id) where T : BaseDbEntity
            => entityes.Where(e => e.Id == id).SingleOrDefault();

        public static IQueryable<Department> ByCompany(this IQueryable<Department> departments, int companyId)
            => departments.Where(d => d.CompanyId == companyId);
        public static IQueryable<Employee> ByCompany(this IQueryable<Employee> employees, int companyId)
            => employees.Where(e => e.Department != null && e.Department.CompanyId == companyId);
        public static IQueryable<Expense> ByCompany(this IQueryable<Expense> expenses, int companyId)
            => expenses.Where(ex => ex.department.CompanyId == companyId);
        public static IQueryable<ExpenseType> ByCompany(this IQueryable<ExpenseType> expenseTypes, int companyId)
            => expenseTypes.Where(ext => ext.CompanyId == companyId);

        public static IQueryable<Employee> ByDepartment(this IQueryable<Employee> employees, int departmentId)
            => employees.Where(e => e.Department != null && e.DepartmentId == departmentId);
        public static IQueryable<Expense> ByDepartment(this IQueryable<Expense> expenses, int departmentId)
            => expenses.Where(expenses => expenses.DepartmentId == departmentId);

        public static IQueryable<Expense> ByEmployee(this IQueryable<Expense> expenses, int employeeId)
            => expenses.Where(ex => ex.EmploeeId == employeeId);

        public static IQueryable<BugetPlan> ByDepartment(this IQueryable<BugetPlan> bugetPlans, int departmentId)
            => bugetPlans.Where(bp => bp.DeparmentId == departmentId);
        public static IQueryable<BugetPlan> ByCompany(this IQueryable<BugetPlan> bugetPlans, int companyId)
            => bugetPlans.Where(bp => bp.Department.CompanyId == companyId);
    }
}
