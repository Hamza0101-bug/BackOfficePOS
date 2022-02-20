﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public string? CategoryImage { get; set; }
        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public int ParantID { get; set; }
        public Branch Branch { get; set; }
        public int BranchID { get; set; }
        public bool Active { get; set; }

    }
}