﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Developer:IEntity
    {
        public int DeveloperId { get; set; }
        public string DeveloperName { get; set; }      
    }
}
