﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Waikato_University.Models
{
    public class Lacturer
    {
        //Primary key.
        public int Id { get; set; }

        //Lecturer name.
        [Required]
        public string Name { get; set; }

        //Lecturer email.
        public string Email { get; set; }
    }
}
