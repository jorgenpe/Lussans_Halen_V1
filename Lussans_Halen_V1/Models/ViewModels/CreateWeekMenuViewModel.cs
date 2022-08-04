﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Lussans_Halen_V1.Models.ViewModels
{
    public class CreateWeekMenuViewModel
    {
        public int WeekMenuId { get; set; }
        
      
        public double DayPrice { get; set; }
        public int WeekNumber { get; set; }
        public Weekday Day { get; set; }

        public int Week { get; set; }

        public List<int> Weeks { get; set; }
        public List<int> ListDishId { get; set; }

        public List<DishWeekMenu> DishWeekMenuList { get; set; }
        public List<Dish> DishList { get; set; }
        public List<WeekMenu> WeekMenuList { get; set; }    
        
    }
}
