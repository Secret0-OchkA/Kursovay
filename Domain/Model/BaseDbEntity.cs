using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public abstract class BaseDbEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
