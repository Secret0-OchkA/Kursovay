using Domain.Model;
using Repository.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CompanyService : BaseService<Company>
    {
        public CompanyService(IRepository<Company> repository) : base(repository) { }

        public void ChangeName(int id, string name)
        {
            Company company = Get(id);

            if (company.Name == name) return;
            
            repository.Update(company);
            repository.SaveChange();
        }


        public Department GetDepartment(int id, int departmentId)
        {
            Company company = Get(id);
            return company.departments.Where(d => d.Id == departmentId).Single();
        }
        public IEnumerable<Department> GetDepartments(int id)
        {
            return Get(id).departments;
        }

        public void AddDepartment(int id, Department entity)
        {
            Company company = Get(id);

            if(entity.CompanyId != 0 && entity.CompanyId != id) throw new ArgumentException();

            var res = from d in company.departments
                      where d.Name == entity.Name || d.Id == entity.Id
                      select d;
            if (res.Count() > 0) throw new ArgumentException();
        }
        public void DeletDepartment(int departmentId) => throw new NotImplementedException();
    }
}
