﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Data.Repositories.Interfaces
{
    public interface ISubCategoryRepository: IBaseRepository<SubCategory>
    {
        Task<SubCategory?> GetByNameAsync(string name);
    }
}
