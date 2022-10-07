using Domain.Model;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceConnect.DepartmentConnects
{
    internal class DepartmentEmployeeConnect :
        IServiceConnectAdd<Department, Employee>,
        IServiceConnectDelete<Department, Employee>,
        IServiceConnectRead<Department, Employee>
    {
        readonly BaseService<Department> departemtnService;
        readonly BaseService<Employee> employeeService;

        public DepartmentEmployeeConnect(BaseService<Department> departemtnService,
            BaseService<Employee> employeeService)
        {
            this.departemtnService = departemtnService;
            this.employeeService = employeeService;
        }

        public void Add(int parentId, Employee entity)
        {
            Department department = departemtnService.Get(parentId);

            entity.Department = department;

            employeeService.Create(entity);
        }

        public void Delete(int parentId, int chieldId)
        {
            Employee employee = employeeService.Get(chieldId);

            employee.Department = null;

            employeeService.Update(employee);       
        }

        public Employee Get(int parentId, int chieldId)
            => departemtnService.Get(parentId).employees.Where(e => e.DepartmentId == chieldId).Single();

        public IEnumerable<Employee> GetAll(int parentId)
            => departemtnService.Get(parentId).employees;
    }
}
