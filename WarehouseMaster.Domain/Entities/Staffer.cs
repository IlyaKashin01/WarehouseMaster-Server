using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMaster.Domain.Entities
{
    public class Staffer: BaseEntity
    {
        public int AccountId { get; set; }
        public string Post {  get; set; } = string.Empty;
        public int WorkExperience { get; set; }
        public int AccessLevel { get; set; }
        public decimal Salary { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
