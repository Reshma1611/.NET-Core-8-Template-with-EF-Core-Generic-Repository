using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.DL.DBModels;

namespace Template.BL.DTOModels
{
    public class EmployeeDTO : EntityDTO
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentDTO Department { get; set; }
    }
}
