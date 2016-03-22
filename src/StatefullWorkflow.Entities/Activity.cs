﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatefullWorkflow.Entities
{
    public class Activity : Entity<int>
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public Activity()
        {
        }
    }
}
