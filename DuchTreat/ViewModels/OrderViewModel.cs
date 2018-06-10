﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DuchTreat.ViewModels
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }


        public DateTime OrderDate { get; set; }

        [Required]
        [MinLength(5)]
        public string OrderNumber { get; set; }

        public ICollection<OrderItemViewModel> Items { get; set; }
    }
}
