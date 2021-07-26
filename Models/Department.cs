using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Waikato_University.Models
{
    public class Department
    {

        //Primary key.
        public int Id { get; set; }

        //Department name.
        [Required]
        public string Name { get; set; }

        //Department email.
        public string DepartmentEmail { get; set; }
    }
}
