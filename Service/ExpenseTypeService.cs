using Domain.Model;
using Repository.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ExpenseTypeService : BaseService<ExpenseType>
    {
        public ExpenseTypeService(IRepository<ExpenseType> repository) : base(repository) { }

        public void ChangeName(int id, string name)
        {
            ExpenseType employee = Get(id);
            if (employee.Name == name) return;

            employee.Name = name;
            repository.SaveChange();
        }

        public void ChangeDescription(int id, string description)
        {
            ExpenseType employee = Get(id);
            if (employee.Description == description) return;

            employee.Description = description;
            repository.SaveChange();
        }

        public void ChangeLimit(int id, decimal limit)
        {
            ExpenseType employee = Get(id);

            if (employee.Limit <= 0) throw new ArgumentException();

            if (employee.Limit == limit) return;

            employee.Limit = limit;
            repository.SaveChange();
        }
    }
}
