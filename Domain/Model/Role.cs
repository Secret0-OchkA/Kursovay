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
        public virtual List<User> users { get; set; } = new List<User>();
    }
}
