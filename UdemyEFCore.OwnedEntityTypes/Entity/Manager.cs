﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.OwnedEntityTypes.Entity
{
    public class Manager
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public Person Person { get; set; }
    }
}
