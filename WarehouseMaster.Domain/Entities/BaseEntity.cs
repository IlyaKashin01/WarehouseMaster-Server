﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMaster.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
