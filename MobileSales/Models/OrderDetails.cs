﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSales.Models
{
    public class OrderDetails
    {
        public int OrderDetailsID { get; set; }
        public int OrderID { get; set; }
        virtual public Order Order { get; set; }
        public int ProductID { get; set; }
        virtual public Product Product { get; set; }
        public decimal  Quantity { get; set; }


    }
}