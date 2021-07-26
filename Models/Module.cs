using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Waikato_University.Models
{
    public class Module
    {
        public int Id { get; set; }

        //Module name .
        [Required]
        public string Name { get; set; }

        //Module credits.
        public int Credits { get; set; }
    }
}
