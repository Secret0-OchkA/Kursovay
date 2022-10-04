using Domain.Model;
using Repository.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public void GetDepartment(int id) => throw new NotImplementedException();
        public void GetDepartments() => throw new NotImplementedException();

        public void AddDepartment(int id, Department entity) => throw new NotImplementedException();
        public void DeletDepartment(int departmentId) => throw new NotImplementedException();
    }
}
