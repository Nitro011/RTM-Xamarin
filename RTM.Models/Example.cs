﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models
{
    public class Example
    {
        [Key]
        public int Id { get; set; }

        public string Texto { get; set; }
    }
}
