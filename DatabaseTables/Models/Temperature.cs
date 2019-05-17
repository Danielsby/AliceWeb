﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DatabaseTables.Models;
namespace DatabaseTables.Models
{
    public class Temperature
    {
        [Key]
        public int OneHour { get; set; }
        public string TwoHours { get; set; }
        public string ThreeHours { get; set; }
    }
}