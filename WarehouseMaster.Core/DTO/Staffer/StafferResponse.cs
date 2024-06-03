using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMaster.Core.DTO.Staffer
{
    public class StafferResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public string Role { get; set; } = string.Empty;
        public string Post { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
