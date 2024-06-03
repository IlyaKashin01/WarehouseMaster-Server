using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMaster.Domain.Entities
{
    public class Staffer: BaseEntity
    {
        public Person Person { get; set; } = new Person();
        public int PersonId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Post {  get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public decimal Salary { get; set; }
        public DateTime AddedDate { get; set; }
        public Warehouse Warehouse { get; set; } = new Warehouse();
        public int WarehouseId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public string QRCode { get; set; } = string.Empty;
    }
}
