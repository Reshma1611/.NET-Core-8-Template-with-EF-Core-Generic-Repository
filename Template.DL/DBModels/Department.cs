using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.DL.DBModels
{
    public class Department : Entity
    {
        public string Name { get; set; }
        public virtual Employee Employees { get; set; }

    }

}
