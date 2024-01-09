using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMaster.Domain.Entities
{
    public class Category: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public List<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
        public Staffer Staffer { get; set; } = new Staffer();
        public int StafferId { get; set; }
    }
}
