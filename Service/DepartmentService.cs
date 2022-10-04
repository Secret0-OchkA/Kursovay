using Domain.Model;
using Repository.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DepartmentService : BaseService<Department>
    {
        public DepartmentService(IRepository<Department> repository) : base(repository) { }

        public void SetBuget(int id, decimal buget)
        {
            Department department = Get(id);

            if (buget < 0) throw new ArgumentException();

            department.budget = buget;
            repository.SaveChange();
        }


        public void GetEmployees() => throw new NotImplementedException();
        public void GetEmployees(int id) => throw new NotImplementedException();

        public void RemoveEmployee(int id) => throw new NotImplementedException();
        public void AddEmployee(int id, Employee employee) => throw new NotImplementedException();


        public void CreatePlan() => throw new NotImplementedException();
        public void DeletePlan() => throw new NotImplementedException();

        public void ChangePlane() => throw new NotImplementedException();
    }
}
