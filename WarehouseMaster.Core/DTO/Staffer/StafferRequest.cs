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
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string MiddleName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string Role { get; set; } = string.Empty;
        [Required]
        public string Post { get; set; } = string.Empty;
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public int WarehouseId { get; set; }
    }
}
