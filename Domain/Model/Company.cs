﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Company : BaseDbEntity
    {
        public string Name { get; set; } = string.Empty;
        
        public virtual List<Department> departments { get; set; } = new List<Department>();
    }
}
