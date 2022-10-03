using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CompanyService : IServiceToEntity<Company>
    {
        public void ChangeName() => throw new NotImplementedException();


        public void DeleteCompany() => throw new NotImplementedException();


        public DepartmentService CreateDepartment() => throw new NotImplementedException();

        public IEnumerable<DepartmentService> GetDepartments() => throw new NotImplementedException();

        public void DeletDepartment() => throw new NotImplementedException();

        public Company GetEntity() => throw new NotImplementedException();
    }
}
