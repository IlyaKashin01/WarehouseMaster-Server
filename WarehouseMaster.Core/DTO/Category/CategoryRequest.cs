﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMaster.Core.DTO.Category
{
    public class CategoryRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int StafferId { get; set; }
    }
}
