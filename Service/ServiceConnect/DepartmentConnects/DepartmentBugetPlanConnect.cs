using Domain.Model;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceConnect.DepartmentConnects
{
    internal class DepartmentBugetPlanConnect :
        IServiceConnectRead<Department, BugetPlan>,
        IServiceConnectAdd<Department, BugetPlan>,
        IServiceConnectDelete<Department, BugetPlan>
    {
        readonly BaseService<Department> departmentService;
        readonly BaseService<BugetPlan> bugetPlanService;

        public DepartmentBugetPlanConnect(BaseService<Department> departmentService, BaseService<BugetPlan> bugetPlanService)
        {
            this.departmentService = departmentService;
            this.bugetPlanService = bugetPlanService;
        }

        public void Add(int parentId, BugetPlan entity)
        {
            Department department = departmentService.Get(parentId);

            department.bugetPlan = entity;

            departmentService.Update(department);          
        }

        public void Delete(int parentId, int chieldId)
        {
            bugetPlanService.Delete(chieldId);
        }

        public BugetPlan Get(int parentId, int chieldId)
            => departmentService.Get(parentId).bugetPlan;

        public IEnumerable<BugetPlan> GetAll(int parentId)
            => new List<BugetPlan> { departmentService.Get(parentId).bugetPlan };
    }
}
