using Domain.Model;
using Repository.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
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
    }
}
