using Domain.Model;
using Repository.RepositoryPattern;
using Service.ServiceConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
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

        #region Department
        public Department GetDepartment(int id, int departmentId, IServiceConnectRead<Company, Department> departemtnController)
            => departemtnController.Get(id, departmentId);
        public IEnumerable<Department> GetDepartments(int id, IServiceConnectRead<Company, Department> departemtnController)
            => departemtnController.GetAll(id);

        public void AddDepartment(int id, Department entity, IServiceConnectAdd<Company, Department> departemtnController)
            => departemtnController.Add(id, entity);

        public void DeletDepartment(int id, int departmentId, IServiceConnectDelete<Company, Department> departemtnController)
            => departemtnController.Delete(id, departmentId);
        #endregion
    }
}
