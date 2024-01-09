using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMaster.Core.DTO.Staffer
{
    public class StafferRequest
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        public string Post { get; set; } = string.Empty;
        [Required]
        public int WorkExperience { get; set; }
        public int AccessLevel { get; set; }
        [Required]
        public decimal Salary { get; set; }
    }
}
