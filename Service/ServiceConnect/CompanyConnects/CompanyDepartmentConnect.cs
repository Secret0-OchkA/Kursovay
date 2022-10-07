using Domain.Model;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceConnect.CompanyConnects
{
    public class CompanyDepartmentConnect :
        IServiceConnectRead<Company, Department>,
        IServiceConnectAdd<Company, Department>,
        IServiceConnectDelete<Company, Department>
    {
        readonly BaseService<Company> companyService;
        readonly BaseService<Department> departemtnService;

        public CompanyDepartmentConnect(BaseService<Company> companyService,
            BaseService<Department> departemtnService)
        {
            this.companyService = companyService;
            this.departemtnService = departemtnService;
        }

        public void Add(int parentId, Department entity)
        {
            Company company = companyService.Get(entity.CompanyId);

            if (entity.CompanyId != 0 && entity.CompanyId != company.Id) throw new ArgumentException();

            entity.Company = company;
            entity.CompanyId = company.Id;

            departemtnService.Create(entity);
        }

        public void Delete(int parentId, int chieldId)
        {
            Company company = companyService.Get(parentId);
            Department department = company.departments.Where(d => d.Id == chieldId).Single();
            departemtnService.Delete(chieldId);
        }

        public Department Get(int parentId)
            => companyService.Get(parentId).departments.FirstOrDefault(new Department());

        public IEnumerable<Department> GetAll(int parentId)
            => companyService.Get(parentId).departments;
    }
}
