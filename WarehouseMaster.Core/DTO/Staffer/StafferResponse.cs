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
        public int AccountId { get; set; }
        public string Post { get; set; } = string.Empty;
        public int WorkExperience { get; set; }
        public int AccessLevel { get; set; }
        public decimal Salary { get; set; }
        public string QRCode { get; set; } = string.Empty;
    }
}
