using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.BL.DTOModels
{
    public class DepartmentDTO : EntityDTO
    {
        [Required]
        public string Name { get; set; }
        public EmployeeDTO? Employees { get; set; }
    }
}
