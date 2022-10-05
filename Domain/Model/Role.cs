using Domain.Model;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Role : BaseDbEntity
    {
        public string Name { get; set; } = string.Empty;

        public virtual List<Employee> users { get; set; } = new List<Employee>();
    }
}
