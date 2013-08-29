﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileSales.Models
{
    public class Route
    {
        public int RouteID { get; set; }
        [Required]
        [StringLength(30)]
        public string RouteName { get; set; }

    }
}