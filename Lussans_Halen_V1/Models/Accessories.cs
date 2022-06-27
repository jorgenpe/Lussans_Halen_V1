﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Lussans_Halen_V1.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lussans_Halen_V1.Models
{
    public class Accessories
    {
        [Key]
        public int AccessoriesId { get; set; }
        public string AccessoriesName { get; set; }

        public List<Dish> dishes { get; set; }
    }
}
