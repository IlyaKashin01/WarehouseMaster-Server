using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMaster.Domain.Entities
{
    public class SubCategory: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public Category Category { get; set; } = new Category();
        public int CategoryId { get; set; }
        public Staffer Staffer { get; set; } = new Staffer();
        public int StafferId {  get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
